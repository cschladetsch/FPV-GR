using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : BaseObject
{
	public Text BestTime;
	public Text WorseTime;
	public Text AverageTime;

	override protected void Construct()
	{
		base.Construct();

		SetText(BestTime, PlayerPrefs.GetFloat("BestTime"));
		SetText(AverageTime, PlayerPrefs.GetFloat("AverageTime"));
        SetText(WorseTime, PlayerPrefs.GetFloat("WorseTime"));
	}

	void SetText(Text text, float val)
	{
		text.text = val.ToString("{0:0.00}");
	}

	override protected void Destruct()
	{
		base.Destruct();
	}

	override protected void ResetForPool()
	{
		base.ResetForPool();
	}
	
	override protected void BeforeFirstTick()
	{
		base.BeforeFirstTick();
	}

	override protected void Tick()
	{
		base.Tick();
	}
}

