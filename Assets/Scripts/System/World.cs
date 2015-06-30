using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class World : BaseObject
{
	[Tooltip("The Canvas for use for the in-game scene")]
	public Canvas GameCanvas;

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

	public Player Player { get { return _player; } } 

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

	/// <summary>
	/// Invoked when the quit game button is pressed when in game mode
	/// </summary>
	public void QuitFromGameButtonPressed()
	{
		CurrentLevel.Stop();
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

	void ActivateGame(bool inGame)
	{
		//Debug.Log("World.ActivateGame: " + inGame);

		// switch canvas's
		GameCanvas.gameObject.SetActive(inGame);
		StartCanvas.gameObject.SetActive(!inGame);

		// switch Camera's
		FindObjectOfType<Player>().GetComponent<Camera>().enabled = inGame;
		SplashCamera.enabled = !inGame;
	}

	/// <summary>
	/// Used to initialise the singleton World object
	/// </summary>
	internal void Awaken()
	{
		Instance = this;

		_kernel = Flow.Create.NewKernel();

		_player = FindObjectOfType<Player>();

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
	}
}

