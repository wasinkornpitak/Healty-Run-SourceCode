using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTotalHistory : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;

	// Use this for initialization
	void Start () {
		createTotalHistory ();
	}

	public void createTotalHistory(){

		for(int i = 0; i < LoadReport.instance.reportInGame.TotalHistory.Count; i++){
			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;

			g.transform.Find ("Score").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumScore.ToString();
			g.transform.Find ("Fruit").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumMiniItem.ToString();
			g.transform.Find ("Vetgetable").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumBigItem.ToString();
			g.transform.Find ("Milk").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumMilk.ToString();
			g.transform.Find ("Time").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumTime.ToString();
			g.transform.Find ("Distance").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumDistance.ToString();
			g.transform.Find ("HP").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumHP.ToString();
			g.transform.Find ("Junkfood").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumHpEnemy.ToString();
			g.transform.Find ("Candy").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].sumScoreEnemy.ToString();
			g.transform.Find ("Plays").GetComponent<Text>().text = LoadReport.instance.reportInGame.TotalHistory[i].countScore.ToString();
		}
	}
}
