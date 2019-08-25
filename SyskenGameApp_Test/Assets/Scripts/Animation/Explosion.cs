using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.localScale += new Vector3(0.01f,0.01f,0.01f);

        this.GetComponent<SpriteRenderer>().color = new Color(1,1,1, this.GetComponent<SpriteRenderer>().color.a - 0.01f);
        if (this.transform.localScale.x > 0.2f) {
            DestroyImmediate(this.gameObject);
        }
    }
}
