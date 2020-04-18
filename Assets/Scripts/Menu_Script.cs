﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Script : MonoBehaviour
{
    public GameObject Menu_Panel;
    public GameObject Setting_Panel;
    public GameObject Level_panel;
    public GameObject Exit_Panel;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Panel = GameObject.Find("Canvas/Panel_Menu");
        Setting_Panel = GameObject.Find("Canvas/Panel_Settings");
        Level_panel = GameObject.Find("Canvas/Panel_Levels");
        Exit_Panel = GameObject.Find("Canvas/Panel_Menu/Panel_Exit");

        Setting_Panel.SetActive(false);
        Exit_Panel.SetActive(false);
        Level_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Exit_Panel&& Input.GetKeyDown(KeyCode.Escape)|| Setting_Panel&&Input.GetKeyDown(KeyCode.Escape)||Level_panel&& Input.GetKeyDown(KeyCode.Escape))
        {
            Back_To_Menu_Button();
        }
    }

    public void New_Game_button(bool Control)
    {
        if (Control)
        {
            Menu_Panel.SetActive(false);
            Level_panel.SetActive(true);
        }
        else
        {
            Back_To_Menu_Button();
        }
    }

    public void Back_To_Menu_Button()
    {

        Menu_Panel.SetActive(true);

        if (Setting_Panel)
        {
            Setting_Panel.SetActive(false);
        }
        if (Exit_Panel)
        {
            Exit_Panel.SetActive(false);
        }
        if (Level_panel)
        {
            Level_panel.SetActive(false);
        }
    }



}
