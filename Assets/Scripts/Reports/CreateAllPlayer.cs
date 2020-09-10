using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAllPlayer : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;

	void Start () {
		createAllPlayer ();
	}

	public void createAllPlayer(){

		for(int i = 0; i < LoadReport.instance.reportInGame.AllPlayer.Count; i++){
			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;

			g.transform.Find ("Number").GetComponent<Text>().text = (i+1).ToString();
			g.transform.Find ("Name").GetComponent<Text>().text = LoadReport.instance.reportInGame.AllPlayer[i].UserName;
			g.transform.Find ("Score").GetComponent<Text>().text = LoadReport.instance.reportInGame.AllPlayer[i].MaxScore.ToString();
		}
	}
}
