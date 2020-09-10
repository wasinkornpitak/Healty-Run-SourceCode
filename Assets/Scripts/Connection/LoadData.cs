using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Data
{
	public List<Item> Item;
	public List<Enemy> Enemy;
	public List<Level> Level;
}

[System.Serializable]
public class Item
{
	public string Id_item;
	public string Name_item;
	public int Unit_item;
	public string Detail_item;
}

[System.Serializable]
public class Enemy
{
	public string Id_enemy;
	public string Name_enemy;
	public int Dmg_enemy;
	public string Detail_enemy;
}

[System.Serializable]
public class Level
{
	public string Id_level;
	public string Speed_level;
	public int Distance_level;
	public string Detail_level;
}

public class LoadData : MonoBehaviour {

	public static LoadData instance;

	public void Start(){
		instance = this;
		DontDestroyOnLoad (this.gameObject);
		StartCoroutine (loadData());
	}

	public Data dataInGame;

	public IEnumerator loadData(){

		WWWForm form = new WWWForm ();

		WWW www = new WWW("http://127.0.0.1/HealtyRun/LoadData.php", form);

		yield return www;

		if (!www.isDone) {
			Debug.Log (www.error);
		} else {
			Debug.Log (www.text.Replace( "\\",""));
			dataInGame = JsonUtility.FromJson <Data> (www.text);
		}
	}
}
