using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeItem : MonoBehaviour {

	public float objSpeed;
	Collider2D col;

	public AudioClip audio;

	// Use this for initialization
	void Start () {
		//objSpeed = (0.035f + GameControl.instance.speedLevel) * Time.deltaTime;
		objSpeed = (8f + GameControl.instance.speedLevel);
		col = GetComponent<Collider2D> ();
		col.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.tag == "Player" && PlayerConntroler.instance.hp > 0){

			Vector2 posPlusTime = new Vector2 (transform.position.x, transform.position.y);
			GameObject g = Instantiate (CreateItem.instance.plusTime , posPlusTime, Quaternion.identity);
			g.transform.SetParent (CreateItem.instance.tranformItemScore);
			GameControl.instance.countTime++;

			AudioSource.PlayClipAtPoint (audio,transform.position);
			Destroy (this.gameObject);

			if(gameObject.name == "Item_time(Clone)" && GameControl.instance.timeInGame <= 60){
				GameControl.instance.timeInGame += CreateItem.instance.addTime;
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
