using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Game : BaseObject
{
	public float TotalTime { get { return _time; } }

	private float _time;

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

	override protected void ResetForPool()
	{
		base.ResetForPool();
	}
	
	override protected void BeforeFirstTick()
	{
		base.BeforeFirstTick();

		Debug.Log ("Construct");

		World.GateManager.GateEntered -= EnteredGate;
		World.GateManager.GateEntered += EnteredGate;
	}


	override protected void Tick()
	{
		_time += GameDeltaTime;

		World.GameCanvas.SetTotalTime(_time);

		base.Tick();
	}

	public void StartGame()
	{
		World.GateManager.GatherGates();

		World.GameCanvas.SetNumGatesRemaining(World.GateManager.Gates.Count);
		World.GameCanvas.SetTotalTime(0);
	}

	public void EndGame()
	{
		var total = World.Game.TotalTime;
		var best = PlayerPrefs.GetFloat("BestTime");
		if (total > best)
			return;

		// TODO: show a splash screen about best time
		Debug.LogWarning("Best Time! " + total);

		PlayerPrefs.SetFloat("BestTime", total);
		PlayerPrefs.SetString("BestGhostRace", World.Player.GetComponent<Recorder>().SerialiseToString());
	}
}
