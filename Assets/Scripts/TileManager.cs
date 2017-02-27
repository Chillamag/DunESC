using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public GameObject currentTile;

    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    public Stack<GameObject> LeftTiles {
        get {return leftTiles;}
        set {leftTiles = value;}
    }

    private Stack<GameObject> rightTiles = new Stack<GameObject>();
    public Stack<GameObject> RightTiles {
        get {return rightTiles;}
        set {rightTiles = value;}
    }

    //Start singleton
    private static TileManager instance;
    public static TileManager Instance {
        get {

            if(instance == null) {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    } //End singleton

    // Use this for initialization
    void Start () {

        CreateTiles(20);

        for (int i = 0; i < 50; i++) {
            SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateTiles(int amount) {
        for(int i = 0; i < amount; i++) {
            LeftTiles.Push(Instantiate(tilePrefabs[0]));
            RightTiles.Push(Instantiate(tilePrefabs[1]));
            RightTiles.Peek().name = "RightTile";
            RightTiles.Peek().SetActive(false);
            LeftTiles.Peek().name = "LeftTile";
            LeftTiles.Peek().SetActive(false);
        }

    }


    public void SpawnTile() {

        if (LeftTiles.Count == 0 || RightTiles.Count == 0) {
            CreateTiles(1);
        }

        int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0) {
            GameObject temp = LeftTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = temp;
        }else if(randomIndex == 1){
            GameObject temp = RightTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = temp;
        }

        //currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
    }


}
