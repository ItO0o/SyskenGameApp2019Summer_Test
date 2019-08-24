using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    GameObject sliderObj;
    Slider slider;
    Image fill;
    Image back;
    GameObject myShip;
    int tempHP;
    // Start is called before the first frame update
    void Start()
    {
        sliderObj = GameObject.Find("HP_Slider");
        fill = sliderObj.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        slider = sliderObj.GetComponent<Slider>();
        myShip = GameObject.Find(StaticInfo.playerName);
        back = sliderObj.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempHP > myShip.GetComponent<PlayerBattleStatus>().hp)
        {
            Damaged();
        }
        else  if(back.color == Color.red)
        {
            SetWhite();
        }
        SetSlider();
        tempHP = myShip.GetComponent<PlayerBattleStatus>().hp;
    }

    void SetSlider()
    {
        slider.value = myShip.GetComponent<PlayerBattleStatus>().hp / myShip.GetComponent<PlayerBattleStatus>().maxHP;
        Color fillColor = new Color(1 - slider.value,slider.value, 0);
        fill.color = fillColor;
    }
    void Damaged()
    {
        Color fillColor = Color.red;
        back.color = fillColor;
    }
    void SetWhite()
    {
        Color fillColor = Color.white;
        back.color = fillColor;
    }
}
