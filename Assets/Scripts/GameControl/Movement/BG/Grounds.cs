using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : MonoBehaviour {

	public float groundSpeed;
	Vector3 startPOS;

	// Use this for initialization
	void Start () {

		groundSpeed = 2;
		startPOS = transform.position;
	}

	// Update is called once per frame
	void Update () {
		groundSpeed = 2f + (GameControl.instance.speedLevel + 1);

//		float newPos = Mathf.Repeat (Time.time * groundSpeed, 17.8f);
//		transform.position = startPOS + Vector3.left * newPos;
		transform.Translate ((new Vector3 (-1,0,0)) * groundSpeed * Time.deltaTime);
		if(transform.position.x < -17.78){
			transform.position = startPOS;
		}
	}
}
