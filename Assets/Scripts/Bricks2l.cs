using UnityEngine;
using System.Collections;

public class Bricks2l : MonoBehaviour {

    public GameObject Brick;
    private GameObject newBrick;

    void OnCollisionEnter()
    {
        newBrick = Instantiate(Brick, transform.position, Quaternion.identity) as GameObject;
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}


