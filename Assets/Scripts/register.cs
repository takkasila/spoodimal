using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class register : MonoBehaviour {
	public Text outputUsername;
    public InputField outputPassword,outputRePassword;
	public Text msgError;
	private bool resultCheckUsername;
	private string UID;
	private WWW www,www2;
	public Button buttonRegister;

	public void clickRegister (){
		StartCoroutine(checkUsername());
		checkPassword();
		StartCoroutine(goPlay());
	}

	IEnumerator goPlay(){
		while(!www.isDone) {

		}
		yield return new WaitForSeconds(0.2f);
		printMsgError();
		StopCoroutine(checkUsername());
		if(msgError.text == ""){
			buttonRegister.enabled = false;
			StartCoroutine(insertUser());
			while(www.isDone && !www2.isDone){

			}
			yield return new WaitForSeconds(0.1f);
			StopCoroutine(insertUser());
			PlayerPrefs.SetString("UID", UID);
			Application.LoadLevel ("menu");
		}
	}

	bool checkCount(string str){
		if(str.Length >=6 && str.Length <= 11){
			return true;
		}
		else{
			return false;
		}
	}

	IEnumerator insertUser(){
		WWWForm form = new WWWForm();
		form.AddField("username", outputUsername.text);
		form.AddField("password", outputPassword.text);
		www2 = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryInsertUser.php",form);
		yield return www2;
		UID = www2.text;
		Debug.Log("INSERT");
	}

	bool checkPassword(){
		if(outputPassword.text != outputRePassword.text){
			return false;
		}
		else{
			return true;
		}
	}

	IEnumerator checkUsername(){
		WWWForm form = new WWWForm();
		form.AddField("username", outputUsername.text);
		www = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryCheckUsername.php",form);
		yield return www;
		if(www.text == "not_available"){
			resultCheckUsername = false;
		}
		else if(www.text == "available"){
			resultCheckUsername = true;
		}
		Debug.Log(www.text);
	}
	

	void printMsgError(){
		if(!checkCount(outputUsername.text ) && !checkCount(outputPassword.text) && !checkCount(outputRePassword.text)){
			msgError.text = "Required Length 6 - 11 Character";
		}
		else{
			if(!resultCheckUsername){
				msgError.text = "Username Not Available";
			}
			else if(!checkPassword()){
				msgError.text = "Password Not Equals Re-Password";
			}
			else{
				msgError.text = "";
			}
		}
		print (msgError.text);
	}
}
