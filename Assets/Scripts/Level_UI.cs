﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_UI : MonoBehaviour
{
    // PAUSE
    public GameObject Pause_Panel;
    public GameObject Pause_Button_Panel_GO;
    public GameObject Back_Menu_Panel_GO;
    public GameObject Exit_Game_Panel_GO;

    //Notepad
    public static GameObject Notepad_Panel;
    private bool isShowed = false;

    // UI
    public GameObject UI_Panel;

    // Start is called before the first frame update
    void Start()
    {
        //получаем GO на старте.
        Pause_Panel = GameObject.Find("Canvas/Panel_Pause");
        Pause_Button_Panel_GO = GameObject.Find("Canvas/Panel_Pause/Pause_Button_Panel");
        Back_Menu_Panel_GO = GameObject.Find("Canvas/Panel_Pause/Back_Menu_Panel");
        Exit_Game_Panel_GO = GameObject.Find("Canvas/Panel_Pause/Exit_Game_Panel");

        UI_Panel = GameObject.Find("Canvas/Panel_UI");

        Pause_Button_Panel_GO.SetActive(false);
        Pause_Panel.SetActive(false);
        Back_Menu_Panel_GO.SetActive(false);
        Exit_Game_Panel_GO.SetActive(false);

        Notepad_Panel = GameObject.Find("Canvas/Notepad");

        Notepad_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isShowed = !isShowed;
            Notepad_Panel.SetActive(isShowed);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_Button_Panel_GO.SetActive(true);
            Pause_Panel.SetActive(true);
            UI_Panel.SetActive(false);
        }
        
    }
    
    public void Exit_Button_Panel()
    {
        Pause_Button_Panel_GO.SetActive(false);
        Exit_Game_Panel_GO.SetActive(true);
    }

    public void Back_Button()
    {
        Pause_Button_Panel_GO.SetActive(false);
        Pause_Panel.SetActive(false);
        UI_Panel.SetActive(true);
    }

    public void Back_to_Menu_panel()
    {
        Pause_Button_Panel_GO.SetActive(false);
        Back_Menu_Panel_GO.SetActive(true);
    }

    //выход в меню
    public void Back_Yes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Back_No()
    {
        Pause_Button_Panel_GO.SetActive(true);
        Back_Menu_Panel_GO.SetActive(false);
        Exit_Game_Panel_GO.SetActive(false);
    }

    // кнопка подтверждения выхода (Yes)
    public void Exit_Button()
    {
        Application.Quit();
    }



}
