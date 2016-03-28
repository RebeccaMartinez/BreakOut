//Script taht controls the movement of the bar
using UnityEngine;
using System.Collections;
using TETCSharpClient;
using TETCSharpClient.Data;

public class Bar : MonoBehaviour, IGazeListener{

	//Variables
	public float barSpeed = 1f; //Velocidad de la barra
	private Vector3 playerPos = new Vector3(0, -12f, 0); //Posición inicial
    //private Vector3 mousePosition;

	void Start(){
		//register for gaze updates
		GazeManager.Instance.AddGazeListener(this);

	}
    // Update is called once per frame
    void Update () {
		/* @TheEyeTribe Check for collision and position waypoint */ 
		Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates();
		Debug.Log(gazeCoords);
		Vector3 mouse;
		if (null != gazeCoords) {
			// Map gaze indicator
			Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords (gazeCoords);
			mouse = new Vector3 ((float)gp.X, (float)gp.Y, 0);
			mouse = Camera.main.ScreenToWorldPoint(mouse);

		} 
		else {
			mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//float xPos = transform.position.x + (Input.GetAxis("Horizontal") * (barSpeed/2));
			//Limita el movimiento de la barra en el eje x (para que no se salga de las paredes) y actualiza la posición
		}
		playerPos = new Vector3 (Mathf.Clamp (mouse.x, -18f, 18f), -12f, 0); 
		transform.position = playerPos;

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
