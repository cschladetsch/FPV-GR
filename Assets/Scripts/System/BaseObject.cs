using System;
using Flow;
using UnityEngine;

/// <summary>
/// Base class for all objects in the game.
/// </summary>
public class BaseObject : MonoBehaviour
{
	/// <summary>
	/// Only increases when Tick() is called, and object is not Paused
	/// </summary>
	protected int FrameCount;

	protected float GameDeltaTime;

	public float GameTime;

	/// <summary>
	/// If false, this game object will not be updated Tick() method
	/// </sum	mary>
	public bool Paused;

	protected float RealDeltaTime;
	protected float RealTime;
	private bool _firstUpate = true;

	/// <summary>
	/// The last time a Tick() was executed
	/// </summary>
	private DateTime _lastTime;

	private World _world;

	/// <summary>
	/// The single world object
	/// </summary>
	protected World World
	{
		get
		{
			if (_world != null)
				return _world;

			Awake();
			//Start();
			return _world;
		}
	}

	protected IKernel Kernel
	{
		get { return World.Kernel; }
	}
	
	public Player Player
	{
		get { return World.Player; }
	}

	public virtual void Pause(bool pause)
	{
		Paused = pause;
	}

	private void Awake()
	{
		_world = World.Instance;
		if (_world == null)
		{
			var world = FindObjectOfType<World>();
			if (!world.Loaded)
			{
				// TODO: add to things to Awake when world is fully loaded
				return;
			}
			_world = world;
			_world.Awaken();

			// TODO _world.Awoken += Construct();
			Debug.Log ("World not awoken yet: " + name);
			return;
		}

		_world.Awaken();

		//Debug.Log ("Constructing:\t " + name);
		Construct();
	}

	public virtual void StartLevel()
	{
		GameTime = 0;
	}

	protected virtual void Construct()
	{
		//Debug.Log("Name=" + name + ", World=" + World);
		_lastTime = DateTime.Now;
	}

	protected virtual void Destruct()
	{
		// TODO: pooling
	}

	void OnDestroy()
	{
		Destruct();
	}

	protected void ResetRealTime()
	{
		_lastTime = DateTime.Now;
		RealDeltaTime = 0;
		RealTime = 0;
	}

	private void Update()
	{
		if (!World.Loaded)
			return;

		DateTime now = DateTime.Now;
		TimeSpan delta = now - _lastTime;
		RealDeltaTime = (float) delta.TotalSeconds;
		_lastTime = now;
		RealTime += RealDeltaTime;

		if (Paused)
			return;

		FrameCount++;

		GameDeltaTime = Time.deltaTime;

		if (_firstUpate)
		{
			_firstUpate = false;

			BeforeFirstTick();
		}

		Tick();

		GameTime += GameDeltaTime;
	}

	protected virtual void BeforeFirstTick()
	{
	}

	protected virtual void Tick()
	{
	}
}