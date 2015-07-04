using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The *Local* Player.
/// </summary>
public class Player : BaseObject
{
	Camera FpVCamera;

	[Tooltip("How fast the player can accel")]
	public float MaxAccel = 500;		// maximum acceleration in m/s/s
	public float MaxSpeed = 20;			// m/s
	public float MinSpeed = 0;
	public float TurnRate = 25; 		// deg/s

	public float SpeedFriction = 0.2f;
	public float YawFriction = 5.0f;

	public float MoveDampTime = 0.2f;
	public float RotDampTime = 0.5f;

	public bool IsPlayingBack { get { return _isPlayingBack; } } 

	List<StateRecord> _samples = new List<StateRecord>();

	float _speed;
	float _yaw, _pitch, _roll;
	bool _isPlayingBack;

	Recorder _recorder;
	Playback _playBack;

	override protected void Construct()
	{
		base.Construct();

		_recorder = GetComponent<Recorder>();
		_playBack = GetComponent<Playback>();

//		Debug.Log ("Player Constructed");
	}

	void ApplyFriction()
	{
		var fr = SpeedFriction*Time.deltaTime;

		if (_speed > 0)
			_speed -= fr;
		else
			_speed += fr;
	}

	override protected void Tick()
	{
		base.Tick();

		ProcessInput(GetInput());

		ApplyFriction();

		Move();
	}

	Vector3 _moveVel;

	void Move()
	{
		var tr = transform;	
		var pos = tr.position;
		var rot = tr.rotation;
		var newRot = Quaternion.AngleAxis(_yaw, Vector3.up);
		
		transform.rotation = Quaternion.Slerp(rot, newRot, RotDampTime);
		transform.position = Vector3.SmoothDamp(pos, pos + tr.forward*_speed*Time.deltaTime, ref _moveVel, MoveDampTime);
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
			_speed += MaxAccel*GameDeltaTime;

		if (On(flags, ControlInput.Backward))
			_speed -= MaxAccel*GameDeltaTime;

		_speed = Mathf.Clamp(_speed, -MaxSpeed, MaxSpeed);
	}

	float Clamp360(float a)
	{
		while (a  > 360)
			a -= 360;

		while (a < 0)
			a += 360;

		return a;
	}

	void ChangeDirection(int flags)
	{
		if (On(flags, ControlInput.Left))
			_yaw -= TurnRate*Time.deltaTime;

		if (On(flags, ControlInput.Right))
			_yaw += TurnRate*Time.deltaTime;

		//_yaw = Clamp360(_yaw)*Mathf.Deg2Rad;
	}

	void ProcessInput(int flags)
	{
		ChangeSpeed(flags);

		ChangeDirection(flags);
	}

	public void PassedThroughGate (GameObject gate)
	{
		Debug.Log ("Passed through " + gate.transform.parent.name);
		//World.GateManager.PassedThrough(gate.GetComponent<Gate>());
	}
}
