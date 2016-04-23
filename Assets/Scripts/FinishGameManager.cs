using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TETCSharpClient;
using TETCSharpClient.Data;


public class FinishGameManager : MonoBehaviour,  IGazeListener {

	private float waitTime = 0.6f;
	private float delay;
	Camera CamaraPosition;

	// Use this for initialization
	void Start () {
		delay = 0f;
		GazeManager.Instance.AddGazeListener(this);
		CamaraPosition = GameObject.Find ("Main Camera").GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
		/*GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
		//Current pointer position
		PointerEventData point = new PointerEventData(null);
		point.position = Input.mousePosition;
		//result will contain all of the hit canvas
		List<RaycastResult> results = new List<RaycastResult> ();
		gr.Raycast (point, results);*/
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

				if (delay > waitTime) {
					if (results [i].gameObject.name == "menu") {
						SceneManager.LoadScene ("MainMenu"); 
					} 
					if (results [i].gameObject.name == "keyboard") {
						SceneManager.LoadScene ("Keyboard"); 
					}
				} else {
					delay += Time.deltaTime;
				}
			}
		}
	}
		
	public void OnGazeUpdate(GazeData gazeData)
	{
		//Debug.Log ("entreeee");
		//Add frame to GazeData cache handler
		GazeDataValidator.Instance.Update(gazeData);
	}

}
