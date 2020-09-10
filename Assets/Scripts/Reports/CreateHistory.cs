using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateHistory : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;

	// Use this for initialization
	void Start () {
		createHistory ();
	}
	
	public void createHistory(){

		for(int i = 0; i < LoadReport.instance.reportInGame.History.Count; i++){
			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;

			g.transform.Find ("Score").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Value_score.ToString();
			g.transform.Find ("fruit").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Count_miniItem.ToString();
			g.transform.Find ("Vetgetable").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Count_bigItem.ToString();
			g.transform.Find ("Milk").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Count_milk.ToString();
			g.transform.Find ("Time").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Count_time.ToString();
			g.transform.Find ("HP").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Count_hp.ToString();
			g.transform.Find ("JunkFood").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Count_hpEnemy.ToString();
			g.transform.Find ("Candy").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Count_scoreEnemy.ToString();
			g.transform.Find ("Date").GetComponent<Text>().text = LoadReport.instance.reportInGame.History[i].Date_score.ToString();
		}
	}
}
