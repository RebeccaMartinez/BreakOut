using UnityEngine;
using System.Collections;

public class Bricks3l : MonoBehaviour {

    public GameObject greenBrick;
    private GameObject newBrick;

	void OnCollisionEnter(){
        newBrick = Instantiate(greenBrick, transform.position, Quaternion.identity) as GameObject;
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
