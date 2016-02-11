//Load the corresponding level from the level menu
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadOnClickLevels : MonoBehaviour {

	public void LoadScene(int l){
		string level = string.Concat ("Level", l);
		SceneManager.LoadScene(level); 
	}
}
