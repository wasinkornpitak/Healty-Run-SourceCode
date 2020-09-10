using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateHiScore : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;
	int number;

	// Use this for initialization
	void Start () {
		createHiScore ();
		number = 1;
	}

	// Update is called once per frame
	public void createHiScore(){
		
		for(int i = 0; i < LoadReport.instance.reportInGame.HiScore.Count; i++){
			for(int j = 0; j < LoadReport.instance.reportInGame.HiScore.Count; j++){
				if (LoadReport.instance.reportInGame.HiScore[i].DatePlay == LoadReport.instance.reportInGame.HiScore[j].DatePlay && i != j) {
					LoadReport.instance.reportInGame.HiScore[j].DatePlay = "";
				} 
			}
		}

		for(int i = 0; i < LoadReport.instance.reportInGame.HiScore.Count; i++){
			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;
			if (LoadReport.instance.reportInGame.HiScore [i].DatePlay == "") {
				number++;
			} else {
				number = 1;
			}
			g.transform.Find ("Date").GetComponent<Text> ().text = LoadReport.instance.reportInGame.HiScore [i].DatePlay.ToString ();
			g.transform.Find ("Number").GetComponent<Text> ().text = number.ToString ();
			g.transform.Find ("Name").GetComponent<Text> ().text = LoadReport.instance.reportInGame.HiScore [i].UserName.ToString ();
			g.transform.Find ("Plays").GetComponent<Text> ().text = LoadReport.instance.reportInGame.HiScore [i].MaxScore.ToString ();
		}
	}
}
