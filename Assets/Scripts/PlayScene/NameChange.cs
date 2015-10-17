using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameChange : MonoBehaviour {
    public Image textFieldImg;
    InputField inputField;

	void Start () {
        inputField = GetComponent<InputField>();
	}

	void Update () {
        if (inputField.isFocused)
            textFieldImg.enabled = true;
        else
            textFieldImg.enabled = false;
	
	}
}
