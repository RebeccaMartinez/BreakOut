//Load de level menu when we click "Niveles"
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClickLM : MonoBehaviour {
	public void LoadScene(){
		SceneManager.LoadScene("Levels"); 
	}
}
