using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CopyText : MonoBehaviour {
    public Text targetText;
    Text selfText;

    void Start()
    {
        selfText = GetComponent<Text>();
    }
    void Update () {
        selfText.text = targetText.text;
	}
}
