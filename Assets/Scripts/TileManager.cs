using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public GameObject currentTile;

    private Stack<GameObject> tile_1_Tiles = new Stack<GameObject>();
    public Stack<GameObject> Tile_1_Tiles {
        get {return tile_1_Tiles;}
        set {tile_1_Tiles = value;}
    }

    private Stack<GameObject> tile_2_Tiles = new Stack<GameObject>();
    public Stack<GameObject> Tile_2_Tiles {
        get { return tile_2_Tiles; }
        set { tile_2_Tiles = value; }
    }

    private Stack<GameObject> tile_3_Tiles = new Stack<GameObject>();
    public Stack<GameObject> Tile_3_Tiles {
        get { return tile_3_Tiles; }
        set { tile_3_Tiles = value; }
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

        CreateTiles(3);

        for (int i = 0; i < 3; i++) {
            SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateTiles(int amount) {
        for(int i = 0; i < amount; i++) {
            Tile_1_Tiles.Push(Instantiate(tilePrefabs[0]));
            Tile_1_Tiles.Peek().name = "Tile_1";
            Debug.Log("Tile 1");
            Tile_1_Tiles.Peek().SetActive(false);

            Tile_2_Tiles.Push(Instantiate(tilePrefabs[1]));
            Tile_2_Tiles.Peek().name = "Tile_2";
            Debug.Log("Tile 2");
            Tile_2_Tiles.Peek().SetActive(false);

            Tile_3_Tiles.Push(Instantiate(tilePrefabs[2]));
            Tile_3_Tiles.Peek().name = "Tile_3";
            Debug.Log("Tile 3");
            Tile_3_Tiles.Peek().SetActive(false);
            
            
        }

    }


    public void SpawnTile() {

        if (Tile_1_Tiles.Count == 0 || Tile_2_Tiles.Count == 0  || Tile_3_Tiles.Count == 0) {
            Debug.Log("Create 3");
            CreateTiles(1);
            
        }

        int randomIndex = Random.Range(0, 3);
        //int randomIndex = Random.Range(0, 1);

        if (randomIndex == 0) {
            GameObject temp = Tile_1_Tiles.Pop();
            temp.SetActive(true);
            //temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(0).position;
            currentTile = temp;

        }else if(randomIndex == 1){
            GameObject temp = Tile_2_Tiles.Pop();
            temp.SetActive(true);
            //temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(0).position;
            currentTile = temp;

        } else if (randomIndex == 2) {
            GameObject temp = Tile_3_Tiles.Pop();
            temp.SetActive(true);
            //temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(0).position;
            currentTile = temp;
        }

        //currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
    }


}
