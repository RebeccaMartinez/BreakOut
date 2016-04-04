﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveMedicalData : MonoBehaviour {
	StreamWriter stream = null;
	public static SaveMedicalData instance;

	public string URL;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
			URL = Application.persistentDataPath + "/Medicaldata.txt";
			if (stream == null) {
				stream = File.AppendText(URL);
			}
		} 
		else {
			Destroy (gameObject);
		}
	}
			
	public void Save(float x, float y){
		stream.WriteLine (x + " , " + y);
	}

	void OnApplicationQuit()
	{
		if (stream != null) {
			stream.Close ();
		}
	}

}