using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for feeding new states for ghost players
/// </summary>
public class Playback : BaseObject
{
	List<StateRecord> _samples = new List<StateRecord>();

	GhostPlayer _ghost;

	public List<StateRecord> Samples { get { return _samples; } }

	public void CreateFromString(string text)
	{
		var lines = text.Split(new char[]{'\n'});
		var count = int.Parse(lines[0]);
		var list = new List<StateRecord>();
		for (var n = 1; n < count; ++n)
		{
			list.Add (StateRecord.SerialiseFromString(lines[n]));
		}

		_samples = list;
	}

	override protected void Construct()
	{
		base.Construct();

		_ghost = GetComponent<GhostPlayer>();
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
}

