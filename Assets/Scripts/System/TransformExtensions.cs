using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TransformExtensions
{
	public static IEnumerable<T> GetValues<T>()
	{
		return Enum.GetValues(typeof (T)).Cast<T>();
	}

	public static IEnumerable<GameObject> GetAllChildren(this GameObject go)
	{
		foreach (Transform tr in go.transform)
		{
			yield return tr.gameObject;

			foreach (GameObject ch in tr.gameObject.GetAllChildren())
				yield return ch;
		}
	}

	public static void SetX(this Transform tr, float x)
	{
		Vector3 p = tr.position;
		tr.position = new Vector3(x, p.y, p.z);
	}

	public static void SetY(this Transform tr, float y)
	{
		Vector3 p = tr.position;
		tr.position = new Vector3(p.x, y, p.z);
	}

	public static void SetZ(this Transform tr, float z)
	{
		Vector3 p = tr.position;
		tr.position = new Vector3(p.x, p.y, z);
	}
}
