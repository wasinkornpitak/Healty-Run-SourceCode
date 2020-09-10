using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;

	public bool isGameOver;
	public float speedLevel;

	public string timeEndGame;

	public int nScore;
	public float nDistance;

	public int countHp;
	public int countMilk;
	public int countBigItem;
	public int countMiniItem;
	public int countScoreEnemy;
	public int countHpEnemy;
	public int countTime;

	public GameObject inGameScore;
	public GameObject txtscore;
	public GameObject reportEndGame;
	public GameObject txtLevel;
	public GameObject btnPause;
	public GameObject objLvUp;
	public GameObject Bg;
	public GameObject Ground;

	public Sprite bgGame;
	public Sprite groundGame;

	public float distance;
	public float timeInGame;

	public string Level;

	Text txtTime;
	Text txtLv;
	Text txtDistance;

	bool statusAddScore;

	void Start () {
		instance = this;
		isGameOver = false;
		nScore = 0;
		StartCoroutine (CreateItem.instance.createItemScore(1));
		StartCoroutine (CreateItem.instance.createItemPotection(1));
		StartCoroutine (CreateItem.instance.createItemTime (1));
		CheckSpeedLevel ();
		distance = 0;
		Level = "LV001";
		speedLevel = 0f * Time.deltaTime;
		timeInGame = 60;
		statusAddScore = false;


	}

	void Update(){
		nDistance = (distance+=1 * Time.deltaTime);
		txtDistance = GameObject.Find ("Score/Canvas/TxtDistance").GetComponent<Text>();
		txtDistance.text = nDistance.ToString ();

		timeInGame -= Time.deltaTime;
		txtTime = GameObject.Find ("Score/Canvas/TxtTime").GetComponent<Text>();
		txtTime.text = System.Math.Round (timeInGame, 2).ToString ();

		CheckSpeedLevel ();

		if(timeInGame <= 0){
			CheckGameover ();
		}
	
	}

	public void CheckSpeedLevel(){
		
		if (Level == LoadData.instance.dataInGame.Level[0].Id_level) {
				txtLv = GameObject.Find ("Score/Canvas/TxtLevel").GetComponent<Text>();
				txtLv.text = "Level:1";
			if(distance > LoadData.instance.dataInGame.Level[0].Distance_level){
				Level = LoadData.instance.dataInGame.Level[1].Id_level;
				CreateLevelUp ();
				StartCoroutine (PlusSpeed());
			}

		} else if (Level == LoadData.instance.dataInGame.Level[1].Id_level) {
				txtLv.text = "Level:2";
			if(distance > LoadData.instance.dataInGame.Level[1].Distance_level){
				Level = LoadData.instance.dataInGame.Level[2].Id_level;
				CreateLevelUp ();
				StartCoroutine (PlusSpeed());
			}

		} else if(Level == LoadData.instance.dataInGame.Level[2].Id_level){
			txtLv.text = "Level:3";
			StartCoroutine (SwitchBG());
			if(distance > LoadData.instance.dataInGame.Level[2].Distance_level){
				Level = LoadData.instance.dataInGame.Level[3].Id_level;
			CreateLevelUp ();
				StartCoroutine (PlusSpeed());
			}

		} else if(Level == LoadData.instance.dataInGame.Level[3].Id_level){
				txtLv.text = "Level:4";
			if(distance > LoadData.instance.dataInGame.Level[3].Distance_level){
				Level = LoadData.instance.dataInGame.Level[4].Id_level;
				CreateLevelUp ();
				StartCoroutine (PlusSpeed());
			}
		} else if(Level == LoadData.instance.dataInGame.Level[4].Id_level){
			txtLv.text = "Level:5";
			if(distance > LoadData.instance.dataInGame.Level[4].Distance_level){
				Level = LoadData.instance.dataInGame.Level[5].Id_level;
				CreateLevelUp ();
				StartCoroutine (PlusSpeed());
			}
		} 
	}

	public void CreateLevelUp(){
		Vector2 poslvUp = new Vector2 (0.53f, 1.7f);
		GameObject g = Instantiate (objLvUp , poslvUp, Quaternion.identity);
		g.transform.SetParent (CreateItem.instance.tranformItemScore);
	}

	public IEnumerator PlusSpeed(){
		yield return new WaitForSeconds (1f);
		speedLevel += 1;
	}

	public IEnumerator SwitchBG(){
		yield return new WaitForSeconds (1f);
		Bg.GetComponent<SpriteRenderer> ().sprite = bgGame;
		Bg.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = bgGame;
		Ground.GetComponent<SpriteRenderer> ().sprite = groundGame;
		Ground.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = groundGame;
	}

	public void CheckGameover(){
		if(PlayerConntroler.instance.hp <= 0 || timeInGame <= 0){
			isGameOver = true;
			StartCoroutine(GameOver ());

		}
	}

	public IEnumerator GameOver()
	{
		if(isGameOver){
			reportEndGame.gameObject.SetActive (true);
			inGameScore.gameObject.SetActive (false);
			txtscore.gameObject.SetActive(false);
			txtLevel.gameObject.SetActive (false);
			btnPause.gameObject.SetActive (false);

			Text txtScore;
			txtScore = GameObject.Find ("Score/Canvas/ReportEndGame/TxtScoreEndGame").GetComponent<Text>();
			txtScore.text = "" + nScore;
			Text txtDistance;
			txtDistance = GameObject.Find ("Score/Canvas/ReportEndGame/TxtDistanceEndGame").GetComponent<Text>();
			txtDistance.text = "" + nDistance;
			Text txtCountHp;
			txtCountHp = GameObject.Find ("Score/Canvas/ReportEndGame/TxtItem/ImgHp/TxtScoreHP").GetComponent<Text>();
			txtCountHp.text = "" + countHp;
			Text txtCountMilk;
			txtCountMilk = GameObject.Find ("Score/Canvas/ReportEndGame/TxtItem/ImgMilk/TxtScoreMilk").GetComponent<Text>();
			txtCountMilk.text = "" + countMilk;
			Text txtCountBigItem;
			txtCountBigItem = GameObject.Find ("Score/Canvas/ReportEndGame/TxtItem/Vegetable/TxtScoreVet").GetComponent<Text>();
			txtCountBigItem.text = "" + countBigItem;
			Text txtCountminiItem;
			txtCountminiItem = GameObject.Find ("Score/Canvas/ReportEndGame/TxtItem/Fruit/TxtScoreFruit").GetComponent<Text>();
			txtCountminiItem.text = "" + countMiniItem;
			Text txtCountTime;
			txtCountTime = GameObject.Find ("Score/Canvas/ReportEndGame/TxtItem/ImgTime/TxtScoreTime").GetComponent<Text>();
			txtCountTime.text = "" + countTime;
			Text txtCountHpEnemy;
			txtCountHpEnemy = GameObject.Find ("Score/Canvas/ReportEndGame/TxtEnemy/JunkFood/TxtScoreJunkFood").GetComponent<Text>();
			txtCountHpEnemy.text = "" + countHpEnemy;
			Text txtCountScoreEnemy;
			txtCountScoreEnemy = GameObject.Find ("Score/Canvas/ReportEndGame/TxtEnemy/Candy/TxtScoreCandy").GetComponent<Text>();
			txtCountScoreEnemy.text = "" + countScoreEnemy;

			yield return new WaitForSeconds (0.2f);
			Time.timeScale = 0;

			statusAddScore = true;
			addScore ();
		}

	}

	void addScore(){
		if(statusAddScore){
			timeEndGame = System.DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
			StartCoroutine (Connections.instance.UploadScore());
			print ("Player : " + Connections.instance.idPlayerInGame);
			print ("Score : " + nScore);
			Debug.Log("Date : " + timeEndGame);
			statusAddScore = false;
		}
	}
}
