using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class StateRecord
{
	public string SerialiseToString ()
	{
		return string.Format ("{0} {1} {2} {3} {4} {5} {6} {7}",
		                      Position.x, Position.y, Position.z, 
		                      Rotation.x, Rotation.y, Rotation.z, Rotation.w, 
		                      GameTime);
	}

	public static StateRecord SerialiseFromString(string text)
	{
		var sr = new StateRecord();
		var sp = text.Split (new char[]{' '});

		sr.Position = new Vector3(float.Parse (sp[0]), float.Parse (sp[1]), float.Parse (sp[2]));
		sr.Rotation = new Quaternion(float.Parse (sp[3]), float.Parse (sp[4]), float.Parse (sp[5]), float.Parse (sp[6]));
		sr.GameTime = float.Parse(sp[7]);
	
		return sr;
	}

	public Vector3 Position;

	public Quaternion Rotation;

	public float GameTime;

	public StateRecord()
	{
	}
	
	public StateRecord(BaseObject bo)
	{
		Position = bo.transform.position;
		Rotation = bo.transform.rotation;
		GameTime = bo.GameTime;
	}

	/// <summary>
	/// Interpolate between two StateRecords.
	/// </summary>
	/// <param name="A">A.</param>
	/// <param name="B">B.</param>
	/// <param name="t">T, the interpolation factor in range [0..1]</param>
	public static StateRecord Interpolate(StateRecord A, StateRecord B, float t)
	{
		var sr = new StateRecord();
		sr.Position = A.Position + (B.Position - A.Position)*t;
		sr.Rotation = Quaternion.Slerp(A.Rotation, B.Rotation, t);
		sr.GameTime = A.GameTime + (B.GameTime - A.GameTime)*t;
		return sr;
	}

	public float Apply(Transform tr)
	{
		tr.position = Position;
		tr.rotation = Rotation;
		return GameTime;
	}
}

