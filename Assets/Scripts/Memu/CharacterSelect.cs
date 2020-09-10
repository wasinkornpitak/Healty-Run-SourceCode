using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

	public GameObject selectBoy;
	public GameObject selectGirl;

	public string strPlayer;

	public static CharacterSelect instance;


	// Use this for initialization
	void Start () {
		instance = this;
		strPlayer = "Boy";
	}
	
	public void SelectBoy(){
		selectBoy.gameObject.SetActive (true);
		selectGirl.gameObject.SetActive (false);
		strPlayer = "Boy";
		Debug.Log (strPlayer);
	}

	public void SelectGirl(){
		selectBoy.gameObject.SetActive (false);
		selectGirl.gameObject.SetActive (true);
		strPlayer = "Girl";
		Debug.Log (strPlayer);
	}
}
