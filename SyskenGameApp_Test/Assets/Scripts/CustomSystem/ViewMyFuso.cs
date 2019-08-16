using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMyFuso : MonoBehaviour {
    int tempListLength;
    GameObject myShip;
    // Start is called before the first frame update
    void Awake() {
        StaticInfo.myCustom = new List<string>(); 
        GameObject prefab = Resources.Load<GameObject>("Kongo");
        myShip = Instantiate(prefab);
        //TestCustom();
        UpdateView();
    }

    // Update is called once per frame
    void Update() {
        if (tempListLength != StaticInfo.myCustom.Count) {
            UpdateView();
        }
        tempListLength = StaticInfo.myCustom.Count;
    
    }

    public void UpdateView() {
        float y = 0;
        DestroyImmediate(GameObject.Find("Kongo(Clone)").transform.FindChild("CustomParts").gameObject);
        GameObject customParts = new GameObject();
        //customParts.transform.name = "CustomParts";
        //GameObject instParts = Instantiate(customParts);
        customParts.name = "CustomParts";
        for (int i = 0; i < StaticInfo.myCustom.Count; i++) {
            GameObject itemPrefab = Resources.Load<GameObject>(StaticInfo.myCustom[i]);
            Instantiate(itemPrefab, new Vector3(0, y, 0), Quaternion.identity, customParts.transform);
            y += 1;

        }
        customParts.transform.parent = GameObject.Find("Kongo(Clone)").transform;
    }
}
