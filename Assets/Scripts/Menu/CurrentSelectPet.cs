using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CurrentSelectPet : MonoBehaviour {

    public Text displayName, displayNameShadow;
    List<GameObject> allChildren = new List<GameObject>();
    GameObject closestPet;
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            allChildren.Add(child.gameObject);
        }
        closestPet = allChildren[0];
    }
    void Update()
    {
        foreach(GameObject child in allChildren)
        {
            if(Mathf.Abs( child.transform.position.x) < Mathf.Abs(closestPet.transform.position.x) )
            {
                closestPet = child;
            }
        }

        displayNameShadow.text = displayName.text = closestPet.name;
    }
    public string getCurrentPetName()
    {
        return closestPet.name;
    }

}
