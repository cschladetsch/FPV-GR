using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GhostPlayer : BaseObject
{
	Playback _playBack;

	public void StartPlaying (string rec)
	{
		_playBack.CreateFromString(rec);
	}

	override protected void Construct()
	{
		base.Construct();
		_playBack = GetComponent<Playback>();
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

		var t = GameTime;

		// find prev and next records that bracket the current game time
		StateRecord prev = null, next = null; 
		foreach (var s in _playBack.Samples)
		{
			prev = next;
			next = s;
			if (next.GameTime >= t)
			{
				break;
			}
		}

		if (next != null)
			SetGhostPlayerTransform (prev, next);
	}

	void SetGhostPlayerTransform (StateRecord prev, StateRecord next)
	{
		var p = next.Position;
		var r = next.Rotation;
		if (prev != null) 
		{
			var dt = next.GameTime - prev.GameTime;
			var a = (GameTime - prev.GameTime)/dt;

			p = prev.Position + (next.Position - prev.Position)*a;
			r = Quaternion.Slerp(prev.Rotation, next.Rotation, a);
		}

		transform.position = p;
		transform.rotation = r;
	}
}
