//Script taht controls the movement of the bar
using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

	//Variables
	public float barSpeed = 1f; //Velocidad de la barra
	private Vector3 playerPos = new Vector3(0, -12f, 0); //Posición inicial


	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * (barSpeed/2));
		//Limita el movimiento de la barra en el eje x (para que no se salga de las paredes) y actualiza la posición
		playerPos = new Vector3 (Mathf.Clamp (xPos, -18f, 18f), -12f, 0); 
		transform.position = playerPos;
	}
}
