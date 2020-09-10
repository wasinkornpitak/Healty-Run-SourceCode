using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusScore : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, (transform.position.y + 5f * Time.deltaTime) ,transform.position.z);
		if(transform.position.y > 3.5){
			Destroy (gameObject);
		}
	}


}
