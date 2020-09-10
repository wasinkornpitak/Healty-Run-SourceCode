using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpEnemy : MonoBehaviour {

	public float objSpeed;
	Collider2D col;

	public AudioClip audio;

	// Use this for initialization
	void Start () {
//		objSpeed = (-0.06f - GameControl.instance.speedLevel) * Time.deltaTime;
		objSpeed = (7f  + GameControl.instance.speedLevel);
		col = GetComponent<Collider2D> ();
		col.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Ground" && other.tag == "Player" && PlayerConntroler.instance.hp > 0) {

			AudioSource.PlayClipAtPoint (audio,transform.position);
			Destroy (this.gameObject);
			GameControl.instance.countHpEnemy++;

			if (CreateItem.instance.protection == false) {
				PlayerConntroler.instance.hp -= CreateEnemy.instance.dmgHp;

				Vector2 posMinusHp = new Vector2 (transform.position.x, transform.position.y);
				GameObject g = Instantiate (CreateItem.instance.minusHp , posMinusHp, Quaternion.identity);
				g.transform.SetParent (CreateItem.instance.tranformItemScore);

				if (PlayerConntroler.instance.hp3.gameObject.activeInHierarchy == true) {
					PlayerConntroler.instance.hp3.gameObject.SetActive (false);
				} else if (PlayerConntroler.instance.hp2.gameObject.activeInHierarchy == true) {
					PlayerConntroler.instance.hp2.gameObject.SetActive (false);
				} else {
					PlayerConntroler.instance.hp1.gameObject.SetActive (false);
				}
				GameControl.instance.CheckGameover ();
			} else {
				
				Vector2 posMinusProtection = new Vector2 (transform.position.x, transform.position.y);
				GameObject g = Instantiate (CreateItem.instance.minusProtection , posMinusProtection, Quaternion.identity);
				g.transform.SetParent (CreateItem.instance.tranformItemScore);

				CreateItem.instance.returnProtection ();
			}
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
