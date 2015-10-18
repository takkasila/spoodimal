using UnityEngine;
using System.Collections;

public class ClickToScene : MonoBehaviour {

    public string scene;
    public GameObject saveScene;

    public void GotoScene()
    {
        Application.LoadLevel(scene);
        if(saveScene)
        {
            saveScene.SendMessage("saveData", SendMessageOptions.RequireReceiver);
        }
    }
}
