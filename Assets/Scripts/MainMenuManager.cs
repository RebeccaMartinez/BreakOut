﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TETCSharpClient;
using TETCSharpClient.Data;



public class MainMenuManager : MonoBehaviour, IGazeListener {
	private float waitTimeButtons = 1f;
	private float waitTimeToggle = 3f;
	private float delay;
	Camera CamaraPosition;
	private Text playText;
	private Text scoreText;
	private Text exitText;

	// Use this for initialization
	void Start () {
		delay = 0f;
		GazeManager.Instance.AddGazeListener(this);
		CamaraPosition = GameObject.Find ("Main Camera").GetComponent<Camera>();
		playText = GameObject.Find ("Play").GetComponent<Text>();
		scoreText = GameObject.Find ("Score").GetComponent<Text>();
		exitText = GameObject.Find ("Exit").GetComponent<Text>();
	}


	// Update is called once per frame
	void Update () {
		Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates();
		GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
		//Current pointer position
		PointerEventData point = new PointerEventData(null);

		if (!Global.useMouse) {
			Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords (gazeCoords);
			point.position = new Vector3 ((float)gp.X, (float)gp.Y, CamaraPosition.nearClipPlane + 1f);
		} 

		else {
			point.position = Input.mousePosition;
		}

		//result will contain all of the hit canvas
		List<RaycastResult> results = new List<RaycastResult> ();
		gr.Raycast (point, results);

		if (results.Count > 0) {
			for (int i = 0; i < results.Count; i++) {

				/*if (delay > waitTimeButtons) {
					if (results [i].gameObject.name == "Play") {
						SceneManager.LoadScene ("Level1"); 
					} 
				} else {
					delay += Time.deltaTime;
				}
				if (delay > waitTimeToggle) {
					if (results [i].gameObject.name == "Toggle") {
						if (changeSaveData () == false) {
							results [i].gameObject.GetComponentInChildren<Toggle> ().isOn = false;
						} else {
							results [i].gameObject.GetComponentInChildren<Toggle> ().isOn = true;
						}
						delay = 0;
					}
				} else {
					delay += Time.deltaTime;
				}*/
				if (results [i].gameObject.name == "Play") {
					playText.color = Color.blue;
					if (delay > waitTimeButtons) {
						SceneManager.LoadScene ("Level1");
					} else {
						delay += Time.deltaTime;
					}
				} else {
					playText.color = Color.white;
				}

				if (results [i].gameObject.name == "Score") {
					scoreText.color = Color.green;
					if (delay > waitTimeButtons) {
						SceneManager.LoadScene ("Score");
					} else {
						delay += Time.deltaTime;
					}
				} else {
					scoreText.color = Color.white;
				}

				if (results [i].gameObject.name == "Exit") {
					exitText.color = Color.red;
					if (delay > waitTimeButtons) {
						exitGame();
					} else {
						delay += Time.deltaTime;
					}
				} else {
					exitText.color = Color.white;
				}

				if (results [i].gameObject.name == "Toggle") {
					if (delay > waitTimeToggle) {
						if (changeSaveData () == false) {
							results [i].gameObject.GetComponentInChildren<Toggle> ().isOn = false;
						} else {
							results [i].gameObject.GetComponentInChildren<Toggle> ().isOn = true;
						}
						delay = 0;
					} else {
						delay += Time.deltaTime;
					}
				}

			}
		}

	}

	public bool changeSaveData(){
		if (Global.saveData == true) {
			Global.saveData = false;
			return false;
		} 
		else {
			Global.saveData = true;
			return true;
		}
	}

	public void exitGame() {
		Application.Quit();
	}

	public void OnGazeUpdate(GazeData gazeData)
	{
		//Debug.Log ("entreeee");
		//Add frame to GazeData cache handler
		GazeDataValidator.Instance.Update(gazeData);
	}

	void OnApplicationQuit()
	{
		GazeManager.Instance.RemoveGazeListener(this);
		GazeManager.Instance.Deactivate();
	}
}
