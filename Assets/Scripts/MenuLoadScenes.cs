//Load the corresponding level from the level menu
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuLoadScenes : MonoBehaviour {

	public void ClickPlay(){
		SceneManager.LoadScene("Level1"); 
	}

    public void ClickMP(){
        SceneManager.LoadScene("ModoPractica1");
    }
}
