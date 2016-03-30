using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


[Serializable]
public class EyePositionData : MonoBehaviour {

	protected List<float> XEyePos { get; set; }
	protected List<float> YEyePos { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="EyePositionData"/> class.
	/// </summary>
	public EyePositionData(){
		XEyePos = new List<float> ();
		YEyePos  = new List<float> ();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="EyePositionData"/> class.
	/// </summary>
	/// <param name="XEyePos">X eye position.</param>
	/// <param name="YEyePos">Y eye position.</param>
	public EyePositionData(List<float> XEyePos, List<float> YEyePos){
		this.XEyePos = XEyePos;
		this.YEyePos = YEyePos;
	}

	public List<float> getXEyePos(){
		return this.XEyePos;
	}

	public List<float> getYEyePos(){
		return this.YEyePos;
	}

	public void addValue(float x, float y){
		this.XEyePos.Add (x);
		this.YEyePos.Add (y);

	}
}
