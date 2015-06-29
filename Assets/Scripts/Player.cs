using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Player : BaseObject
{
	[Tooltip("Where the player starts")]
	public Transform StartPoint;

	[Tooltip("How fast the player can accel")]
	public float MaxAccel = 500;		// maximum acceleration in m/s/s
	public float MaxSpeed = 20;		// m/s
	public float MinSpeed = 0;
	public float TurnRate = 25; 	// deg/s

	public float MoveDampTime = 0.2f;
	public float RotDampTime = 5.5f;

	float _speed;
	float _yaw;

	override protected void Construct()
	{
		base.Construct();

		transform.position = StartPoint.position;
		transform.rotation = StartPoint.rotation;
	}

	override protected void Tick()
	{
		base.Tick();

		ProcessInput(GetInput());

		Move();
	}

	Vector3 _moveVel;

	void Move()
	{
		var tr = transform;	
		var pos = tr.position;
		var rot = tr.rotation;

		pos = Vector3.SmoothDamp(pos, tr.forward*_speed*Time.deltaTime, ref _moveVel, MoveDampTime);

		transform.position = pos;

		//Debug.Log (string.Format ("Player.Move: {0}, {1}", pos, _speed));
	}

	// sigh... .net 4.5 [Flags]
	enum ControlInput
	{
		Forward = 1,
		Backward = 2,
		Left = 4,
		Right = 8,
	}
	
	bool On(int flags, ControlInput inp)
	{
		return (flags & (int)inp) != 0;
	}
	
	bool Off(int flags, ControlInput inp)
	{
		return !On(flags, inp);
	}

	int GetInput()
	{
		int input = 0;

		if (Input.GetKey(KeyCode.UpArrow))
			input |= (int)ControlInput.Forward;

		if (Input.GetKey(KeyCode.DownArrow))
			input |= (int)ControlInput.Backward;

		if (Input.GetKey(KeyCode.LeftArrow))
			input |= (int)ControlInput.Left;

		if (Input.GetKey(KeyCode.RightArrow))
			input |= (int)ControlInput.Right;

		return input;
	}

	void ChangeSpeed(int flags)
	{
		if (On(flags, ControlInput.Forward))
			_speed += MaxAccel;

		if (On(flags, ControlInput.Backward))
			_speed -= MaxAccel;

		_speed = Mathf.Clamp (_speed, -MaxSpeed, MaxSpeed);
	}

	float Clamp360(float a)
	{
		Debug.Log(a);

		while (a  > 360)
			a -= 360;

		while (a < 0)
			a += 360;

		return a;
	}

	void ChangeDirection(int flags)
	{
		if (On(flags, ControlInput.Forward))
			_yaw += Time.deltaTime * MaxAccel;

		if (On(flags, ControlInput.Backward))
			_yaw -= Time.deltaTime * MaxAccel;

		_yaw = Clamp360(_yaw);
	}

	void ProcessInput(int flags)
	{
		ChangeSpeed (flags);

		ChangeDirection(flags);
	}
}
