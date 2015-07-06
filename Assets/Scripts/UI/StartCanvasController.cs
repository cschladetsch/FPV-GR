using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Start canvas controller for pre-game and splash screen.
/// Shows best times and leaderboards, allows to login to FB.
/// </summary>
public class StartCanvasController : BaseObject
{
	public void ClearGhostRace()
	{
		PlayerPrefs.SetFloat("BestTime", 0);
		PlayerPrefs.SetString("BestGhostRace", null);
	}

	override protected void Construct()
	{
		base.Construct();
	}

	override protected void Destruct()
	{
		base.Destruct();
	}

	override public void StartLevel()
	{
		base.StartLevel();
	}
	
	override protected void BeforeFirstTick()
	{
		base.BeforeFirstTick();
	}

	override protected void Tick()
	{
		base.Tick();
	}

	public void StartButtonPressed()
	{
		World.StartGame();
	}
}

