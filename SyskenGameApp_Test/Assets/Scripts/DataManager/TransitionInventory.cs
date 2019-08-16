using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionInventory : MonoBehaviour
{
    public void InitInventory() {
        StaticInfo.items = new List<Item>();
    }

}

