using UnityEngine;
using System.Collections;

public class SunnyEffect : MonoBehaviour {
    public float step;
    float counter;
    public float tickTime;
	// Update is called once per frame
	void Update () {
        if (counter < tickTime)
            counter += Time.deltaTime;
        else
        {
            counter = 0;
            transform.Rotate(new Vector3(0, 0, 1) * step);
        }
	}
}
