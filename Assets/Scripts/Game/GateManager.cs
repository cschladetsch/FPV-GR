using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GateManager : BaseObject
{
	public List<Gate> Gates = new List<Gate>();

	public delegate void GateEnteredHandler(Gate gate);
	public event GateEnteredHandler GateEntered;

	public void GatherGates()
	{
		Gates = FindObjectsOfType<Gate>().ToList();
		Debug.Log ("There are " + Gates.Count + " gates");
		foreach (var g in Gates)
			g.Reset();
		base.Construct();
	}

	public void Entered (Gate gate)
	{
		if (GateEntered != null)
			GateEntered(gate);

		var remaining = Gates.Count(g => !g.HasBeenEntered);
		World.GameCanvas.SetNumGatesRemaining(remaining);
		if (remaining > 0)
			return;

		World.Game.EndGame();
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
}

