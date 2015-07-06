using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The player passes through gates in any order. Currently there is assumed
/// to be only one player, but we will need separate indicators and HasBeenEntered
/// flags for each player (or inverse this, and store that info in Player class).
/// </summary>
public class Gate : BaseObject
{
	AudioSource _audio;
	public AudioClip PassSound;
	public AudioClip FailSound;

	/// <summary>
	/// The indicator that shows if this gate has been passed through or not.
	/// </summary>
	public GameObject Indicator;

	public bool HasBeenEntered { get; private	set; }

	override protected void Construct()
	{
		base.Construct();

		_audio = GetComponent<AudioSource>();
	}

	override protected void Destruct()
	{
		base.Destruct();
	}

	override public void StartLevel()
	{
		base.StartLevel();
	}
	
	override protected void BeforeFirstTick()
	{
		base.BeforeFirstTick();
	}

	override protected void Tick()
	{
		base.Tick();
	}

	/// <summary>
	/// Reset this gate for start of new game.
	/// </summary>
	public void Reset()
	{
		HasBeenEntered = false;
		Indicator.SetActive(true);
	}

	/// <summary>
	/// The player as entered this gate.
	/// </summary>
	public void Entered()
	{
		if (HasBeenEntered)
			return;

		HasBeenEntered = true;

		Indicator.SetActive(false);
	}

	/// <summary>
	/// Player has entered a gate - red should be on right,
	/// which means +Z of this gate should be within 90 degrees of +z of quad
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other)
	{
		var angle = Vector3.Angle (transform.forward, other.transform.forward);
		//Debug.Log ("OnTriggerEnter: " + angle);

		if (angle > 90)
		{
			_audio.clip = FailSound;
			_audio.Play ();
			return;
		}
		var otherParent = other.transform.parent;
		if (otherParent == null)
			return;

		var player = otherParent.gameObject.GetComponent<Player>();

		_audio.clip = PassSound;
		_audio.Play ();
		
		if (player != null)
			World.GateManager.Entered(this);
	}
}

