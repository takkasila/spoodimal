using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class select_pet : MonoBehaviour {
    public CurrentSelectPet currentPetScript;
	private string UID,PID,URL = "http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/";
	private WWW www,www2;
	public Text msgError;

	void Start () {
		UID = PlayerPrefs.GetString("UID");
	}

    // Doge = 1
    // Cate = 2
	public void clickPet(){
        string petName = currentPetScript.getCurrentPetName();
		StartCoroutine(checkInternet());
		while(!www2.isDone){
			
		}
		if (string.IsNullOrEmpty (www2.error)) {
			msgError.text = "";
			if (petName == "Doge") {
				PID = "1";
			} else if (petName == "Cate") {
				PID = "2";
			}
			StartCoroutine (goPlay ());
		} 
		else {
			msgError.text = "Can't Connect Server";
		}

	}

	IEnumerator goPlay(){
		StartCoroutine(insertPlayer());
		while (!www.isDone) {

		}
		yield return new WaitForSeconds(0.1f);
		StopCoroutine(insertPlayer());
		PlayerPrefs.SetString("UID", UID);
		Application.LoadLevel ("gamePlay");
	}

	IEnumerator insertPlayer(){
		WWWForm form = new WWWForm();
		form.AddField("UID", UID);
		form.AddField("PID", PID);
		www = new WWW(URL+"queryInsertPlayer.php",form);
		yield return www;
	}

	public void clickBack(){
		Application.LoadLevel ("login");
	}

	IEnumerator checkInternet(){
		www2 = new WWW("https://www.google.co.th");
		yield return www2;
		print (www2.error);
	}
}
