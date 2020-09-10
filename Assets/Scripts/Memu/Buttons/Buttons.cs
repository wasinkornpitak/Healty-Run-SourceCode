using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	public GameObject ImgAlert;

	public GameObject ImgAlertBack;

	public GameObject ImgAlertPause;

	public GameObject reportTop5;
	public GameObject reportAllPlayer;
	public GameObject reportTest;
	public GameObject reportTest2;
	public GameObject reportHistory;
	public GameObject reportTotalHistory;
	public GameObject reportPlayMost;
	public GameObject reportHiScore;
	public GameObject reportTop5Distance;

	public GameObject testOneScoll;
	public GameObject testTwoScoll; 

	public static Buttons instance;

	void Start(){
		instance = this;
	}

	public void Login(){
		StartCoroutine (Connections.instance.Login());
		ImgAlert.gameObject.SetActive (true);
	}

	public void AlertBackTrue(){
		ImgAlertBack.gameObject.SetActive (true);
	}

	public void AlertBackFalse(){
		ImgAlertBack.gameObject.SetActive (false);
	}

	public void Register(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
	}

	public void ConfirmRegister(){
		StartCoroutine (Connections.instance.Register());
		ImgAlert.gameObject.SetActive (true);
	}

	public void Exit(){
		Application.Quit ();
		print ("Exit");
	}

	public void Pause(){
		Time.timeScale = 0;
		ImgAlertPause.gameObject.SetActive (true);
	}

	public void Resume(){
		Time.timeScale = 1;
		ImgAlertPause.gameObject.SetActive (false);
	}

	public void BackToLogin(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Login");
	}

	public void Play(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
	}

	public void Restart(){
		Time.timeScale = 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
	}

	public void BackToMenu(){
		Time.timeScale = 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Menu");
	}

	public void Reports(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Reports");
	}

	public void HowToPlay(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("HowToPlay");
	}

	public void Ok(){
		ImgAlert.gameObject.SetActive (false);
	}

	//Report
	public void ReportTopFive(){
		reportTop5.gameObject.SetActive (true);
	}

	public void ReportAllPlayer(){
		reportAllPlayer.gameObject.SetActive (true);
	}

	public void ReportTest(){
		reportTest.gameObject.SetActive (true);
	}

	public void ReportHistory(){
		reportHistory.gameObject.SetActive (true);
	}

	public void ReportTotalHistory(){
		reportTotalHistory.gameObject.SetActive (true);
	}

	public void ReportPlayMost(){
		reportPlayMost.gameObject.SetActive (true);
	}

	public void ReportHiScore(){
		reportHiScore.gameObject.SetActive (true);
	}

	public void ReportTop5Distance(){
		reportTop5Distance.gameObject.SetActive (true);
	}

	public void ReportTestTwo(){
		reportTest2.gameObject.SetActive (true);
	}

	public void ConfrimSelectDateTestOne(){
		StartCoroutine (LoadReportTestOne.instance.loadReportsTestOne());
		StartCoroutine (delayLoad());
	}

	public void ConfrimSelectDateTestTwo(){
		StartCoroutine (LoadReportTestTwo.instance.loadReportsTestTwo());
		StartCoroutine (delayLoadTestTwo());
	}

	IEnumerator delayLoad(){
		foreach (Transform T in testOneScoll.transform) {
			Destroy (T.gameObject);
		}
		yield return new WaitForSeconds (0.1f);
		CreateTestOne.instance.createTestOne ();
		
	}

	IEnumerator delayLoadTestTwo(){
		foreach (Transform T in testTwoScoll.transform) {
			Destroy (T.gameObject);
		}
		yield return new WaitForSeconds (0.1f);
		CreateTestTwo.instance.createTestTwo ();

	}

	public void CloseformatError(){
		LoadReportTestOne.instance.formatError.gameObject.SetActive (false);
	}

	public void CloseformatErrorTwo(){
		LoadReportTestTwo.instance.formatError.gameObject.SetActive (false);
	}
}
