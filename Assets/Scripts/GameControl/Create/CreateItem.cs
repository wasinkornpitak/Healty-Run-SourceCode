using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour {

	public static CreateItem instance;

	public GameObject[] itemScore;
	public GameObject[] itemProtection;
	public GameObject itemTime;

	float[] posY = new float[]{1f, 0.25f, -0.25f, -1};
	float[] posYpro = new float[]{0f, 0.1f};
	public int addHp;
	public int addTime;
	public int score;
	public bool protection;
	public Transform tranformItemScore;
	public Transform tranformItemPro;
	public int countProtec;

	public GameObject plus1Score;
	public GameObject plus2Score;
	public GameObject minus1Score;
	public GameObject minusHp;
	public GameObject plusHp;
	public GameObject plusProtection;
	public GameObject minusProtection;
	public GameObject plusTime;

	// Use this for initialization
	void Start () {
		instance = this;
		score = 0;
		addHp = 0;
		protection = false;
		countProtec = 0;
	}

	public IEnumerator createItemScore(int countItem){
		while(!GameControl.instance.isGameOver){
			for(int i = 0; i < countItem; i++){
				int randomY = Random.Range (0, posY.Length);
				int randomItemScore = Random.Range (0, itemScore.Length);
				if (randomItemScore <= 3) {
					yield return new WaitForSeconds (Random.Range(1.8f - (GameControl.instance.speedLevel / 4), 5.1f - (GameControl.instance.speedLevel / 2)));
					Vector2 posItemScoreRandom = new Vector2 (10, posY [randomY]);
					GameObject itemScoreTranform = Instantiate (itemScore [randomItemScore], posItemScoreRandom, Quaternion.identity);
					itemScoreTranform.transform.SetParent (tranformItemScore);
					score = LoadData.instance.dataInGame.Item[2].Unit_item;
				} else {
					yield return new WaitForSeconds (Random.Range(2.5f - (GameControl.instance.speedLevel / 4), 8.5f - (GameControl.instance.speedLevel / 2)));
					Vector2 posItemScoreRandom = new Vector2 (10, posY[randomY]);
					GameObject itemScoreTranform = Instantiate (itemScore[randomItemScore],posItemScoreRandom,Quaternion.identity);
					itemScoreTranform.transform.SetParent (tranformItemScore);
					score = LoadData.instance.dataInGame.Item[3].Unit_item;
				}
			}
		}
	}

	public IEnumerator createItemPotection (int countItem){
		while(!GameControl.instance.isGameOver){
			yield return new WaitForSeconds (Random.Range((15f - GameControl.instance.speedLevel / 4), (25f - GameControl.instance.speedLevel / 2)));
			for(int i = 0; i < countItem; i++){
				int randomYpro = Random.Range (0, posYpro.Length);
				int randomItemProtection = Random.Range (0, itemProtection.Length);
				if (randomItemProtection == 0) {
					yield return new WaitForSeconds (Random.Range(20f, 25f));
					Vector2 posItemProtectionRamdom = new Vector2 (-10, posYpro [randomYpro]);
					GameObject itemProTranform = Instantiate (itemProtection [randomItemProtection], posItemProtectionRamdom, Quaternion.identity);
					itemProTranform.transform.SetParent (tranformItemPro);
					addHp = LoadData.instance.dataInGame.Item[1].Unit_item;
				} else {
					yield return new WaitForSeconds (Random.Range((15f), 20f));
					addHp = LoadData.instance.dataInGame.Item[0].Unit_item;
					Vector2 posItemProtectionRamdom = new Vector2 (-10, posYpro [randomYpro]);
					GameObject itemProTranform = Instantiate (itemProtection [randomItemProtection], posItemProtectionRamdom, Quaternion.identity);
					itemProTranform.transform.SetParent (tranformItemPro);
				}
			}
		}
	}

	public IEnumerator createItemTime (int countItem){
		while(!GameControl.instance.isGameOver){
			
			yield return new WaitForSeconds (Random.Range(15f, 20f));

			int randomYTime = Random.Range (0, posY.Length);
			Vector2 posItemTimeRamdom = new Vector2 (10, posY [randomYTime]);
			GameObject itemTimeTranform = Instantiate (itemTime , posItemTimeRamdom, Quaternion.identity);
			itemTimeTranform.transform.SetParent (tranformItemPro);

			addTime = LoadData.instance.dataInGame.Item[4].Unit_item;


		}
	}

	public void returnProtection(){
		countProtec--;
		if (PlayerConntroler.instance.milk1.gameObject.activeInHierarchy == true) {
			PlayerConntroler.instance.milk1.gameObject.SetActive (false);
		} else if (PlayerConntroler.instance.milk2.gameObject.activeInHierarchy == true) {
			PlayerConntroler.instance.milk2.gameObject.SetActive (false);
		} else {
			PlayerConntroler.instance.milk3.gameObject.SetActive (false);
		}
		if(countProtec <= 0){
			protection = false;
			countProtec = 0;
			if (CharacterSelect.instance.strPlayer == "Boy") {
				Player.instance.boy.GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 1f);
			} else {
				Player.instance.girl.GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 1f);
			}
		}
	}
}
