using UnityEngine;
using System.Collections;

public class WeatherEffect : MonoBehaviour {

    public getlocation getlocationguy;
    bool init = false;

    public SpriteRenderer BGSprite;

    public Sprite sunnyBG;
    public GameObject sunnyEffect;
    public AudioClip sunnySoundBG;
    
    public Sprite rainyBG;
    public GameObject rainingEffect;
    public AudioClip rainingSoundBG;
 
    public AudioSource ExtraSoundBG;

    void Update()
    {
        if(getlocationguy.weather != "" && !init)
        {
            init = true;
            SpawnWeather();
        }
    }

    // Rain
    // Sunny    // Default case
    void SpawnWeather()
    {
        switch(getlocationguy.weather)
        {
            case "Rain":
                BGSprite.sprite = rainyBG;
                Instantiate(rainingEffect);
                ExtraSoundBG.clip = rainingSoundBG;
                ExtraSoundBG.Play();
                break;

            default:
                BGSprite.sprite = sunnyBG;
                Instantiate(sunnyEffect);
                ExtraSoundBG.clip = sunnySoundBG;
                ExtraSoundBG.Play();
                break;
        }
    }
}
