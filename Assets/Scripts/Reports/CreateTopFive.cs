using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTopFive : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;

	void Start () {
		createTopFive ();
	}

	public void createTopFive(){
		
		for(int i = 0; i < LoadReport.instance.reportInGame.TopFive.Count; i++){
			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;

			g.transform.Find ("Number").GetComponent<Text>().text = (i+1).ToString();
			g.transform.Find ("Name").GetComponent<Text>().text = LoadReport.instance.reportInGame.TopFive[i].UserName;
			g.transform.Find ("Score").GetComponent<Text>().text = LoadReport.instance.reportInGame.TopFive[i].MaxScore.ToString();
		}
	}
}
