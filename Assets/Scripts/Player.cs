using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Player : BaseObject
{
	public Transform StartPoint;

	public float MaxAccel = 5;
	public float MaxSpeed = 20;		// world units/second
	public float MinSpeed = 0;
	public float TurnRate = 25; 	// degreees/second

	public float MoveDampTime = 0.2f;
	public float RotDampTime = 5.5f;

	float _speed;
	float _yaw;

	override protected void Construct()
	{
		base.Construct();
	}

	override protected void BeforeFirstTick()
	{
		base.BeforeFirstTick();
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

		pos += Vector3.SmoothDamp(pos, tr.forward*_speed*Time.deltaTime, _moveVel, MoveDampTime);
	//	rot =
	}

	// sign... .net 4.5 [Flags]
	enum ControlInput
	{
		Forward = 1,
		Backward = 2,
		Left = 4,
		Right = 8,
	}

	int GetInput()
	{
		int input;

		if (Input.GetKey(KeyCode.UpArrow))
			input |= ControlInput.Forward;

		if (Input.GetKey(KeyCode.DownArrow))
			input |= ControlInput.Backward;

		if (Input.GetKey(KeyCode.LeftArrow))
			input |= ControlInput.Left;

		if (Input.GetKey(KeyCode.RightArrow))
			input |= ControlInput.Right;

		return input;
	}

	void ChangeSpeed (int flags)
	{
		if (flags & ControlInput.Forward)
			_speed += Time.deltaTime * MaxAccel;
		if (flags & ControlInput.Backward)
			_speed -= Time.deltaTime * MaxAccel;
		_speed = Mathf.Clamp (_speed, -MaxSpeed, MaxSpeed);
	}

	void ChangeDirection (int flags)
	{
		if (flags & ControlInput.Forward)
			_yaw += Time.deltaTime * MaxAccel;
		if (flags & ControlInput.Backward)
			_yaw -= Time.deltaTime * MaxAccel;
		_yaw = Mathf.Clamp (_yaw, 0, 360);
	}

	void ProcessInput(int flags)
	{
		ChangeSpeed (flags);

		ChangeDirection(flags);


	}
}

