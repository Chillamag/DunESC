using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Vector3 dir; 

	// Use this for initialization
	void Start () {
        dir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if(dir == Vector3.back) {
                dir = Vector3.right;
            }else {
                dir = Vector3.back;
            }
        }

        float amountToMove = speed * Time.deltaTime;

        transform.Translate(dir * amountToMove);

	}
}
