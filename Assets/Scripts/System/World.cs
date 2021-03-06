﻿using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the main game flow
/// </summary>
public class World : BaseObject
{
	[Tooltip("The Canvas for use for the in-game scene")]
	public GameCanvasController GameCanvas;

	[Tooltip("The Canvas for use for the pre-game scene")]
	public Canvas StartCanvas;

	public Camera SplashCamera;

	public static World Instance;

	/// <summary>
	/// True if all mixin scenes have been loaded.
	/// </summary>
	public bool Loaded { get { return _loaded; } }

	/// <summary>
	/// The Co-Routine kernel used by the game
	/// </summary>
	/// <value>The kernel.</value>
	public new  Flow.IKernel Kernel { get { return _kernel; } }

	public new Player Player { get { return _player; } } 

	public GateManager GateManager { get { return _gateManager; } } 

	public Game Game { get { return _game; } } 

	/// <summary>
	/// When using multiple mixin scenes, they are specified here.
	/// This allows multiple people to work on differnt, otherwise disjoint aspects of
	/// the same scene.
	/// </summary>
	public string[] ScenesToLoad;
	
	Flow.IKernel _kernel;

	/// <summary>
	/// True if all mixin scenes are loaded
	/// </summary>
	private bool _loaded;

	Player _player;

	Game _game;

	void Start()
	{
		Awaken();
	}

	/// <summary>
	/// Invoked when the quit game button is pressed when in game mode
	/// </summary>
	public void QuitFromGameButtonPressed()
	{
		//CurrentLevel.Stop();
		ActivateGame(false);
		Debug.Log("World.EndGame");
	}

	/// <summary>
	/// Starts the game.
	/// </summary>
	public void StartGame ()
	{
		ActivateGame(true);
	}

	GateManager _gateManager;

	public void ActivateGame(bool inGame)
	{
//		Debug.Log("World.ActivateGame: " + inGame);

		// switch canvas's
		GameCanvas.gameObject.SetActive(inGame);
		StartCanvas.gameObject.SetActive(!inGame);

//		// switch Camera's
//		Player.GetComponent<Camera>().enabled = inGame;
//		SplashCamera.enabled = !inGame;

		if (inGame)
			Game.StartGame();
	}

	/// <summary>
	/// Used to initialise the singleton World object
	/// </summary>
	internal void Awaken()
	{
		if (Instance != null)
			return;

		Instance = this;

		_kernel = Flow.Create.NewKernel();

		_player = FindObjectOfType<Player>();

		GameCanvas = FindObjectOfType<GameCanvasController>();

		_gateManager = FindObjectOfType<GateManager>();

		_game = FindObjectOfType<Game>();

		// TODO: combine scenes
		_loaded = true;

		ActivateGame(false);
	}

	override protected void Construct()
	{
	}

	override protected void Destruct()
	{
	}

	override protected void Tick()
	{
		if (Kernel != null)
		{
			Kernel.Step();
		}
	}
}

