using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Time panel contains a collection of TimeDisplay objectss
/// </summary>
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
}
