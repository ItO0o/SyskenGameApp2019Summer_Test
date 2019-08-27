using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour {
    GameObject[] sliderObj = new GameObject[2];
    Slider[] slider = new Slider[2];
    Image[] fill = new Image[2];
    Image[] back = new Image[2];
    GameObject[] ship = new GameObject[2];
    int[] tempHP = new int[2];
    GameObject canvas;
    // Start is called before the first frame update
    void Start() {
        sliderObj[0] = GameObject.Find("HP_Slider");
        ship[0] = GameObject.Find(StaticInfo.playerName);

        sliderObj[1] = GameObject.Find("Enemy_HP_Slider");
        ship[1] = GameObject.Find("Kongo(Clone)");

        canvas = GameObject.Find("Canvas");

        for (int i = 0; i < 2; i++) {
            fill[i] = sliderObj[i].transform.GetChild(1).GetChild(0).GetComponent<Image>();
            slider[i] = sliderObj[i].GetComponent<Slider>();
            back[i] = sliderObj[i].transform.GetChild(0).GetComponent<Image>();
        }
       
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < 2; i++) {
            if (tempHP[i] > ship[i].GetComponent<PlayerBattleStatus>().hp) {
                Damaged(i);
            } else if (back[i].color == Color.red) {
                SetWhite(i);
            }
            SetSlider(i);
            tempHP[i] = ship[i].GetComponent<PlayerBattleStatus>().hp;
        }
        //if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
        //    sliderObj[0].transform.position = Camera.main.WorldToScreenPoint(new Vector3(ship[0].transform.position.x - 10, ship[0].transform.position.y + 5, 0));
        //    sliderObj[1].transform.position = Camera.main.WorldToScreenPoint(new Vector3(ship[1].transform.position.x + 10, ship[1].transform.position.y + 5, 0));
        //} else {
        //    sliderObj[0].transform.position = Camera.main.WorldToScreenPoint(new Vector3(ship[0].transform.position.x + 10, ship[0].transform.position.y + 5, 0));
        //    sliderObj[1].transform.position = Camera.main.WorldToScreenPoint(new Vector3(ship[1].transform.position.x - 10, ship[1].transform.position.y + 5, 0));
        //}
    }

    void SetSlider(int index) {
        //slider.value = 0.5f;
        slider[index].value = (float)ship[index].GetComponent<PlayerBattleStatus>().hp / (float)ship[index].GetComponent<PlayerBattleStatus>().maxHP;
        Color fillColor = new Color(1 - slider[index].value, slider[index].value, 0);
        fill[index].color = fillColor;
    }
    void Damaged(int index) {
        Color fillColor = Color.red;
        back[index].color = fillColor;
    }
    void SetWhite(int index) {
        Color fillColor = Color.white;
        back[index].color = fillColor;
    }
}
