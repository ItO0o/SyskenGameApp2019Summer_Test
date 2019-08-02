using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStart : MonoBehaviour
{
    public GameObject[] hideObj;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < hideObj.Length; i++)
        {
            hideObj[i].SetActive(false);
        }
    }
    public GameObject FindAndGetHideObj(string objName)
    {
        for (int i = 0; i <= hideObj.Length; i++)
        {
            Debug.Log(hideObj[i].name);
            if (hideObj[i].name.Equals(objName))
            {
                return hideObj[i];
            }
        }
        Debug.Log("Can't find obj " + "\""+objName + "\"");
        return null;
    }

    
}
