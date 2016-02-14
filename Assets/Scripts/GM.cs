using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	//variables
	public float resetDelay = 1f; //Time before de game resets when we finish
	public int bricks; //new bricks
	//public GameObject bricksPrefab;
	public GameObject bar;
	public static GM instance = null;
	public GameObject win;

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
		//Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}

	void FinishGame(){
		if (bricks < 1) {
			win.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset(){
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // The last level is reloaded

	}

	public void DestroyBrick(){
		bricks--;
		FinishGame();
	}

	public void Lose(){
		Destroy (newBar);
		Invoke ("BarSetup", resetDelay);
		FinishGame();
	}

	void BarSetup(){
		newBar = Instantiate(bar, transform.position, Quaternion.identity) as GameObject;
	}

}
