using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConntroler : MonoBehaviour {

	public static PlayerConntroler instance;

	public GameObject hp1;
	public GameObject hp2;
	public GameObject hp3;

	public GameObject milk1;
	public GameObject milk2;
	public GameObject milk3;

	public int jump;

	public Animator anim;
	Rigidbody2D rb;

	public int hp;

	// Use this for initialization
	void Awake () {
		instance = this;
		hp = 3;
		jump = 0;
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameControl.instance.isGameOver){
			if(Input.GetKeyDown(KeyCode.Space) && jump < 2 ){
				jump++;
				anim.SetBool ("Jump", true);
				rb.velocity = new Vector2 (rb.velocity.x, 5f);
			}
		}
		if(hp <= 0 || GameControl.instance.timeInGame <= 0){
			anim.SetBool ("Dead", true);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		anim.SetBool ("Jump", false);
		jump = 0;
	}
}
