﻿using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Playback : BaseObject
{
	Recorder _recorder;

	public List<StateRecord> Samples { get { return _recorder.Samples; } }

	public void FromRecorder(Recorder rec)
	{
		_recorder = rec;
	}

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
}

