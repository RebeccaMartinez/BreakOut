﻿//Script taht controls the movement of the bar
using UnityEngine;
using System.Collections;
using TETCSharpClient;
using TETCSharpClient.Data;

public class Bar : MonoBehaviour, IGazeListener{

	//Variables
	Vector3 speed = new Vector3(.5f, 0, 0);
	public float barSpeed = 1f; //Velocidad de la barra
	private Vector3 playerPos = new Vector3(0, -12f, 0); //Posición inicial
    //private Vector3 mousePosition;
	Vector3 CamaraPosition;
	float xPos;

	void Start(){
		//register for gaze updates
		CamaraPosition = GameObject.Find ("Main Camera").transform.position;
		GazeManager.Instance.AddGazeListener(this);

	}
    // Update is called once per frame
    void Update () {
		/* @TheEyeTribe Check for collision and position waypoint */ 
		Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates();
		Debug.Log(gazeCoords);
		Vector3 mouse;
		playerPos = transform.position;
		float radio = GetComponent<Renderer> ().bounds.extents.x;
		if (null != gazeCoords) {
			// Map gaze indicator
			Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords (gazeCoords);
			mouse = new Vector3 ((float)gp.X, (float)gp.Y, CamaraPosition.z);
			mouse = Camera.main.ScreenToWorldPoint(mouse);

		} 
		else {
			mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		if (mouse.x - playerPos.x < -radio/100) { //Raton a la izquierda
			transform.Translate(-1 * speed);
		} 
		else if(mouse.x - playerPos.x > radio/3){
			transform.Translate (speed);
		}
			
		if (transform.position.x > 18f) {
			transform.position = new Vector3(18f, transform.position.y, transform.position.z);;
		}
		if (transform.position.x < -18f) {
			transform.position = new Vector3(-18f, transform.position.y, transform.position.z);
		}


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
