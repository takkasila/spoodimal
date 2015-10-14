using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    public AudioClip sound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter2D() {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
