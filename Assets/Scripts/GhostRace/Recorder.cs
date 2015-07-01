using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Recorder : BaseObject
{
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
		_samples.Add(new StateRecord(this));
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

	public string SerialiseToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine(_samples.Count.ToString());
		foreach (var s in _samples)
			sb.AppendLine(s.SerialiseToString());

		return sb.ToString();
	}


}
