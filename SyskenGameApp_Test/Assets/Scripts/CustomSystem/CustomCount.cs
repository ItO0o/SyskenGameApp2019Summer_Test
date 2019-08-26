using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCount : MonoBehaviour
{
    Text countText;
    // Start is called before the first frame update
    void Start()
    {
        countText = GameObject.Find("CustomCount_Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = StaticInfo.myCustom.Count.ToString() + "/" + "20";
    }
}
