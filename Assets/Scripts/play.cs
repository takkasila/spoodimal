using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class play : MonoBehaviour {
	public Text inputPET_NAME,inputPET_WEIGHT,inputPET_FOOD;
	private string UID,PID,PET_NAME,PET_NAME_Old,START_DATE,UPDATE_DATE;
	private double PET_WEIGHT,PET_WEIGHT_Old;
	private int PET_FOOD,PET_FOOD_Old;
	private WWW www,www2,www3;
	// Use this for initialization
	void Start () {
		PET_NAME = "Petname";
		PET_WEIGHT = 0;
		PET_FOOD = 0;
		UID = PlayerPrefs.GetString("UID");
		StartCoroutine (checkPetData ());
//		showUID.text = UID;
//		Debug.Log (UID);

	}

	// Update is called once per frame
	void Update () {
		if (inputPET_WEIGHT.text != "") {
			PET_WEIGHT = double.Parse(inputPET_WEIGHT.text);
		}
		if(inputPET_FOOD.text != ""){
			PET_FOOD = int.Parse(inputPET_FOOD.text);
		}
//		print (inputPET_WEIGHT.text);
		if (PET_WEIGHT != PET_WEIGHT_Old || PET_FOOD != PET_FOOD_Old || PET_NAME != PET_NAME_Old) {
			PET_WEIGHT_Old = PET_WEIGHT;
			PET_FOOD_Old = PET_FOOD;
			PET_NAME_Old = PET_NAME;
			StartCoroutine (updatePetData ());
			while(!www3.isDone){

			}
			StopCoroutine(updatePetData());
		}
	}

	public void confirmPetName(){
		PET_NAME = inputPET_NAME.text;
	}

	string removeDoubleQuote(string str){
		return str.Trim( new Char[] { '"' });
	}

	IEnumerator checkPetData(){
		WWWForm form = new WWWForm();
		form.AddField("UID", UID);
		www = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryCheckPetData.php",form);
		yield return www;
		JSONObject jsonObject = JSONObject.Parse(www.text);
		string valueType = removeDoubleQuote(jsonObject.GetValue ("TYPE").ToString());
		if (valueType.Equals ("DATA")) {
			JSONObject jsonData = JSONObject.Parse(jsonObject.GetValue("VALUE").ToString());
			PID = removeDoubleQuote(jsonData.GetValue("PID").ToString());
			START_DATE = removeDoubleQuote(jsonData.GetValue("START_DATE").ToString());
			PET_NAME = removeDoubleQuote(jsonData.GetValue("PET_NAME").ToString());
			PET_WEIGHT = double.Parse(removeDoubleQuote(jsonData.GetValue("PET_WEIGHT").ToString()));
			PET_FOOD = int.Parse(removeDoubleQuote(jsonData.GetValue("PET_FOOD").ToString()));
			print (removeDoubleQuote(jsonData.ToString()));
		}
		else if (valueType.Equals ("ERROR")) {
			StartCoroutine(insertPetData());
		}
	}

	IEnumerator insertPetData(){
		WWWForm form = new WWWForm();
		form.AddField("UID", UID);
		form.AddField("PET_NAME", PET_NAME);
		form.AddField("PET_WEIGHT", PET_WEIGHT.ToString());
		form.AddField("PET_FOOD", PET_FOOD.ToString());
		www2 = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryInsertPetData.php",form);
		yield return www2;
	}

	IEnumerator updatePetData(){
		WWWForm form = new WWWForm();
		form.AddField("UID", UID);
		form.AddField("PET_NAME", PET_NAME);
		form.AddField("PET_WEIGHT", PET_WEIGHT.ToString());
		form.AddField("PET_FOOD", PET_FOOD.ToString());
		www3 = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryUpdatePetData.php",form);
		yield return www3;
	}
}
