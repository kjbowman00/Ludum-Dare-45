﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeButtons : MonoBehaviour
{

    public Button button;
    public GameObject level;
    private int upgrade;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public string upgradedItem;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    { 
        Vector2 thisPosition = EventSystem.current.currentSelectedGameObject.GetComponent<Transform>().localPosition;
        if (thisPosition.y > 70F)
        {
            upgrade = 0;
        }
        else if (thisPosition.y > 50)
        {
            upgrade = 1;
        }
        else if (thisPosition.y > 30)
        {
            upgrade = 2;
        }
        else if (thisPosition.y > 0)
        {
            upgrade = 3;
        }
        else if (thisPosition.y > -20)
        {
            upgrade = 4;
        }
        else if (thisPosition.y > -45)
        {
            upgrade = 5;
        }
        else if (thisPosition.y > -80)
        {
            upgrade = 6;
        }
        else if (thisPosition.y > -100)
        {
            upgrade = 7;
        }
        else if (thisPosition.y > -130)
        {
            upgrade = 8;
        }
        Text text = GetComponentInChildren<Text>();

        Debug.Log(upgrade);
        if (text.text.Equals("$100") && UpgradeManager.money >= 100)
        {
            text.text = "$300";
            UpgradeManager.money -= 100;
            level.GetComponent<Image>().sprite = sprite1;
            UpgradeManager.Upgrade(upgrade);
            Debug.Log(UpgradeManager.GetUpgrades()[0]);
        }
        else if (text.text.Equals("$300") && UpgradeManager.money >= 300)
        {
            text.text = "$1000";
            UpgradeManager.money -= 300;
            level.GetComponent<Image>().sprite = sprite2;
            UpgradeManager.Upgrade(upgrade);
        }
        else if (text.text.Equals("$1000") && UpgradeManager.money >= 1000)
        {
            text.text = "Max";
            UpgradeManager.money -= 1000;
            level.GetComponent<Image>().sprite = sprite3;
            UpgradeManager.Upgrade(upgrade);
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
