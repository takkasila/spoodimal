using UnityEngine;
using System.Collections;

public class ScrollSize : MonoBehaviour {

    public float maxSize = 1.2f, minSize = 0.8f;
    public SpriteRenderer BG_renderer;
    float screenWidth, screenHeight;
	void Start () {
        screenWidth = BG_renderer.bounds.size.x;
        screenHeight = BG_renderer.bounds.size.y;
	}
	
	void Update () {
        float dist = Mathf.Clamp(transform.position.x, -screenWidth / 2, screenWidth / 2);
        float distPercent;
        if(dist >= 0)
            distPercent = (screenWidth / 2 - dist) / (screenWidth / 2);
        else
            distPercent = (screenWidth / 2 + dist) / (screenWidth / 2);

        float extraSize = (maxSize - minSize) * distPercent;
        float fullSize = extraSize + minSize;
        transform.localScale = new Vector3(fullSize, fullSize, fullSize);
	}
}
