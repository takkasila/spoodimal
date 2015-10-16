using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class login : MonoBehaviour {
	public Text username,msgError;
    public InputField password;
	private string UID,URL = "http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/";
	private bool loginSuccess = false,resultCheckSelectPet = false;
	private WWW www,www2,www3;

	public void clickPlay (){
		StartCoroutine(checkInternet());
		while(!www3.isDone){

		}
		if (string.IsNullOrEmpty(www3.error)) {
			msgError.text = "";
			StopCoroutine (checkInternet ());
			StopCoroutine (goPlay ());
			StartCoroutine (checkLogin ());
			StartCoroutine (goPlay ());
		}
		else {
			msgError.text = "Can't Connect Server";
		}
	}

	IEnumerator goPlay(){
		while (!www.isDone) {

		}
		yield return new WaitForSeconds(0.1f);
		StopCoroutine(checkLogin());
		if (loginSuccess) {
			StartCoroutine(checkSelectPet());
			while(!www2.isDone){

			}
			yield return new WaitForSeconds(0.1f);
			StopCoroutine(checkSelectPet());
			PlayerPrefs.SetString("UID", UID);
			if(resultCheckSelectPet){
				Application.LoadLevel ("gameplay");
			}
			else{
				Application.LoadLevel ("menu");
			}
		}
	}

	public void clickRegister (){
    	Application.LoadLevel ("register");
	}

	string removeDoubleQuote(string str){
		return str.Trim( new Char[] { '"' });
	}

	IEnumerator checkLogin(){
		WWWForm form = new WWWForm();
		form.AddField("username", username.text);
		form.AddField("password", password.text);
		www = new WWW(URL+"queryCheckLogin.php",form);
		yield return www;
		JSONObject jsonObject = JSONObject.Parse(www.text);
		string valueType = removeDoubleQuote(jsonObject.GetValue ("TYPE").ToString());
		if (valueType.Equals("UID")) {
			UID = removeDoubleQuote(jsonObject.GetValue("VALUE").ToString());
			msgError.text = "";
			loginSuccess = true;
		}
		else if(valueType.Equals("ERROR")){
			msgError.text = removeDoubleQuote(jsonObject.GetValue("VALUE").ToString());
			loginSuccess = false;
		}
	}

	IEnumerator checkSelectPet(){
		WWWForm form = new WWWForm();
		form.AddField("UID", UID);
		www2 = new WWW(URL+"queryCheckSelectPet.php",form);
		yield return www2;
		string result = removeDoubleQuote(www2.text);
		if(result.Equals("not_selected")){
			resultCheckSelectPet = false;
		}
		else if(result.Equals("selected")){
			resultCheckSelectPet = true;
		}
		Debug.Log(www2.text);
		print (resultCheckSelectPet);
	}

	IEnumerator checkInternet(){
		www3 = new WWW("https://www.google.co.th");
		yield return www3;
		print (www3.error);
	}
}
