using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class select_pet : MonoBehaviour {
	private string UID,PID;
	private WWW www;
	public Button buttonDog,buttonCat;
	// Use this for initialization
	void Start () {
		UID = PlayerPrefs.GetString("UID");
	}

	// Update is called once per frame
	void Update () {

	}

	public void clickDog(){
		PID = "1";
		afterClickButton();
	}

	public void clickCat(){
		PID = "2";
		afterClickButton();
	}

	void afterClickButton(){
		buttonDog.enabled = false;
		buttonCat.enabled = false;
		StartCoroutine(goPlay());
	}

	IEnumerator goPlay(){
		StartCoroutine(insertPlayer());
		while (!www.isDone) {

		}
		yield return new WaitForSeconds(0.1f);
		StopCoroutine(insertPlayer());
		PlayerPrefs.SetString("UID", UID);
		Application.LoadLevel ("play");
	}

	IEnumerator insertPlayer(){
		WWWForm form = new WWWForm();
		form.AddField("UID", UID);
		form.AddField("PID", PID);
		www = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryInsertPlayer.php",form);
		yield return www;
	}

}
