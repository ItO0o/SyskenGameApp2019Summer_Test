using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourAllow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
            this.transform.position = new Vector3(1000,150,0);
        } else {
            this.transform.position = new Vector3(200, 150, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
