using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour {
    public float pushForce = 9.8f;
    Rigidbody2D rb;
    Transform forcePoint;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Transform centerOfMass =  transform.FindChild("CM");
        rb.centerOfMass = centerOfMass.localPosition;
        forcePoint = transform.FindChild("ForcePoint");
	}
	
	void Update () {
        rb.AddForceAtPosition(new Vector2(Input.acceleration.x * pushForce, 0), forcePoint.position, ForceMode2D.Force);
	}
}
