using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KeyboardManager : MonoBehaviour {
	private float waitTime = 0.9f;
	private string text;
	private float delay;


	// Use this for initialization
	void Start () {
		text = "";
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
					if (results [i].gameObject.name == "Save") {
						SceneManager.LoadScene ("FinishGame"); 
					}

					if (results [i].gameObject.name == "Delete") {

						try {
							text = text.Substring (0, text.Length - 1);
							delay = 0;
						} catch (System.Exception e){
							text = "";
							delay = 0;
						}

					}

					if (results [i].gameObject.name == "Space") {
						text = text + " ";
						delay = 0;
					} 

					if (results [i].gameObject.name == "letter") {
						text += results [i].gameObject.GetComponentInChildren<Text> ().text;
						delay = 0;
					}
				} else {
					delay += Time.deltaTime;
				}
				Debug.Log (text);
			}
		}
	
	}

	public string getText(){
		return text;
	}

	void OnGUI(){
		GUI.skin.label.fontSize = 50;
		//cambiar 1000 por tamaño adecuado
		GUI.Label (new Rect (400, 100, 1000, 1000), getText ());
	}
}
