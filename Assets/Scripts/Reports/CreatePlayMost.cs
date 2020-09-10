using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayMost : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;
	int number;

	void Start () {
		createPlayMost ();
		number = 1;
	}

	public void createPlayMost(){

		for(int i = 0; i < LoadReport.instance.reportInGame.PlayMost.Count; i++){
			for(int j = 0; j < LoadReport.instance.reportInGame.PlayMost.Count; j++){
				if (LoadReport.instance.reportInGame.PlayMost [i].DatePlay == LoadReport.instance.reportInGame.PlayMost [j].DatePlay && i != j) {
					LoadReport.instance.reportInGame.PlayMost [j].DatePlay = "";
				} 
			}
		}

		for(int i = 0; i < LoadReport.instance.reportInGame.PlayMost.Count; i++){
			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;
			if (LoadReport.instance.reportInGame.PlayMost [i].DatePlay == "") {
				number++;
			} else {
				number = 1;
			}
			g.transform.Find ("Date").GetComponent<Text> ().text = LoadReport.instance.reportInGame.PlayMost [i].DatePlay.ToString ();
			g.transform.Find ("Number").GetComponent<Text> ().text = number.ToString ();
			g.transform.Find ("Name").GetComponent<Text> ().text = LoadReport.instance.reportInGame.PlayMost [i].UserName.ToString ();
			g.transform.Find ("Plays").GetComponent<Text> ().text = LoadReport.instance.reportInGame.PlayMost [i].CountScore.ToString ();
		}
	}
}