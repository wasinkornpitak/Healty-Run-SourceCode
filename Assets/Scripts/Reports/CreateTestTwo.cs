using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTestTwo : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;

	public static CreateTestTwo instance;

	int number;

	// Use this for initialization
	void Start () {
		instance = this;
		createTestTwo ();
	}
	
	public void createTestTwo(){
		if(LoadReportTestTwo.instance.reportTestTwo.TestTwo.Count == 0){
			print ("this name no data");
		}
		string currDate = "";
		string tempDate = "";

		int sumPlayer = 1;

		int totalPlayer = 0;
		int totalDate = 0;

		int[] tempScore = new int[1];
		int[] tempTotalScore = new int[1];

		number = 1;

		for(int i = 0; i < LoadReportTestTwo.instance.reportTestTwo.TestTwo.Count; i++){

			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;

			g.transform.Find ("Score").GetComponent<Text>().text = LoadReportTestTwo.instance.reportTestTwo.TestTwo[i].score.ToString();
			g.transform.Find ("Number").GetComponent<Text>().text = number.ToString();
			g.transform.Find ("Date").GetComponent<Text>().text = LoadReportTestTwo.instance.reportTestTwo.TestTwo[i].datePlay.ToString();
			g.transform.Find ("Name").GetComponent<Text>().text = LoadReportTestTwo.instance.reportTestTwo.TestTwo[i].UserName.ToString();

			tempScore[0] +=  LoadReportTestTwo.instance.reportTestTwo.TestTwo [i].score;
			tempTotalScore[0] +=  LoadReportTestTwo.instance.reportTestTwo.TestTwo [i].score;

			if ( LoadReportTestTwo.instance.reportTestTwo.TestTwo [i].datePlay == tempDate) {
				sumPlayer++;
				totalPlayer++;
				//print (LoadReportTestOne.instance.reportTestOne.TestOne [i].datePlay + " player + " + totalPlayer);
			}

			if (currDate !=  LoadReportTestTwo.instance.reportTestTwo.TestTwo [i].datePlay) {
				//print (LoadReportTestOne.instance.reportTestOne.TestOne [i].datePlay);
				currDate =  LoadReportTestTwo.instance.reportTestTwo.TestTwo [i].datePlay;
				totalDate++;
				totalPlayer++;
				sumPlayer = 1;

			} else {
				g.transform.Find ("Date").GetComponent<Text> ().text = "";

			}

			number++;
			tempDate =  LoadReportTestTwo.instance.reportTestTwo.TestTwo[i].datePlay.ToString();

			if(i ==  LoadReportTestTwo.instance.reportTestTwo.TestTwo.Count-1 ||  LoadReportTestTwo.instance.reportTestTwo.TestTwo[i].datePlay !=  LoadReportTestTwo.instance.reportTestTwo.TestTwo[i+1].datePlay){
				createSum (sumPlayer, tempScore);
				createLine ();
//				print ("createSum");
				tempScore = new int[7];
				number = 1;
				if(i ==  LoadReportTestTwo.instance.reportTestTwo.TestTwo.Count-1){
//					print ("create grand total");
					createTotal (totalPlayer, totalDate,tempTotalScore);
				}
			}
		}

		//Null
		if (LoadReportTestTwo.instance.reportTestTwo.TestTwo.Count == 0){
//			print ("no data");
			createTotal (totalPlayer, totalDate,tempTotalScore);
		}
	}

	void createSum(int sumPlayer, int[] tempScore){
		GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
		g.transform.SetParent (group);
		g.transform.localScale = Vector3.one;

		g.transform.Find ("Score").GetComponent<Text>().text = tempScore[0].ToString();
		g.transform.Find ("Number").GetComponent<Text>().text = "sum ";
		g.transform.Find ("Date").GetComponent<Text> ().text = "";
		g.transform.Find ("Name").GetComponent<Text>().text =  sumPlayer + " Player";
	}

	void createLine(){
		GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
		g.transform.SetParent (group);
		g.transform.localScale = Vector3.one;

		g.transform.Find ("Score").GetComponent<Text>().text = "----------";
		g.transform.Find ("Number").GetComponent<Text> ().text = "--------";
		g.transform.Find ("Date").GetComponent<Text> ().text = "--------------";
		g.transform.Find ("Name").GetComponent<Text>().text = "-------------";
	}

	void createTotal(int totalPlayer,int totalDate, int[] tempTotalScore){
		GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
		g.transform.SetParent (group);
		g.transform.localScale = Vector3.one;

		g.transform.Find ("Score").GetComponent<Text>().text = tempTotalScore[0].ToString();
		g.transform.Find ("Number").GetComponent<Text>().text = "";
		g.transform.Find ("Date").GetComponent<Text> ().text = "total " + totalDate + " Days";
		g.transform.Find ("Name").GetComponent<Text>().text = totalPlayer + " Player";
	}
}
