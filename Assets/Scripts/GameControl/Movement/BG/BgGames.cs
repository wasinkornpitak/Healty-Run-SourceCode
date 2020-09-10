using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgGames : MonoBehaviour {

	public float bgSpeed;
	Vector3 startPOS;

	// Use this for initialization
	void Start () {
		bgSpeed = 1;
		startPOS = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		bgSpeed = (1f + GameControl.instance.speedLevel);

//		float newPos = Mathf.Repeat (Time.time * bgSpeed, 17.8f);
//		transform.position = startPOS + Vector3.left * newPos;
		transform.Translate ((new Vector3 (-1,0,0)) * bgSpeed * Time.deltaTime);
		if(transform.position.x < -17.78){
			transform.position = startPOS;
		}
	}
}
