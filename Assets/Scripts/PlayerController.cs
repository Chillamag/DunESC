using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Vector3 dir;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnim;

    public GameObject startToDelete;
    public GameObject curentTileToDelete;
    private bool startIsActive;

    public GameObject fire;

    private bool ground;
    private bool lava;
    public static bool dead;

    public GameObject canvas;

    // Use this for initialization
    void Start () {
        dir = Vector3.zero;
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myAnim = GetComponentInChildren<Animator>();
        myAnim.enabled = false;
        startIsActive = true;
        Time.timeScale = 1.0f;
        dead = false;
        canvas.SetActive(false);
        fire.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !dead) {
            if (startIsActive) {
                StartCoroutine(deleteStart());
            }
            myAnim.enabled = true;
            if (dir == Vector3.back) {
                mySpriteRenderer.flipX = true;
                dir = Vector3.right;
            }else {
                mySpriteRenderer.flipX = false;
                dir = Vector3.back;
            }
        }

        float amountToMove = speed * Time.deltaTime;

        transform.Translate(dir * amountToMove);

        if (!ground && lava) {
            //Debug.Log("Lava");
            Die();
        }

	}
    IEnumerator deleteStart() {
        yield return new WaitForSeconds(5);

        if (!dead) {
            startToDelete.SetActive(false);
            curentTileToDelete.SetActive(false);
            startIsActive = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Lava" && other.tag == "Ground") {
            //Debug.Log("Lava & Ground");
            //Die();
        }else if (other.tag == "Ground") {
            //Debug.Log("Ground");
            ground = true;
        }else {
            //Debug.Log("Lava");
            lava = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Lava") {
            lava = false;
        }else if (other.tag == "Ground") {
            ground = false;
        }
    }

    void Die() {
        StartCoroutine(drowning());
        //gameObject.transform.GetChild(0).gameObject.
        mySpriteRenderer.color = new Color32(255, 96, 96, 255);
        myAnim.enabled = false;
        //dir = Vector3.zero;
        //Time.timeScale = 1.0f;
        dead = true;
        canvas.SetActive(true);
        fire.SetActive(true);
    }

    IEnumerator drowning() {
        yield return new WaitForSeconds(0.1f);
        dir = Vector3.zero;
    }

}
