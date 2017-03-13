using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    private float fallDelay = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            TileManager.Instance.SpawnTile();
            StartCoroutine(FallDown());
            Debug.Log("Spawn");
        }
    }

    IEnumerator FallDown() {
        yield return new WaitForSeconds(fallDelay);
        //GetComponent<Rigidbody>().isKinematic = false;

        if (!PlayerController.dead) {
            switch (gameObject.name) {

                case "Tile_1":
                    TileManager.Instance.Tile_1_Tiles.Push(gameObject);
                    //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.SetActive(false);
                    break;

                case "Tile_2":
                    TileManager.Instance.Tile_2_Tiles.Push(gameObject);
                    //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.SetActive(false);
                    break;

                case "Tile_3":
                    TileManager.Instance.Tile_3_Tiles.Push(gameObject);
                    //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
