using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetData : MonoBehaviour {

    // Phase 2 TODO: Show food, start date
    public InputField text_name;
    public Text text_weight_output;
    public Text text_totalTime_output;
    public Text text_food_output;
    public PlayDatabase petDatabase;

    public GameObject FoodUIParent;

    public GameObject Doge;
    public GameObject DogeFood1;
    public GameObject DogeFood2;

    public GameObject Cate;
    public GameObject CateFood1;
    public GameObject CateFood2;

    [HideInInspector]
    public string PYID, PID;
    [HideInInspector]
    public string petName, startDate;
    [HideInInspector]
    public static double petWeight;
    [HideInInspector]
    public static int petFood;
    [HideInInspector]
    public static double petTotalTime;

    bool firstScene = true;

    void Start () {
		petFood = 0;
		petWeight = 0;
		petTotalTime = 0;
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
        text_weight_output.text = petWeight.ToString("F1") + " kg";

        petDatabase.PET_TOTALTIME = petTotalTime;
        text_totalTime_output.text = ((int)petTotalTime).ToString() + " sec";

        petDatabase.PET_FOOD = petFood;
        text_food_output.text = petFood.ToString();
	}

    void EndEditName(InputField input)
    {
        petDatabase.PET_NAME = petName = input.text;
    }

    // call upon database finished receive data 
    public void getDatabase()
    {
        PYID = petDatabase.PYID;
        PID = petDatabase.PID;
        petName = petDatabase.PET_NAME;
        startDate = petDatabase.START_DATE;
        petWeight = petDatabase.PET_WEIGHT;
        petFood = petDatabase.PET_FOOD;
        petTotalTime = petDatabase.PET_TOTALTIME;

        text_name.text = petName;
        text_weight_output.text = petWeight.ToString("F1");
        text_totalTime_output.text = ((int)petTotalTime).ToString();
        text_food_output.text = petFood.ToString();

        // Doge
        if(PID == "1")
        {
            Instantiate(Doge);
            
            var food = Instantiate(DogeFood1);
            food.transform.parent = FoodUIParent.transform;
            // Have to fix value cause unity world space not compatible with RectTransform
            food.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.86f, 3.46f, 0);

            food = Instantiate(DogeFood2);
            food.transform.parent = FoodUIParent.transform;
            food.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.84f, 2.35f, 0);
        }
        // Cate
        else if(PID == "2")
        {
            Instantiate(Cate);

            var food = Instantiate(CateFood1);
            food.transform.parent = FoodUIParent.transform;
            food.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.86f, 3.46f, 0);

            food = Instantiate(CateFood2);
            food.transform.parent = FoodUIParent.transform;
            food.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.86f, 2.35f, 0);
        }
    }
}
