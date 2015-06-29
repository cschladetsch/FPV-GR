using UnityEngine;
using System.Collections;

public class MoveInCircle : MonoBehaviour
{
	public float Radius;
	public float DegreesPerSecond;

	float _degrees;

	void Start()
	{
		Debug.Log ("Started");
	}
	
	void Update()
	{
		var cur = transform.position;

		_degrees += DegreesPerSecond*Time.deltaTime;

		var x = Radius * Mathf.Cos (Mathf.Deg2Rad*_degrees);
		var z = Radius * Mathf.Sin (Mathf.Deg2Rad*_degrees);

		transform.position = new Vector3 (x, cur.y, z);
	}
}
