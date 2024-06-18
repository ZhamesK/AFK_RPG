using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button MenuBttn;
    public Button InfoBtn;
    public Button QuestBtn;
    public Button SettingBtn;

    public GameObject MenuList;
    public GameObject InfoList;
    public GameObject QuestList;
    public GameObject SettingList;

    // Start is called before the first frame update
    void Start()
    {
        MenuBttn.onClick.AddListener(OpenMenuList);
        InfoBtn.onClick.AddListener(OpenInfoList);
        QuestBtn.onClick.AddListener(OpenQuestList);
        SettingBtn.onClick.AddListener(OpenSettingList);
    }

    private void OpenSettingList()
    {
        SettingList.SetActive(true);
    }

    private void OpenQuestList()
    {
        QuestList.SetActive(true);
    }

    private void OpenInfoList()
    {
        InfoList.SetActive(true);
    }

    void OpenMenuList()
    {
        MenuList.SetActive(true);
    }
}
