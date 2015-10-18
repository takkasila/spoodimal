using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundController : MonoBehaviour {

    public AudioSource wall_hit;
    public AudioSource click;
    public AudioSource feed;
    public AudioSource hungry;
	
    public void playHitWall()
    {
        playSound(wall_hit);
    }

    public void playClick()
    {
        playSound(click);
    }

    public void playFeed()
    {
        playSound(feed);
    }

    public void playHungry()
    {
        playSound(hungry);
    }

    void playSound(AudioSource sound)
    {
        if (sound.isPlaying)
        {
            sound.Stop();
            sound.Play();
        }
        else
            sound.Play();
    }
}
