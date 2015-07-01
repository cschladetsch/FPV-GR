using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Logic for main game sequence: flying through hoops
/// </summary>
public class Game : BaseObject
{
	public GhostPlayer GhostPlayer;

	override protected void Construct()
	{
		base.Construct();
	}

	void EnteredGate(Gate gate)
	{
		if (gate.HasBeenEntered)
			return;

		gate.Entered();
	}

	override protected void Destruct()
	{
		base.Destruct();
	}

	override public void StartLevel()
	{
		base.StartLevel();

		//StartGame();
	}
	
	override protected void BeforeFirstTick()
	{
		base.BeforeFirstTick();

		World.GateManager.GateEntered -= EnteredGate;
		World.GateManager.GateEntered += EnteredGate;
	}

	override protected void Tick()
	{
		base.Tick();

		World.GameCanvas.SetTotalTime(GameTime);
	}

	public void StartGame()
	{
		foreach (var go in FindObjectsOfType<BaseObject>())
			go.StartLevel();

		Debug.Log("Game.StartGame");

		var rec = PlayerPrefs.GetString("BestGhostRace");
		if (!string.IsNullOrEmpty(rec))
		{
			GhostPlayer.SetRecording(rec);
		}
 
		World.GameCanvas.SetNumGatesRemaining(World.GateManager.Gates.Count);
		World.GameCanvas.SetTotalTime(0);
	}

	public void EndGame()
	{
		Debug.Log ("Game.EndGame");

		var total = World.Game.GameTime;
		var best = PlayerPrefs.GetFloat("BestTime");
		if (total < best)
		{
			// TODO: show a splash screen about best time
			Debug.LogWarning("Best Time! " + total);

			PlayerPrefs.SetFloat("BestTime", total);
			PlayerPrefs.SetString("BestGhostRace", World.Player.GetComponent<Recorder>().SerialiseToString());
		}

		// go back to title screen.
		World.ActivateGame(false);
	}
}
