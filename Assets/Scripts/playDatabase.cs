using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class PlayDatabase : MonoBehaviour {

    // Can be get, push
    // UID, PID
    // PET_NAME, START_DATE
    // PET_WEIGHT
    // PET_FOOD
    // PET_TOTALTIME

    public PetData petData;

    [HideInInspector]
    public string UID, PID, PET_NAME, START_DATE;
    private string PET_NAME_Old;

    [HideInInspector]
    public double PET_WEIGHT, PET_TOTALTIME;
	private double PET_WEIGHT_Old;

    [HideInInspector]
    public int PET_FOOD;
	private int PET_FOOD_Old;

    // Calling URLs
	private WWW www,www2,www3;
	
	void Start () {
		PET_NAME = "";
		UID = PlayerPrefs.GetString("UID");
		StartCoroutine (checkPetData ());
	}

	void Update () {
		if (PET_WEIGHT != PET_WEIGHT_Old || PET_FOOD != PET_FOOD_Old || PET_NAME != PET_NAME_Old) {
			PET_WEIGHT_Old = PET_WEIGHT;
			PET_FOOD_Old = PET_FOOD;
			PET_NAME_Old = PET_NAME;
			StartCoroutine (updatePetData ());

			while(!www3.isDone){
                // Should wait for some int second?
			}
			StopCoroutine(updatePetData());
		}
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
			PET_TOTALTIME = double.Parse(removeDoubleQuote(jsonData.GetValue("PET_TOTALTIME").ToString()));
			print (removeDoubleQuote(jsonData.ToString()));

            petData.getDatabase();
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
		www2 = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryInsertPetData.php",form);
		yield return www2;

        petData.getDatabase();
	}

	IEnumerator updatePetData(){
		WWWForm form = new WWWForm();
		form.AddField("UID", UID);
		form.AddField("PET_NAME", PET_NAME);
		form.AddField("PET_WEIGHT", PET_WEIGHT.ToString());
		form.AddField("PET_FOOD", PET_FOOD.ToString());
		form.AddField("PET_TOTALTIME", PET_TOTALTIME.ToString());
		www3 = new WWW("http://www.zp9039.tld.122.155.167.199.no-domain.name/spoodiman/queryUpdatePetData.php",form);
		yield return www3;
	}

}
