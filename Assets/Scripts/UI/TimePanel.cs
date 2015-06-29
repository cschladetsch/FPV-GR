﻿using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TimePanel : BaseObject
{
	public TimeDisplay Best;
	public TimeDisplay Avergage;
	public TimeDisplay Worst;

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
