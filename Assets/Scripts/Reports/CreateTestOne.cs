using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTestOne : MonoBehaviour {

	public GameObject PlayerScoreEntry;
	public Transform group;

	public static CreateTestOne instance;

	// Use this for initialization
	void Start () {
		instance = this;
		createTestOne ();
	}

	public void createTestOne(){

		string currDate = "";
		string tempDate = "";

		int sumPlayer = 1;

		int totalPlayer = 0;
		int totalDate = 0;

		int[] tempScore = new int[7];
		int[] tempTotalScore = new int[7];

		for(int i = 0; i < LoadReportTestOne.instance.reportTestOne.TestOne.Count; i++){

			GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
			g.transform.SetParent (group);
			g.transform.localScale = Vector3.one;
			
			g.transform.Find ("Score").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].sumScore.ToString();
			g.transform.Find ("fruit").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].sumMiniItem.ToString();
			g.transform.Find ("Vetgetable").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].sumBigItem.ToString();
			g.transform.Find ("Milk").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].sumMilk.ToString();
			g.transform.Find ("HP").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].sumHP.ToString();
			g.transform.Find ("JunkFood").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].sumHpEnemy.ToString();
			g.transform.Find ("Candy").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].sumScoreEnemy.ToString();
			g.transform.Find ("Date").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].datePlay.ToString();
			g.transform.Find ("Name").GetComponent<Text>().text = LoadReportTestOne.instance.reportTestOne.TestOne[i].UserName.ToString();

			tempScore[0] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumScore;
			tempScore[1] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumMiniItem;
			tempScore[2] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumBigItem;
			tempScore[3] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumMilk;
			tempScore[4] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumHP;
			tempScore[5] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumHpEnemy;
			tempScore[6] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumScoreEnemy;

			tempTotalScore[0] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumScore;
			tempTotalScore[1] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumMiniItem;
			tempTotalScore[2] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumBigItem;
			tempTotalScore[3] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumMilk;
			tempTotalScore[4] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumHP;
			tempTotalScore[5] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumHpEnemy;
			tempTotalScore[6] += LoadReportTestOne.instance.reportTestOne.TestOne [i].sumScoreEnemy;

			if (LoadReportTestOne.instance.reportTestOne.TestOne [i].datePlay == tempDate) {
				sumPlayer++;
				totalPlayer++;
//				print (LoadReportTestOne.instance.reportTestOne.TestOne [i].datePlay + " player + " + totalPlayer);
			}
				
			if (currDate != LoadReportTestOne.instance.reportTestOne.TestOne [i].datePlay) {
//				print (LoadReportTestOne.instance.reportTestOne.TestOne [i].datePlay);
				currDate = LoadReportTestOne.instance.reportTestOne.TestOne [i].datePlay;
				totalDate++;
				totalPlayer++;
				sumPlayer = 1;
			} else {
				g.transform.Find ("Date").GetComponent<Text> ().text = "";
			}
				
			tempDate = LoadReportTestOne.instance.reportTestOne.TestOne[i].datePlay.ToString();

			if(i == LoadReportTestOne.instance.reportTestOne.TestOne.Count-1 || LoadReportTestOne.instance.reportTestOne.TestOne[i].datePlay != LoadReportTestOne.instance.reportTestOne.TestOne[i+1].datePlay){
				createSum (sumPlayer, tempScore);
				createLine ();
//				print ("createSum");
				tempScore = new int[7];
				if(i == LoadReportTestOne.instance.reportTestOne.TestOne.Count-1){
//					print ("create grand total");
					createTotal (totalPlayer, totalDate,tempTotalScore);
				}
			}
		}

		//Null
		if (LoadReportTestOne.instance.reportTestOne.TestOne.Count == 0){
//			print ("no data");
			createTotal (totalPlayer, totalDate,tempTotalScore);
		}
	}

	void createSum(int sumPlayer, int[] tempScore){
		GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
		g.transform.SetParent (group);
		g.transform.localScale = Vector3.one;

		g.transform.Find ("Score").GetComponent<Text>().text = tempScore[0].ToString();
		g.transform.Find ("fruit").GetComponent<Text>().text =  tempScore[1].ToString();
		g.transform.Find ("Vetgetable").GetComponent<Text>().text =  tempScore[2].ToString();
		g.transform.Find ("Milk").GetComponent<Text>().text =  tempScore[3].ToString();
		g.transform.Find ("HP").GetComponent<Text>().text =  tempScore[4].ToString();
		g.transform.Find ("JunkFood").GetComponent<Text>().text =  tempScore[5].ToString();
		g.transform.Find ("Candy").GetComponent<Text>().text =  tempScore[6].ToString();
		g.transform.Find ("Date").GetComponent<Text> ().text = "";
		g.transform.Find ("Name").GetComponent<Text>().text = "sum " + sumPlayer + " Player";
	}

	void createLine(){
		GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
		g.transform.SetParent (group);
		g.transform.localScale = Vector3.one;

		g.transform.Find ("Score").GetComponent<Text>().text = "----------";
		g.transform.Find ("fruit").GetComponent<Text>().text =  "------";
		g.transform.Find ("Vetgetable").GetComponent<Text>().text =  "------";
		g.transform.Find ("Milk").GetComponent<Text>().text =  "------";
		g.transform.Find ("HP").GetComponent<Text>().text =  "------";
		g.transform.Find ("JunkFood").GetComponent<Text>().text =  "------";
		g.transform.Find ("Candy").GetComponent<Text>().text =  "------";
		g.transform.Find ("Date").GetComponent<Text> ().text = "-----------";
		g.transform.Find ("Name").GetComponent<Text>().text = "---------------";
	}

	void createTotal(int totalPlayer,int totalDate, int[] tempTotalScore){
		GameObject g = Instantiate (PlayerScoreEntry) as GameObject;
		g.transform.SetParent (group);
		g.transform.localScale = Vector3.one;

		g.transform.Find ("Score").GetComponent<Text>().text = tempTotalScore[0].ToString();
		g.transform.Find ("fruit").GetComponent<Text>().text =  tempTotalScore[1].ToString();
		g.transform.Find ("Vetgetable").GetComponent<Text>().text =  tempTotalScore[2].ToString();
		g.transform.Find ("Milk").GetComponent<Text>().text =  tempTotalScore[3].ToString();
		g.transform.Find ("HP").GetComponent<Text>().text =  tempTotalScore[4].ToString();
		g.transform.Find ("JunkFood").GetComponent<Text>().text =  tempTotalScore[5].ToString();
		g.transform.Find ("Candy").GetComponent<Text>().text =  tempTotalScore[6].ToString();
		g.transform.Find ("Date").GetComponent<Text> ().text = "total " + totalDate + " Days";
		g.transform.Find ("Name").GetComponent<Text>().text = totalPlayer + " Player";
	}
}
