using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour{

    public PetAnimationController animationController;
    public int foodToGrow = 10;
    public float baseWeight = 10;
    public float maxWeight = 20;
    public float weightPerGrow = 1;
    public float minScale;
    public float maxScale;
    public int secToGrow = 2 * 60;

    public float pushForce = 9.8f;
    Rigidbody2D rb;
    Transform forcePoint;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Transform centerOfMass =  transform.FindChild("CM");
        rb.centerOfMass = centerOfMass.localPosition;
        forcePoint = transform.FindChild("ForcePoint");

        // For testing
        //PetData.petFood = 0;
        //PetData.petTotalTime = 0;
	}
	
	void Update () {
        updateForce();
        growing();
        updateTime();
	}

    void updateForce()
    {
        rb.AddForceAtPosition(new Vector2(Input.acceleration.x * pushForce, 0), forcePoint.position, ForceMode2D.Force);
    }

    void growing()
    {
        PetData.petWeight = baseWeight
            + Mathf.Clamp(weightPerGrow * (int)(PetData.petFood / foodToGrow)
            , 0, maxWeight - baseWeight);

		PetData.petWeight += weightPerGrow * (int)(PetData.petTotalTime / secToGrow);

        float percentWeight = ((float)PetData.petWeight - baseWeight) / (maxWeight - baseWeight);
        float scale = minScale + percentWeight * (maxScale - minScale);
        transform.localScale = new Vector3(scale, scale, 1);

    }

    void updateTime()
    {
        PetData.petTotalTime += Time.deltaTime;
    }

    public void gotFood(int foodValue)
    {
        PetData.petFood++;
        animationController.PlayEatFood(foodValue);
    }
}
