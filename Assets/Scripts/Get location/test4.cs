using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;

public class test4 : MonoBehaviour {

	bool gpsInit = false;
	LocationInfo currentGPSPosition;

	public delegate void GetItemCatelogReceiver(string text);

	public TextMesh outputText1;
	public TextMesh outputText2;
	public TextMesh outputText3;
	public TextMesh outputText4;
	public TextMesh outputText5;
	
	// Use this for initialization
	void Start () {
		//GetItemCatelog(RecieveItemCatelog);
	}
	
	// Update is called once per frame
	void Update () {
		#if PC
		Debug.Log("On PC / Don't have GPS");
		#elif !PC
		
		//Starting the Location service before querying location
		Input.location.Start(10f); // Accuracy of 10 m
		
		int wait = 100; // Per default
		
		// Checks if the GPS is enabled by the user (-> Allow location )
		if(Input.location.isEnabledByUser)
		{
			while(Input.location.status == LocationServiceStatus.Initializing && wait>0)
			{
				wait--;
			}
			
			
			if (Input.location.status == LocationServiceStatus.Failed) {
				print("Unable to determine device location");
			}
			else {
				gpsInit = true;
				// We start the timer to check each tick (every 3 sec) the current gps position
				InvokeRepeating("RetrieveGPSData", 0, 4);
			}
		}
		else
		{
			print ("GPS not available");
			//outputText1.text = "GPS not available";
		}
		#endif

		GetItemCatelog(RecieveItemCatelog);
	}

	void RetrieveGPSData()
	{
		currentGPSPosition = Input.location.lastData;
		string gpsString = "::" + currentGPSPosition.latitude + "//" + currentGPSPosition.longitude;
		print (gpsString);
		//outputText1.text = gpsString;
	}


	void GetItemCatelog(GetItemCatelogReceiver _GetItemCatelogReceiver)
	{
		StartCoroutine("GetItemCatelogResponse", _GetItemCatelogReceiver);
	}
	
	IEnumerator GetItemCatelogResponse(GetItemCatelogReceiver _GetItemCatelogReceiver)
	{
		string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + Input.location.lastData.latitude  + "&lon=" + Input.location.lastData.longitude + "&APPID=95306e9f0721ee115aeb609673b7d30e";
		WWW www = new WWW(url);
		yield return www; 
		
		_GetItemCatelogReceiver(www.text);
	}
	
	private void RecieveItemCatelog(string text)
	{
		var N = JSONNode.Parse(text);
		
		string lon = N["coord"]["lon"];
		string lat = N["coord"]["lat"];
		string w_main = N["weather"][0]["main"];
		string w_desc = N["weather"][0]["description"];
		string m_temp = N ["main"] ["temp"];
		//var m_temp = N ["main"]["temp"].AsFloat;
		var m_pressure = N["main"]["pressure"].AsFloat;
		var m_humidity = N["main"]["humidity"].AsFloat;
		var m_temp_max = N["main"]["temp_max"].AsFloat;
		var m_temp_min = N["main"]["temp_min"].AsFloat;
		
		
		Debug.Log (lon);
		Debug.Log (lat);
		Debug.Log (w_main);
		Debug.Log (w_desc);
		Debug.Log (m_temp);
		Debug.Log (m_pressure);
		Debug.Log (m_humidity);
		Debug.Log (m_temp_max);
		Debug.Log (m_temp_min);
		
		outputText1.text = lon;
		outputText2.text = lat;
		outputText3.text = m_temp;
		outputText4.text = w_main;
		outputText5.text = w_desc;
		
		//Debug.Log(text);
	}
}
