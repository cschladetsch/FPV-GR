using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Game canvas controller, for in-game UI events and display.
/// </summary>
public class GameCanvasController : BaseObject
{
	public Text TotalTimeText;
	public Text NumGates;
	
	override protected void Construct()
	{
		base.Construct();
	}

	override protected void Destruct()
	{
		base.Destruct();
	}

	override protected void StartLevel()
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

	public void QuitButtonPressed()
	{
		World.QuitFromGameButtonPressed();
	}

	public void SetTotalTime(float t)
	{
		TotalTimeText.text = t.ToString("F");
	}

	public void SetNumGatesRemaining(int g)
	{
		NumGates.text = g.ToString();
	}
}
