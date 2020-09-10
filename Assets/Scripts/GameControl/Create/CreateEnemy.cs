using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {

	public static CreateEnemy instance;

	public GameObject[] enemyHp;
	public GameObject[] enemyScore;

	public int dmgHp;
	public int dmgScore;
	public Transform tranformEnemyHp;
	public Transform tranformEnemyScore;

	void Start () {
		instance = this;
		StartCoroutine (createEnemyHp(1));
		StartCoroutine (createEnemyScore(1));
		dmgHp = 0;
	}
	
	public IEnumerator createEnemyHp(int countEnemy){
		
		while(!GameControl.instance.isGameOver){
			for(int i = 0; i < countEnemy; i++){
				yield return new WaitForSeconds (Random.Range(2.1f - (GameControl.instance.speedLevel / 4), 3.5f - (GameControl.instance.speedLevel / 2)));
				int randomEnemyHp = Random.Range (0, enemyHp.Length);

				if (randomEnemyHp < 2) {
					Vector2 posEnemyHp = new Vector2 (10f, -2.48f);
					GameObject enemyHpTranform = Instantiate (enemyHp [randomEnemyHp], posEnemyHp, Quaternion.identity);
					enemyHpTranform.transform.SetParent (tranformEnemyHp);
					dmgHp = LoadData.instance.dataInGame.Enemy[0].Dmg_enemy;
				} else {
					Vector2 posEnemyHp= new Vector2 (10f, -2.1f);
					GameObject enemyHpTranform = Instantiate (enemyHp [randomEnemyHp], posEnemyHp, Quaternion.identity);
					enemyHpTranform.transform.SetParent (tranformEnemyHp);
					dmgHp = LoadData.instance.dataInGame.Enemy[0].Dmg_enemy;
				}
			}
		}
	}

	public IEnumerator createEnemyScore(int countEnemy){

		while(!GameControl.instance.isGameOver){
			for(int i = 0; i < countEnemy; i++){
				yield return new WaitForSeconds (Random.Range(7.3f - (GameControl.instance.speedLevel / 4), 10.8f - (GameControl.instance.speedLevel / 2)));
				int randomEnemyScore = Random.Range (0, enemyScore.Length);

				Vector2 posEnemyScore = new Vector2 (-10f, -2.25f);
				GameObject enemyScoreTranform = Instantiate (enemyScore [randomEnemyScore], posEnemyScore, Quaternion.identity);
				enemyScoreTranform.transform.SetParent (tranformEnemyScore);
				dmgScore = LoadData.instance.dataInGame.Enemy[1].Dmg_enemy;
				
			}
		}
	}
}
