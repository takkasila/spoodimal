using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetData : MonoBehaviour {

    // Phase 2 TODO: Show food, start date
    public InputField text_name;
    public Text text_weight_output;
    public Text text_totalTime_output;
    public PlayDatabase petDatabase;

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

    bool firstScene = true;

    void Start () {

        //Adding end name edit listener
        text_name.onEndEdit.AddListener(
            delegate
            {
                EndEditName(text_name);
            }
        );
	}

	void Update () {
	}

    void EndEditName(InputField input)
    {
        Debug.Log("Yo it's working");
        petDatabase.PET_NAME = petName = input.text;
    }

    // call upon database finished receive data 
    public void getDatabase()
    {
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
}
