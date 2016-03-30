using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveMedicalData : MonoBehaviour {
	StreamWriter stream = null;
	public static SaveMedicalData instance;
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}

	public EyePositionData medicalData;
	public string URL;
	// Use this for initialization
	void Start () {
		URL = Application.persistentDataPath + "/Medicaldata.txt";
		if (stream == null) {
			stream = File.AppendText(URL);
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
