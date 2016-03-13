using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class GM : MonoBehaviour {
	//variables
	public float resetDelay = 0.1f; //Time before de game resets when we finish
	public int bricks; //new bricks
	public GameObject bar;
	public static GM instance = null;
    public int nextLevel;

	private GameObject newBar;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		Setup ();
	}

	public void Setup(){
		newBar = Instantiate (bar, transform.position, Quaternion.identity) as GameObject;
	}

	void FinishGame(){
		if (bricks < 1) {
            //Are we in the last level?
            if (nextLevel == 0) {
                Global.win = true;
                Time.timeScale = .5f;
                SceneManager.LoadScene("FinishGame");
            }
            else {
                Time.timeScale = .2f;
                Invoke("LoadLevel", resetDelay);
            }
        }

        if(Global.lives == 0) {
            SceneManager.LoadScene("FinishGame");
        }
    }

	void LoadLevel(){
		//Time.timeScale = 1f;
        string aux = String.Concat("Level", nextLevel);
        SceneManager.LoadScene(aux);
        Time.timeScale = 1f;
    }

    public void DestroyBrick(){
		bricks--;
        Global.points ++;
		FinishGame();
	}

	public void Lose(){
		Destroy (newBar);
        Global.lives--;
		Invoke ("BarSetup", resetDelay);
		FinishGame();
	}

	void BarSetup(){
		newBar = Instantiate(bar, transform.position, Quaternion.identity) as GameObject;
	}

}
