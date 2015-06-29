using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class World : BaseObject
{
	public void QuitFromGameButtonPressed ()
	{
		CurrentLevel.Stop();
		ActivateGameCanvas(false);
		Debug.Log("World.EndGame");
	}

	public void StartGame ()
	{
		ActivateGameCanvas(true);
		Debug.Log("World.StartGame");
	}

	public Canvas GameCanvas;
	public Canvas StartCanvas;


	public static World Instance;

	public bool Loaded { get { return _loaded; } }

	public new  Flow.IKernel Kernel { get { return _kernel; } }

	Flow.IKernel _kernel;
	private bool _loaded;

	public string[] ScenesToLoad;

	void ActivateGameCanvas(bool inGame)
	{
		GameCanvas.gameObject.SetActive (inGame);
		StartCanvas.gameObject.SetActive (!inGame);
	}

	/// <summary>
	/// Used to initialise the singleton World object
	/// </summary>
	internal void Awaken()
	{
		Instance = this;

		_kernel = Flow.Create.NewKernel();

		// TODO: combine scenes
		_loaded = true;

		ActivateGameCanvas(false);
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

