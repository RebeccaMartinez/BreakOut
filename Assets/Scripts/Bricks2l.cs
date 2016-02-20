using UnityEngine;
using System.Collections;

public class Bricks2l : MonoBehaviour {

    public GameObject blueBrick;
    private GameObject newBrick;

    void OnCollisionEnter()
    {
        newBrick = Instantiate(blueBrick, transform.position, Quaternion.identity) as GameObject;
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
