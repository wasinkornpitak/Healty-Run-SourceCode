using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Report
{
	public List<TopFive> TopFive;
	public List<History> History;
	public List<TotalHistory> TotalHistory;
	public List<PlayMost> PlayMost;
	public List<HiScore> HiScore;
	public List<AllPlayer> AllPlayer;
	public List<TopFiveDistance> TopFiveDistance;
//	public List<TestOne> TestOne;
}

[System.Serializable]
public class TopFive
{
	public int MaxScore;
	public string UserName;
}

[System.Serializable]
public class History
{
	public int Value_score;
	public int Count_hp;
	public int Count_milk;
	public int Count_miniItem;
	public int Count_bigItem;
	public int Count_time;
	public int Count_hpEnemy;
	public int Count_scoreEnemy;
	public string Date_score;
}

[System.Serializable]
public class TotalHistory
{
	public int countScore;
	public int sumScore;
	public int sumHP;
	public int sumMilk;
	public int sumMiniItem;
	public int sumBigItem;
	public int sumTime;
	public int sumDistance;
	public int sumHpEnemy;
	public string sumScoreEnemy;
}

[System.Serializable]
public class PlayMost
{
	public int CountScore;
	public string DatePlay;
	public int DayPlay;
	public string DateScore;
	public string UserName;

}

[System.Serializable]
public class HiScore
{
	public int MaxScore;
	public string DatePlay;
	public int DayPlay;
	public string DateScore;
	public string UserName;

}

[System.Serializable]
public class AllPlayer
{
	public int MaxScore;
	public string UserName;
}

[System.Serializable]
public class TopFiveDistance
{
	public int sumDistance;
	public string UserName;
}

//[System.Serializable]
//public class TestOne
//{
//	public string Date_score;
//	public string DateScore;
//	public string UserName;
//	public int Count_hp;
//	public int Count_milk;
//	public int Count_miniItem;
//	public int Count_bigItem;
//	public int Count_hpEnemy;
//	public int Count_scoreEnemy;
//	public int Value_score;
//}


public class LoadReport : MonoBehaviour {

	public static LoadReport instance;

	void Start () {
		instance = this;
		StartCoroutine (loadReports());
	}

	public Report reportInGame;
	
	public IEnumerator loadReports(){

		WWWForm form = new WWWForm ();

		form.AddField ("Id", Connections.instance.idPlayerInGame);

		WWW www = new WWW("http://127.0.0.1/HealtyRun/LoadReport.php", form);

		yield return www;

		if (!www.isDone) {
			Debug.Log (www.error);
		} else {
			Debug.Log (www.text.Replace( "\\",""));
			reportInGame = JsonUtility.FromJson <Report> (www.text);
		}
	}
}
