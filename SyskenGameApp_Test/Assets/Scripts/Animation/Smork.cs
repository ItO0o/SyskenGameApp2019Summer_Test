using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smork : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.localScale += new Vector3(0.002f, 0.0004f, 0.002f);
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, this.GetComponent<SpriteRenderer>().color.a - 0.01f);
        if (this.transform.localScale.y > 0.2f) {
            DestroyImmediate(this.gameObject);
        }
    }
}
