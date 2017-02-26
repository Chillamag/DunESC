using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Vector3 dir;
    private SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    void Start () {
        dir = Vector3.zero;
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if(dir == Vector3.back) {
                mySpriteRenderer.flipX = true;
                dir = Vector3.right;
            }else {
                mySpriteRenderer.flipX = false;
                dir = Vector3.back;
            }
        }

        float amountToMove = speed * Time.deltaTime;

        transform.Translate(dir * amountToMove);

	}
}
