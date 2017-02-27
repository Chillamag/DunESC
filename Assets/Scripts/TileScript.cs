using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    private float fallDelay = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            TileManager.Instance.SpawnTile();
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown() {
        yield return new WaitForSeconds(fallDelay);
        //GetComponent<Rigidbody>().isKinematic = false;


        switch (gameObject.name) {

            case "LeftTile":
                TileManager.Instance.LeftTiles.Push(gameObject);
                //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "RightTile":
                TileManager.Instance.RightTiles.Push(gameObject);
                //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }
    }
}
