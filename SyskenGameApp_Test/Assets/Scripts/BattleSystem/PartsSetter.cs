using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsSetter : MonoBehaviour
{
    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    InstCustomParts photonCont;
    GameObject now;
    int index = 1;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        photonCont = GameObject.Find("Photon_Controller").GetComponent<InstCustomParts>();
        now = photonCont.parts[index];
        player = GameObject.Find(StaticInfo.playerName);
    }

    // Update is called once per frame
    void Update()
    {
        if (now.GetComponent<CheckSetted>().setted) {
            index++;
            if (index == StaticInfo.myCustom.Count) {
                DestroyImmediate(this.gameObject);
            }
            now = photonCont.parts[index];
            now.transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 5,player.transform.position.z);

        }
        if (Input.GetMouseButton(0)) {
            // Vector3でマウス位置座標を取得する
            position = Input.mousePosition;
            // Z軸修正
            position.z = 10f;
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
            // ワールド座標に変換されたマウス座標を代入
            now.transform.position = new Vector3(screenToWorldPointPosition.x, player.transform.position.y + 5,0);
        }
        if (Input.GetMouseButtonUp(0)) {
            now.AddComponent<Rigidbody2D>();
            
        }
    }
}
