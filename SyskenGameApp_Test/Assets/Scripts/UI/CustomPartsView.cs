using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPartsView : MonoBehaviour
{
    private GameObject[] buttons;
    private GameObject[] cntText;
    public Vector2 t;
    GameObject instObj;
    // Use this for initialization
    void Start()
    {
        GameObject viewContent = GameObject.Find("Custom_Content");
        buttons = new GameObject[StaticInfo.items.Count];
        cntText = new GameObject[StaticInfo.items.Count];
        for (int i = 0; i < StaticInfo.items.Count; i++)
        {

            instObj = Instantiate(Resources.Load<GameObject>("Part_Button"), new Vector3(0,0,0),Quaternion.identity,viewContent.transform);
            buttons[i] = instObj;
            instObj.name = StaticInfo.items[i].name + "_Button";
            instObj.GetComponent<RectTransform>().localPosition = new Vector3(50, -50 *(i + 1), 0);
            instObj.transform.GetChild(0).GetComponent<Text>().text = StaticInfo.items[i].name;
            int s = i;
            instObj.GetComponent<Button>().onClick.AddListener(() =>
            GameObject.Find("EventSystem").GetComponent<CustomFuso>().AddParts(StaticInfo.items[s].name,s)
            );

            instObj = Instantiate(Resources.Load<GameObject>("Text"), new Vector3(0, 0, 0), Quaternion.identity, viewContent.transform);
            cntText[i] = instObj;
            instObj.name = StaticInfo.items[i].name + "_Text";
            instObj.GetComponent<Text>().text = "×" + StaticInfo.items[i].cnt;
            instObj.GetComponent<RectTransform>().localPosition = new Vector3(150, -50 * (i + 1), 0);
        }
    }

    public void UpdateItemCntView() {
        for (int i = 0; i < StaticInfo.items.Count; i++) {
            cntText[i].GetComponent<Text>().text = StaticInfo.items[i].cnt.ToString();
        }
    }
}
