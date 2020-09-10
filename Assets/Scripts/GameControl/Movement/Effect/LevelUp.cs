using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, (transform.position.y + 4f * Time.deltaTime) ,transform.position.z);
		if(transform.position.y > 4){
			Destroy (gameObject);
		}
	}
}
