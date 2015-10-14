using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	private string UID;
	// Use this for initialization
	void Start () {
		UID = PlayerPrefs.GetString("UID");
		print (UID);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
