using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetData : MonoBehaviour {

    InputField text_name;
    Text text_weight_output;
    Text text_totalTime_output;
    
    [HideInInspector]
    public string UID, PID;
    public string petName, startDate;
    public double petWeight;
    public int petFood;
    public double petTotalTime;

    void Start () {
	
	}
	
	void Update () {
	
	}
}
