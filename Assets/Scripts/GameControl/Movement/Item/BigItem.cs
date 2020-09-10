using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigItem : MonoBehaviour {

	public float objSpeed;
	Collider2D col;

	public AudioClip audio;

	// Use this for initialization
	void Start () {
		objSpeed = (8f  + GameControl.instance.speedLevel);
//		objSpeed = (-0.11f - GameControl.instance.speedLevel) * Time.deltaTime;
		col = GetComponent<Collider2D> ();
		col.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player" && PlayerConntroler.instance.hp > 0){

			Vector2 posPlus2Score = new Vector2 (transform.position.x, transform.position.y);
			GameObject g = Instantiate (CreateItem.instance.plus2Score , posPlus2Score, Quaternion.identity);
			g.transform.SetParent (CreateItem.instance.tranformItemScore);
			GameControl.instance.countBigItem++;

			AudioSource.PlayClipAtPoint (audio,transform.position);
			Destroy (this.gameObject);


			Text txtScore;
			txtScore = GameObject.Find ("Score/Canvas/TxtScore").GetComponent<Text>();
			GameControl.instance.nScore += CreateItem.instance.score;
			txtScore.text = "" + GameControl.instance.nScore;
//			GameControl.instance.CheckSpeedLevel ();
		}
	}

	void Update () {
		transform.Translate ((new Vector3(-1,0,0)) * objSpeed * Time.deltaTime);
		if(transform.position.x < -10){
			Destroy (gameObject);
		}
	}
}