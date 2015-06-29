using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class StartCanvasController : BaseObject
{
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

	public void StartButtonPressed()
	{
		Debug.Log ("Start button Pressed");
		World.StartGame();
	}
}

