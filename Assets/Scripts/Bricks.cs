using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	void OnCollisionEnter(){
		GM.instance.DestroyBrick();
		Destroy(gameObject);
	}
}
