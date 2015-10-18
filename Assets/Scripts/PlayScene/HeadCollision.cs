using UnityEngine;
using System.Collections;

public class HeadCollision : MonoBehaviour {

    public PetAnimationController animationController;

	void OnCollisionEnter2D(Collision2D stuff)
    {
        animationController.PlayHeadHitWall();
    }
}
