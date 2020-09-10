using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ReportTestTwo
{
	public List<TestTwo> TestTwo;
}

[System.Serializable]
public class TestTwo
{
	public string datePlay;
	public string dates;
	public string dayPlay;
	public string UserName;
	public int score;
}

public class LoadReportTestTwo : MonoBehaviour {

	public LoadReportTestOne loadReportTestOne;

	public Text txtError;

	public GameObject formatError;

	public static LoadReportTestTwo instance;

	public InputField dateStart;
	public InputField dateEnd;
	public InputField Username;

	public ReportTestTwo reportTestTwo;

	bool loadFirst;

	// Use this for initialization
	void Start () {
		instance = this;
		loadFirst = true;
		StartCoroutine (loadReportsTestTwo());
	}

	public IEnumerator loadReportsTestTwo(){

		// get date no name
		if (loadFirst || ((loadReportTestOne.checkDateTrue (dateStart.text, dateEnd.text) == "true") && (Username.text == ""))) {

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

			WWW www = new WWW("http://127.0.0.1/HealtyRun/test2GetDateNoName.php", form);

			yield return www;

			if (!www.isDone) {
				Debug.Log (www.error);
			} else {
				Debug.Log (www.text.Replace( "\\",""));
				reportTestTwo = JsonUtility.FromJson <ReportTestTwo> (www.text);
			}

		// get name no date
		} else if ((dateStart.text == "" && dateEnd.text == "" && (Username.text != ""))) {

			WWWForm form = new WWWForm ();

			if (!loadFirst) {
				form.AddField ("UserName", Username.text);

			} else {
				form.AddField ("UserName", Username.text);
				loadFirst = false;
			}

			WWW www = new WWW("http://127.0.0.1/HealtyRun/test2GetNameNoDate.php", form);

			yield return www;

			if (!www.isDone) {
				Debug.Log (www.error);
			} else {
				Debug.Log (www.text.Replace( "\\",""));
				reportTestTwo = JsonUtility.FromJson <ReportTestTwo> (www.text);
			}

		// get date and name
		} else	if (((loadReportTestOne.checkDateTrue (dateStart.text, dateEnd.text) == "true") && (Username.text != ""))) {
			
			WWWForm form = new WWWForm ();

			if (!loadFirst) {
				string[] tempDateStart = dateStart.text.Split ('/');
				string[] tempDateEnd = dateEnd.text.Split ('/');
				string myDateStart = tempDateStart [2] + "/" + tempDateStart [1] + "/" + tempDateStart [0];
				string myDateEnd = tempDateEnd [2] + "/" + tempDateEnd [1] + "/" + tempDateEnd [0];

				form.AddField ("start", myDateStart);
				form.AddField ("end", myDateEnd);
				form.AddField ("UserName", Username.text);
			} else {
				form.AddField ("start", dateStart.text);
				form.AddField ("end", dateEnd.text);
				form.AddField ("UserName", Username.text);
				loadFirst = false;
			}

			WWW www = new WWW("http://127.0.0.1/HealtyRun/test2GetDateAndName.php", form);

			yield return www;

			if (!www.isDone) {
				Debug.Log (www.error);
			} else {
				Debug.Log (www.text.Replace( "\\",""));
				reportTestTwo = JsonUtility.FromJson <ReportTestTwo> (www.text);
			}
		} else {
			//Error
			txtError.text = loadReportTestOne.checkDateTrue (dateStart.text, dateEnd.text);
			formatError.gameObject.SetActive (true);
		}
	}
}
