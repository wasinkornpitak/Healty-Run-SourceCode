using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player instance;

	public GameObject boy;
	public GameObject girl;

	// Use this for initialization
	void Start () {

		instance = this;

		if (CharacterSelect.instance.strPlayer == "Boy") {
			boy.gameObject.SetActive (true);
		} else {
			girl.gameObject.SetActive (true);
		} 


	}
}
