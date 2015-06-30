using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

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

	override protected void ResetForPool()
	{
		base.ResetForPool();
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
