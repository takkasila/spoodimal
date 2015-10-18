using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetData : MonoBehaviour {

    // Phase 2 TODO: Show food, start date
    public InputField text_name;
    public Text text_weight_output;
    public Text text_totalTime_output;
    public playDatabase petDatabase;

    [HideInInspector]
    public string UID, PID;
    [HideInInspector]
    public string petName, startDate;
    [HideInInspector]
    public double petWeight;
    [HideInInspector]
    public int petFood;
    [HideInInspector]
    public double petTotalTime;

    void Start () {
        UID = petDatabase.UID;
        PID = petDatabase.UID;
        petName = petDatabase.PET_NAME;
        startDate = petDatabase.START_DATE;
        petWeight = petDatabase.PET_WEIGHT;
        petFood = petDatabase.PET_FOOD;
        petTotalTime = petDatabase.PET_TOTALTIME;

        text_name.text = petName;
        text_weight_output.text = petWeight.ToString("F1");
        text_totalTime_output.text = ((int)petTotalTime).ToString();
	}
	
	void Update () {
	    
	}
}
