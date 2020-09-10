using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEnemy : MonoBehaviour {

	public float objSpeed ;
	Collider2D col;

	public AudioClip audio;

	// Use this for initialization
	void Start () {
		objSpeed = (3f + GameControl.instance.speedLevel);
//		objSpeed = (0.05f + GameControl.instance.speedLevel) * Time.deltaTime;
		col = GetComponent<Collider2D> ();
		col.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player" && PlayerConntroler.instance.hp > 0){
			AudioSource.PlayClipAtPoint (audio,transform.position);
			GameControl.instance.countScoreEnemy++;
			Destroy (this.gameObject);

			if(GameControl.instance.nScore > 0 && CreateItem.instance.protection == false){

				Vector2 posMinus1Score = new Vector2 (transform.position.x, transform.position.y);
				GameObject g = Instantiate (CreateItem.instance.minus1Score , posMinus1Score, Quaternion.identity);
				g.transform.SetParent (CreateItem.instance.tranformItemScore);

				Text txtScore;
				txtScore = GameObject.Find ("Score/Canvas/TxtScore").GetComponent<Text>();
				GameControl.instance.nScore -= CreateEnemy.instance.dmgScore;
				txtScore.text = "" + GameControl.instance.nScore;
			}else if(CreateItem.instance.protection == true){
				
				Vector2 posMinusProtection = new Vector2 (transform.position.x, transform.position.y);
				GameObject g = Instantiate (CreateItem.instance.minusProtection , posMinusProtection, Quaternion.identity);
				g.transform.SetParent (CreateItem.instance.tranformItemScore);

				CreateItem.instance.returnProtection ();
			}
		}
	}

	void Update () {
		transform.Translate ((new Vector3(1,0,0)) * objSpeed * Time.deltaTime);
		if(transform.position.x > 10){
			Destroy (gameObject);
		}
	}
}
