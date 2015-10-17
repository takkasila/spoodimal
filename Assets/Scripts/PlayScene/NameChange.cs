using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameChange : MonoBehaviour {
    public Image textFieldImg;
    InputField inputField;
    Text x;
	// Use this for initialization
	void Start () {
        inputField = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inputField.isFocused)
            textFieldImg.enabled = true;
        else
            textFieldImg.enabled = false;
	
	}
}
