using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class login : MonoBehaviour {
	public Text username,msgError;
    public InputField password;
	private string UID;
	private bool loginSuccess = false,resultCheckSelectPet = false;
	private WWW www,www2;

	public void clickPlay (){
		StopCoroutine(goPlay());
		StartCoroutine(checkLogin());
		StartCoroutine(goPlay());
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
		www = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryCheckLogin.php",form);
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
		www2 = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryCheckSelectPet.php",form);
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
}
