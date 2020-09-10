using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (SwitchScence());
	}
	
	// Update is called once per frame
	public IEnumerator SwitchScence(){
		yield return new WaitForSeconds (1f);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Login");
	}
}
