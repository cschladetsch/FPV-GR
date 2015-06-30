using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Recorder : BaseObject
{
	[Tooltip("How long between samples")]
	public float SampleTime = 0.100f;

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

	public string SerialiseToString()
	{
		Debug.LogError("Recorder.SerialiseToString not implemented");
		return "";
	}

	public List<StateRecord> SerialiseFromString(string text)
	{
		Debug.LogError("Recorder.SerialiseFromString not implemented");
		return null;
	}
}
