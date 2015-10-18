using UnityEngine;
using System.Collections;

public class PetAnimationController : MonoBehaviour {

    public float intervalToSleep = 10;
    float intervalSleep_counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        intervalSleep_counter +=Time.deltaTime;
        if(intervalSleep_counter >= intervalToSleep)
        {
            intervalSleep_counter = 0;
            PlaySleep();
        }
	
	}

    public void PlayEatFood(int foodType)
    {

    }

    public void PlayHeadHitWall()
    {

    }

    void OnMouseDown()
    {

    }

    void PlaySleep()
    {

    }
}
