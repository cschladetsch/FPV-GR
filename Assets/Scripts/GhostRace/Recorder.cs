using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Recorder : BaseObject
{
	public Object MarkerPrefab;

	[Tooltip("How long between samples")]
	public float SampleTime = 0.100f;

	public List<StateRecord> Samples { get { return _samples; } }

	List<StateRecord> _samples = new List<StateRecord>();

	Flow.IPeriodic _timer;
	
	override protected void Construct()
	{
		base.Construct();

		_timer = Kernel.Factory.NewPeriodicTimer(System.TimeSpan.FromSeconds(SampleTime));
		_timer.Elapsed += TakeSample;
	}

	void TakeSample (Flow.ITransient sender)
	{
		var sr = new StateRecord (this);
		_samples.Add(sr);

//		if (MarkerPrefab != null)
//		{
//			var marker = (GameObject)Instantiate(MarkerPrefab);
//			marker.transform.position = sr.Position;
//			marker.transform.rotation = sr.Rotation;
//		}
	}

	override protected void Destruct()
	{
		base.Destruct();
	}

	override public void StartLevel()
	{
		base.StartLevel();
	}

	// testing capturing gifs and sending to Slack
	override protected void BeforeFirstTick()
	{
		base.BeforeFirstTick();
	}

	override protected void Tick()
	{
		base.Tick();
	}

	public string SerialiseToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine(_samples.Count.ToString());
		foreach (var s in _samples)
			sb.AppendLine(s.SerialiseToString());

		Debug.Log (sb.ToString ());

		return sb.ToString();
	}


}
