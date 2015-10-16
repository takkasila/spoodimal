using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class select_pet : MonoBehaviour {
    public CurrentSelectPet currentPetScript;
	private string UID,PID;
	private WWW www;
	void Start () {
		UID = PlayerPrefs.GetString("UID");
	}

    // Doge = 1
    // Cate = 2
	public void clickPet(){
        string petName = currentPetScript.getCurrentPetName();
        if(petName == "Doge")
            PID = "1";
        else if(petName == "Cate")
            PID = "2";
        StartCoroutine(goPlay());
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
		www = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryInsertPlayer.php",form);
		yield return www;
	}

}
