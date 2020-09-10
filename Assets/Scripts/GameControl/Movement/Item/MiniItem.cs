using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniItem : MonoBehaviour {

	public float objSpeed;
	Collider2D col;

	public AudioClip audio;

	// Use this for initialization
	void Start () {
//		objSpeed = (-0.07f - GameControl.instance.speedLevel) * Time.deltaTime;
		objSpeed = (6f + GameControl.instance.speedLevel);
		col = GetComponent<Collider2D> ();
		col.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" && PlayerConntroler.instance.hp > 0) {

			Vector2 posPlus1Score = new Vector2 (transform.position.x, transform.position.y);
			GameObject g = Instantiate (CreateItem.instance.plus1Score , posPlus1Score, Quaternion.identity);
			g.transform.SetParent (CreateItem.instance.tranformItemScore);
			GameControl.instance.countMiniItem++;

			AudioSource.PlayClipAtPoint (audio,transform.position);

			Destroy (this.gameObject);

			Text txtScore;
			txtScore = GameObject.Find ("Score/Canvas/TxtScore").GetComponent<Text> ();
			GameControl.instance.nScore += CreateItem.instance.score;
			txtScore.text = "" + GameControl.instance.nScore;
//			GameControl.instance.CheckSpeedLevel ();
		} 
	}

	// Update is called once per frame
	void Update () {
		transform.Translate ((new Vector3(-1,0,0)) * objSpeed * Time.deltaTime);
		if(transform.position.x < -10){
			Destroy (gameObject);
		}
	}
}
