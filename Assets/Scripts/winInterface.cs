using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class winInterface : MonoBehaviour {

    public Text fin;
    private string textFieldString = "text field";
	
	// Update is called once per frame
	void Update () {
        if (Global.win) {
            fin.text = "You win";
        }
        else {
            fin.text = "Game Over";
        }
    }

    /*void OnGUI() {
        textFieldString = GUI.TextField(new Rect(500, 25, 100, 30), textFieldString, 25);
        //GUI.Label(new Rect(505, 75, 100, 100), textFieldString);
    }*/
}
