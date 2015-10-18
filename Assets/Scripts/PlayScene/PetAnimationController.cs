using UnityEngine;
using System.Collections;

public class PetAnimationController : MonoBehaviour {

    public float intervalToSleep = 10;
    float intervalSleep_counter = 0;
    public float intervalToHungry = 14;
    float intervalHungry_counter = 0;

    bool doNothing = true;
    Animator anim;

    bool ticking = true;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        // A quick fix. Need to work soon
        ticking = !ticking;
        if(ticking)
            clearAnimationVariable();

        updateSleepCounter();
        updateHungryCounter();
	}

    void updateSleepCounter()
    {
        if (doNothing)
            intervalSleep_counter += Time.deltaTime;
        else
            intervalSleep_counter = 0;

        if (intervalSleep_counter >= intervalToSleep)
        {
            intervalSleep_counter = 0;
            PlaySleep();
        }

        doNothing = true;
    }

    void updateHungryCounter()
    {
        intervalHungry_counter += Time.deltaTime;
        if(intervalHungry_counter >= intervalToHungry)
        {
            intervalHungry_counter = 0;
            anim.SetBool("hungry", true);
        }
    }

    void clearAnimationVariable()
    {
        anim.SetBool("eat1", false);
        anim.SetBool("eat2", false);
        anim.SetBool("hitWall", false);
        anim.SetBool("reac1", false);
        anim.SetBool("reac2", false);
        anim.SetBool("sleep", false);
        anim.SetBool("hungry", false);
    }

    public void PlayEatFood(int foodType)
    {
        if (foodType == 1)
            anim.SetBool("eat1", true);
        else if (foodType == 2)
            anim.SetBool("eat2", true);

        intervalHungry_counter = 0;
        doNothing = false;
    }

    public void PlayHeadHitWall()
    {
        anim.SetBool("hitWall", true);

        doNothing = false;
    }

    void OnMouseDown()
    {
        switch(Random.Range(1, 2))
        {
            case 1:
                anim.SetBool("reac1", true);
                break;
            case 2:
                anim.SetBool("reac2", true);
                break;
        }

        doNothing = false;
    }

    void PlaySleep()
    {
        anim.SetBool("sleep", true);
    }
}
