using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GhostPlayer : BaseObject
{
	Playback _playBack;

	public void StartPlaying (string rec)
	{
		_playBack = Playback.CreateFromString(rec);
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
}

