using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class FinishButtons : MonoBehaviour {

	public void ClickKeyboard(){
		SceneManager.LoadScene("Keyboard"); 
	}

	public void ClickBackToMenu(){
		SceneManager.LoadScene("MainMenu"); 
	}
}
