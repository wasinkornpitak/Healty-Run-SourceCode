using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class ReportTestOne
{
	public List<TestOne> TestOne;
}

[System.Serializable]
public class TestOne
{
	public string datePlay;
	public string dates;
	public string dayPlay;
	public string UserName;
	public int sumScore;
	public int sumHP;
	public int sumMilk;
	public int sumMiniItem;
	public int sumBigItem;
	public int sumHpEnemy;
	public int sumScoreEnemy;
}

public class LoadReportTestOne : MonoBehaviour {

	public GameObject formatError;

	public static LoadReportTestOne instance;

	public InputField dateStart;
	public InputField dateEnd;

	public ReportTestOne reportTestOne;
	bool loadFirst;

	public Text txtError;

	// Use this for initialization
	void Start () {
		instance = this;
		loadFirst = true;
		StartCoroutine (loadReportsTestOne());
	}

	public string checkDateTrue(string myDateStart, string myDateEnd){
		string[] tempDateStart = myDateStart.Split ('/');
		string[] tempDateEnd = myDateEnd.Split ('/');

		if (tempDateStart.Length == 3 && tempDateEnd.Length == 3) {
			
			//Cheack Date Start
			if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 31) && int.Parse (tempDateStart [1]) == 1) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 29) && (int.Parse (tempDateStart [1]) == 2)) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 31) && int.Parse (tempDateStart [1]) == 3) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 30) && int.Parse (tempDateStart [1]) == 4) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 31) && int.Parse (tempDateStart [1]) == 5) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 30) && int.Parse (tempDateStart [1]) == 6) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 31) && int.Parse (tempDateStart [1]) == 7) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 3) && int.Parse (tempDateStart [1]) == 8) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 30) && int.Parse (tempDateStart [1]) == 9) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 31) && int.Parse (tempDateStart [1]) == 10) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 30) && int.Parse (tempDateStart [1]) == 11) {
				return "format error";
			} else if ((int.Parse (tempDateStart [0]) < 1 || int.Parse (tempDateStart [0]) > 31) && int.Parse (tempDateStart [1]) == 12) {
				return "format error";
			} 
			//Cheack Month Start
			if (int.Parse (tempDateStart [1]) < 1 || int.Parse (tempDateStart [1]) > 13) {
				return "format error";
			}
			//Cheack Year Start
			if(int.Parse (tempDateStart [2]) < 2017 || int.Parse (tempDateStart [2]) > 2019){
				return "format error";
			}

			//Cheack Date End
			if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 31) && int.Parse (tempDateEnd [1]) == 1) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 29) && int.Parse (tempDateEnd [1]) == 2) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 31) && int.Parse (tempDateEnd [1]) == 3) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 30) && int.Parse (tempDateEnd [1]) == 4) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 31) && int.Parse (tempDateEnd [1]) == 5) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 30) && int.Parse (tempDateEnd [1]) == 6) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 31) && int.Parse (tempDateEnd [1]) == 7) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 31) && int.Parse (tempDateEnd [1]) == 8) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 30) && int.Parse (tempDateEnd [1]) == 9) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 31) && int.Parse (tempDateEnd [1]) == 10) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 30) && int.Parse (tempDateEnd [1]) == 11) {
				return "format error";
			} else if ((int.Parse (tempDateEnd [0]) < 1 || int.Parse (tempDateEnd [0]) > 31) && int.Parse (tempDateEnd [1]) == 12) {
				return "format error";
			} 
			//Cheack Month Start
			if (int.Parse (tempDateEnd [1]) < 1 || int.Parse (tempDateEnd [1]) > 13) {
				return "format error";
			}
			//Cheack Year Start
			if(int.Parse (tempDateEnd [2]) < 2017 || int.Parse (tempDateEnd [2]) > 2019){
				return "format error";
			}
			return "true";
		} else {
			if(myDateStart == "" || myDateEnd == ""){
				return "Please enter date";
			}else{
				return "Please enter a valid date";
			}
		}
	}
	
	public IEnumerator loadReportsTestOne(){

		if (loadFirst || checkDateTrue (dateStart.text, dateEnd.text) == "true") {

			WWWForm form = new WWWForm ();

			if (!loadFirst) {
				string[] tempDateStart = dateStart.text.Split ('/');
				string[] tempDateEnd = dateEnd.text.Split ('/');
				string myDateStart = tempDateStart [2] + "/" + tempDateStart [1] + "/" + tempDateStart [0];
				string myDateEnd = tempDateEnd [2] + "/" + tempDateEnd [1] + "/" + tempDateEnd [0];
				
				form.AddField ("start", myDateStart);
				form.AddField ("end", myDateEnd);
			} else {
				form.AddField ("start", dateStart.text);
				form.AddField ("end", dateEnd.text);
				loadFirst = false;
			}
			
			WWW www = new WWW("http://127.0.0.1/HealtyRun/test1.php", form);
			
			yield return www;
			
			if (!www.isDone) {
				Debug.Log (www.error);
			} else {
				Debug.Log (www.text.Replace( "\\",""));
				reportTestOne = JsonUtility.FromJson <ReportTestOne> (www.text);
			}
		} else {
//			print ("formate date wrong");
			txtError.text = checkDateTrue (dateStart.text, dateEnd.text);
			formatError.gameObject.SetActive (true);
		}
	}
}
