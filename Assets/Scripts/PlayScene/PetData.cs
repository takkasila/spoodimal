using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetData : MonoBehaviour {

    // Phase 2 TODO: Show food, start date
    public InputField text_name;
    public Text text_weight_output;
    public Text text_totalTime_output;
    public PlayDatabase petDatabase;

    public GameObject Doge;
    public GameObject Cate;

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
        // Automaticly sync data so data could be globally edit anytime
        petDatabase.PET_WEIGHT = petWeight;
        text_weight_output.text = petWeight.ToString("F1");

        petDatabase.PET_TOTALTIME = petTotalTime;
        text_totalTime_output.text = ((int)petTotalTime).ToString();

        petDatabase.PET_FOOD = petFood;
	}

    void EndEditName(InputField input)
    {
        petDatabase.PET_NAME = petName = input.text;
    }

    // call upon database finished receive data 
    public void getDatabase()
    {
        UID = petDatabase.UID;
        PID = petDatabase.PID;
        petName = petDatabase.PET_NAME;
        startDate = petDatabase.START_DATE;
        petWeight = petDatabase.PET_WEIGHT;
        petFood = petDatabase.PET_FOOD;
        petTotalTime = petDatabase.PET_TOTALTIME;

        text_name.text = petName;
        text_weight_output.text = petWeight.ToString("F1");
        text_totalTime_output.text = ((int)petTotalTime).ToString();

        if(PID == "1")
        {
            // Doge
            Instantiate(Doge);
        }
        else if(PID == "2")
        {
            // Cate
            Instantiate(Cate);
        }
    }
}
