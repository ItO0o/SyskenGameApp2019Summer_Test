using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSetted : MonoBehaviour
{
    public bool setted = false;
    public bool outOfGanchu = false;

    private void OnCollisionEnter2D(Collision2D collision) {
        setted = true;
    }
}
