using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Connections : MonoBehaviour {

	public static Connections instance;

	public InputField Id;
	public InputField Password;
	public InputField ConfirmPassword;

	public string idPlayerInGame;

	public GameObject txtEnter;

	public void Start(){
		instance = this;
	}

	public IEnumerator Login(){

		Text txtenter = txtEnter.GetComponent<Text> ();

		if (Id.text != "") {
			if (Password.text != "") {
				
				WWWForm form = new WWWForm ();

				form.AddField ("Id", Id.text);
				form.AddField ("Password", Password.text);

				WWW www = new WWW("http://127.0.0.1/HealtyRun/Login.php", form);

				yield return www;

				if (!www.isDone) {
					Debug.Log (www.error);
				} else {
					idPlayerInGame = www.text;
					Debug.Log (idPlayerInGame);
				}

				if (www.text == "falseId") {
					txtenter.color = Color.red;
					txtenter.text = "No user please register";
				}else if(www.text == "falsePass"){
					txtenter.color = Color.red;
					txtenter.text = "Invalid Password";
				} else {
					txtenter.color = Color.green;
					txtenter.text = "Login complete.";
					yield return new WaitForSeconds(1);
					UnityEngine.SceneManagement.SceneManager.LoadScene ("Menu");
				}

			} else {
				txtenter.color = Color.red;
				txtenter.text = "Please enter Password";
			}
		} else {
			txtenter.color = Color.red;
			txtenter.text = "Please enter ID";
		}
	}

	public IEnumerator Register(){

		Text txtenter = txtEnter.GetComponent<Text> ();

		if (Id.text != "" && Id.text.Length >= 5) {
			if (Password.text != "" && Password.text.Length >= 5) {
				if(Password.text == ConfirmPassword.text){

					WWWForm form = new WWWForm ();

					form.AddField ("Id", Id.text);
					form.AddField ("Password", Password.text);

					WWW www = new WWW("http://127.0.0.1/HealtyRun/Register.php", form);

					yield return www;

					if (!www.isDone) {
						Debug.Log (www.error);
					} else {
						Debug.Log (www.text);
						//Debug.Log (www.text.Replace( "\\",""));
						//newData = JsonUtility.FromJson <Data> (www.text);
					}
					if (www.text == "false") {
						txtenter.color = Color.red;
						txtenter.text = "Username already exists";
					} else {
						txtenter.color = Color.green;
						txtenter.text = www.text;
						yield return new WaitForSeconds(1);
						UnityEngine.SceneManagement.SceneManager.LoadScene ("Login");
					}

				}else{
					txtenter.color = Color.red;
					txtenter.text = "Invalid password";
				}
			} else {
				txtenter.color = Color.red;
				txtenter.text = "Please enter Password more than 5 character";
			}
		} else {
			txtenter.color = Color.red;
			txtenter.text = "Please enter ID more than 5 character";
		}
	}

	public IEnumerator UploadScore (){

		WWWForm form = new WWWForm ();

		form.AddField ("Value_score", GameControl.instance.nScore);
		form.AddField ("Count_hp", GameControl.instance.countHp);
		form.AddField ("Count_milk", GameControl.instance.countMilk);
		form.AddField ("Count_miniItem", GameControl.instance.countMiniItem);
		form.AddField ("Count_bigItem", GameControl.instance.countBigItem);
		form.AddField ("Count_time", GameControl.instance.countTime);
		form.AddField ("Count_hpEnemy", GameControl.instance.countHpEnemy);
		form.AddField ("Count_scoreEnemy", GameControl.instance.countScoreEnemy);
		form.AddField ("Distance", GameControl.instance.nDistance.ToString());
		form.AddField ("Date_score", GameControl.instance.timeEndGame);
		form.AddField ("UserName", idPlayerInGame);

		WWW www = new WWW("http://127.0.0.1/HealtyRun/Update.php", form);

		yield return www;

		if (!www.isDone) {
			Debug.Log (www.error);
		} else {
  			Debug.Log (www.text);
		}
	}

}
