using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectionItem : MonoBehaviour {

	public float objSpeed;
	Collider2D col;
	bool plusScore;

	public AudioClip audio;

	// Use this for initialization
	void Start () {

//		objSpeed = (0.035f + GameControl.instance.speedLevel) * Time.deltaTime;
		objSpeed = (3f + GameControl.instance.speedLevel);
		col = GetComponent<Collider2D> ();
		col.isTrigger = true;
		plusScore = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player" && PlayerConntroler.instance.hp > 0){
			AudioSource.PlayClipAtPoint (audio,transform.position);
			Destroy (this.gameObject);

			if (gameObject.name == "Item_milk(Clone)" && CreateItem.instance.countProtec < 3) {
				Vector2 posPlusProtection = new Vector2 (transform.position.x, transform.position.y);
				GameObject g = Instantiate (CreateItem.instance.plusProtection, posPlusProtection, Quaternion.identity);
				g.transform.SetParent (CreateItem.instance.tranformItemScore);
				plusScore = false;
				CreateItem.instance.protection = true;
				CreateItem.instance.countProtec = 3;
				GameControl.instance.countMilk++;
				PlayerConntroler.instance.milk1.gameObject.SetActive (true);
				PlayerConntroler.instance.milk2.gameObject.SetActive (true);
				PlayerConntroler.instance.milk3.gameObject.SetActive (true);

				waitProTection ();

			} 
			if(gameObject.name == "Item_hp(Clone)" && PlayerConntroler.instance.hp < 3){
				Vector2 posPlusHp = new Vector2 (transform.position.x, transform.position.y);
				GameObject g = Instantiate (CreateItem.instance.plusHp , posPlusHp, Quaternion.identity);
				g.transform.SetParent (CreateItem.instance.tranformItemScore);
				GameControl.instance.countHp++;
				PlayerConntroler.instance.hp += CreateItem.instance.addHp;
				plusScore = false;
				if (PlayerConntroler.instance.hp3.gameObject.activeInHierarchy == false && PlayerConntroler.instance.hp2.gameObject.activeInHierarchy == true) {
					PlayerConntroler.instance.hp3.gameObject.SetActive (true);
				} else if((PlayerConntroler.instance.hp3.gameObject.activeInHierarchy == false && (PlayerConntroler.instance.hp2.gameObject.activeInHierarchy == false))){
					PlayerConntroler.instance.hp2.gameObject.SetActive (true);
				}
			}

			if(plusScore){
				Vector2 posPlus2Score = new Vector2 (transform.position.x, transform.position.y);
				GameObject g = Instantiate (CreateItem.instance.plus2Score , posPlus2Score, Quaternion.identity);
				g.transform.SetParent (CreateItem.instance.tranformItemScore);
				if(gameObject.name == "Item_hp(Clone)"){
					GameControl.instance.countHp++;
				}else if(gameObject.name == "Item_milk(Clone)"){
					GameControl.instance.countMilk++;
				}

				Text txtScore;
				txtScore = GameObject.Find ("Score/Canvas/TxtScore").GetComponent<Text>();
				GameControl.instance.nScore += CreateItem.instance.score;
				txtScore.text = "" + GameControl.instance.nScore;
				plusScore = true;
			}
		}
	}

	public void waitProTection(){
		if (CharacterSelect.instance.strPlayer == "Boy") {
			Player.instance.boy.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 1f);
		} else {
			Player.instance.girl.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ((new Vector3(1,0,0)) * objSpeed * Time.deltaTime);
		if(transform.position.x > 10){
			Destroy (gameObject);
		}
	}
}
