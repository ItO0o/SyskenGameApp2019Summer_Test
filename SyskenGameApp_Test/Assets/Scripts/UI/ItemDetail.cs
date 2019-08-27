using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDetail : MonoBehaviour, IPointerEnterHandler{
    string SAVE_FILE_PATH = "TextResource/ItemDetailText/";
    string fileName;
    int index;
    public void OnPointerEnter(PointerEventData eventData) {
        LoadAndPrintText();
    }
    public void OnPointerExit(PointerEventData eventData) {
        ClearText();
    }
    public void LoadAndPrintText() {
        fileName = StaticInfo.items[index].name;
        var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH + fileName + ".txt");
        var reader = new StreamReader(info.OpenRead());
        string txt = reader.ReadToEnd();
        GameObject textObj = GameObject.Find("Detail_TextText");
        textObj.GetComponent<Text>().text = txt;
        textObj.transform.position = new Vector3(Input.mousePosition.x + 100,Input.mousePosition.y,0);
    }

    public void ClearText() {
        GameObject textObj = GameObject.Find("Detail_TextText");
        textObj.GetComponent<Text>().text = "";
    }

    public void SetIndex(int index) {
        this.index = index;
    }
}
