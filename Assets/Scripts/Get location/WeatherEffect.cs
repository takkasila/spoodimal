using UnityEngine;
using System.Collections;

public class WeatherEffect : MonoBehaviour {

    public getlocation getlocationguy;
    bool init = false;

    public SpriteRenderer BGSprite;

    public Sprite sunnyBG;
    public Sprite rainyBG;
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
                break;

            default:
                BGSprite.sprite = sunnyBG;
                break;
        }
    }
}
