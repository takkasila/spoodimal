using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;

public class getlocation : MonoBehaviour {
	
	public delegate void GetItemCatelogReceiver(string text);

    public string weather = "";
    void Start()
    {
        StartCoroutine(StartLocation());
        GetItemCatelog(RecieveItemCatelog);
    }

	// get latitude and longtitude
	IEnumerator StartLocation()
	{
		// First, check if user has location service enabled
        //if (!Input.location.isEnabledByUser)
            //print("GPS NOT AVAILABLE");
		//outputText1.text = "GPS not available";
		yield break;
		
		// Start service before querying location
		Input.location.Start();
		
		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		
		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}
		
		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		}
		else
		{
			// Access granted and location value could be retrieved
			string gpsString = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
			print (gpsString);
			//outputText1.text = gpsString;
		}
		
		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
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

        weather = w_main;

        //Debug.Log (lon);
        //Debug.Log (lat);
        //Debug.Log(w_main); // Require one
        //Debug.Log (w_desc);
        //Debug.Log (m_temp);
        //Debug.Log (m_pressure);
        //Debug.Log (m_humidity);
        //Debug.Log (m_temp_max);
        //Debug.Log (m_temp_min);

	}
}
