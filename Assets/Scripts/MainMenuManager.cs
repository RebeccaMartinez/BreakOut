using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour {
	private float waitTime = 0.9f;
	private float delay;

	// Use this for initialization
	void Start () {
		delay = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
		//Current pointer position
		PointerEventData point = new PointerEventData(null);
		point.position = Input.mousePosition;
		//result will contain all of the hit canvas
		List<RaycastResult> results = new List<RaycastResult> ();
		gr.Raycast (point, results);

		if (results.Count > 0) {
			for (int i = 0; i < results.Count; i++) {

				if (delay > waitTime) {
					if (results [i].gameObject.name == "Play") {
						SceneManager.LoadScene ("Level1"); 
					} 
				} else {
					delay += Time.deltaTime;
				}
			}
		}

	}
}
