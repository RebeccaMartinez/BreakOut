using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class winInterface : MonoBehaviour {

    public Text fin;
	
	// Update is called once per frame
	void Update () {
        if (Global.win) {
            fin.text = "You win";
        }
        else {
            fin.text = "Game Over";
        }
    }
}
