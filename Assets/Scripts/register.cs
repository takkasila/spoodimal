using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class register : MonoBehaviour {
	public Text outputUsername;
    public InputField outputPassword,outputRePassword;
	public Text msgUsernameError,msgPasswordError,msgRePasswordError;
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
			yield return new WaitForSeconds(0.2f);
			printMsgError();
		}
		StopCoroutine(checkUsername());
		if(msgUsernameError.text == "" && msgPasswordError.text == "" && msgRePasswordError.text == ""){
			buttonRegister.enabled = false;
			StartCoroutine(insertUser());
			while(www.isDone && !www2.isDone){
				yield return new WaitForSeconds(0.1f);
				StopCoroutine(insertUser());
			}
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
		print (resultCheckUsername);
		if(checkCount(outputUsername.text)){
			msgUsernameError.text = (resultCheckUsername)? "":"Username Error";
		}
		else{
			msgUsernameError.text = "Length Beetween 6 and 11";
		}
		if(checkCount(outputPassword.text)){
			msgPasswordError.text = (checkPassword())? "":"Password Error";
		}
		else{
			msgPasswordError.text = "Length Beetween 6 and 11";
		}
		if(checkCount(outputRePassword.text)){
			msgRePasswordError.text = "";
		}
		else{
			msgRePasswordError.text = "Length Beetween 6 and 11";
		}
	}
}
