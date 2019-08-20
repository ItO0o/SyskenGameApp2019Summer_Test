using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWaitForCallbacl : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.GetComponent<Button>().interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (StaticInfo.callback.Equals("Loaded data")) {
            this.GetComponent<Button>().interactable = true;
        }
    }
}
