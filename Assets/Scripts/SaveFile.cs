using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveFile : MonoBehaviour {

	private String fileURL = Application.persistentDataPath + "/data.dat";
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(fileURL);

		saveData data = new saveData(Global.points, "pepe");
		bf.Serialize(file, data);
		file.Close();
	}

	void Cargar() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(fileURL, FileMode.Open);

		saveData data = (saveData)bf.Deserialize(file);

		file.Close();


	}

}

[Serializable]
class saveData {
	public int score;
	public string name;

	public saveData(int score, string name) {
		this.score = score;
		this.name = name;
	}
}
