using UnityEngine;
using System.Collections;

public class ClickToScene : MonoBehaviour {

    public string scene;

    public void GotoScene()
    {
        Application.LoadLevel(scene);
    }
}
