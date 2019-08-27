using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InstCustomParts : MonoBehaviour {
    public List<GameObject> parts;
    // Start is called before the first frame update
    void Start() {
        GameObject player = GameObject.Find(StaticInfo.playerName);
        GameObject partsObj = player.transform.Find("CustomParts").gameObject;
        LocalInventory li = new LocalInventory();
        li.Load();
        float y = 0;
        foreach (string s in StaticInfo.myCustom) {
            GameObject instParts;
            if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
                instParts = PhotonNetwork.Instantiate(s, new Vector3(player.transform.position.x, player.transform.position.y + y + 100, 0), new Quaternion(0, 0, 0, 0));
                instParts.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
                instParts.transform.parent = partsObj.transform;
            } else {
                instParts = PhotonNetwork.Instantiate(s, new Vector3(player.transform.position.x, player.transform.position.y + y + 100, 0), new Quaternion(0, 0, 0, 0));
                instParts.transform.parent = partsObj.transform;
            }
            //Debug.Log(instParts.transform.localRotation);
            //instParts.transform.parent = player.transform.Find("CustomParts").transform;
            try {
                DestroyImmediate(instParts.GetComponent<Rigidbody2D>());
            } catch {

            }
            parts.Add(instParts);
            y++;
        }
    }
}
