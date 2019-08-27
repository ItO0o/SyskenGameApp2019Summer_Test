using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMyFuso : MonoBehaviour {
    int tempListLength;
    GameObject myShip;
    private Vector3 tempMousePosition;
    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;
    // Start is called before the first frame update
    void Awake() {
        StaticInfo.myCustom = new List<string>(); 
        GameObject prefab = Resources.Load<GameObject>("Kongo");
        myShip = Instantiate(prefab);
        myShip.name = StaticInfo.playerName;
        //TestCustom();
        UpdateView();
    }

    void Update() {
        if (tempListLength != StaticInfo.myCustom.Count) {
            UpdateView();
            //Debug.Log(myShip.transform.FindChild("CustomParts").transform.childCount);
        }
        tempListLength = StaticInfo.myCustom.Count;
        if (Input.GetMouseButton(0)) {
            SetPosition();
        }

        tempMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    void SetPosition() {
        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        myShip.transform.position += new Vector3(0,screenToWorldPointPosition.y - tempMousePosition.y, 0);
    }

    public void UpdateView() {
        myShip.transform.localPosition = new Vector3(0, -StaticInfo.myCustom.Count, 0);
        float y = 0;
        DestroyImmediate(GameObject.Find(StaticInfo.playerName).transform.Find("CustomParts").gameObject);
        GameObject customParts = new GameObject();
        //customParts.transform.name = "CustomParts";
        //GameObject instParts = Instantiate(customParts);
        customParts.name = "CustomParts";
        for (int i = 0; i < StaticInfo.myCustom.Count; i++) {
            GameObject itemPrefab = Resources.Load<GameObject>(StaticInfo.myCustom[i]);
            Instantiate(itemPrefab, new Vector3(0, y - StaticInfo.myCustom.Count, 0), Quaternion.identity, customParts.transform);
            y += 1;

        }
        customParts.transform.parent = GameObject.Find(StaticInfo.playerName).transform;
    }
}
