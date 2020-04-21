using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_UI : MonoBehaviour
{
    // PAUSE
    [SerializeField] private GameObject Pause_Panel;
    [SerializeField] private GameObject Pause_Button_Panel_GO;
    [SerializeField] private GameObject Back_Menu_Panel_GO;
    [SerializeField] private GameObject Exit_Game_Panel_GO;
    [SerializeField] private GameObject Panel_Setting_LVL;
    internal static GameObject Panel_RESTART;

    [SerializeField] internal static GameObject Panel_Zapisok;
    [SerializeField] internal static bool Bool_Notepad = false;

    // UI
    [SerializeField] private GameObject UI_Panel;
    [SerializeField] private GameObject Help_Panel;

    // Start is called before the first frame update
    void Start()
    {
        //получаем GO на старте.
        Pause_Panel = GameObject.Find("Canvas/Panel_Pause");
        Pause_Button_Panel_GO = GameObject.Find("Canvas/Panel_Pause/Pause_Button_Panel");
        Back_Menu_Panel_GO = GameObject.Find("Canvas/Panel_Pause/Back_Menu_Panel");
        Exit_Game_Panel_GO = GameObject.Find("Canvas/Panel_Pause/Exit_Game_Panel");
        Panel_Setting_LVL = GameObject.Find("Canvas/Panel_Pause/Panel_Setting");

        Panel_Zapisok = GameObject.Find("Canvas/NotePad");
        Panel_RESTART = GameObject.Find("Canvas/Panel_Restart");

        UI_Panel = GameObject.Find("Canvas/Panel_UI");
        Help_Panel = GameObject.Find("Canvas/Panel_UI/Panel_Help");

        Pause_Button_Panel_GO.SetActive(false);
        Pause_Panel.SetActive(false);
        Back_Menu_Panel_GO.SetActive(false);
        Exit_Game_Panel_GO.SetActive(false);
        Panel_Setting_LVL.SetActive(false);

        Panel_RESTART.SetActive(false);

        Help_Panel.SetActive(false);

        Panel_Zapisok.SetActive(false);
        
    }

    

    internal static void rest()
    {
        Panel_RESTART.SetActive(true);
    }

    /*
    private void LateUpdate()
    {
        if (!Panel_Zapisok)
        {
            Debug.Log("TEST");
        }

        if (Bool_Notepad)
        {
            Debug.Log("!!!!!!!!!!!!!!!!");
        }
        else
        {
            Debug.Log("________________");
        }

        //Bool_Notepad = Panel_Zapisok;
    }
    */


    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Panel_Zapisok.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Panel_Zapisok.SetActive(false);
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape) && !Bool_Notepad/* && !Panel_Zapisok*/)
        {
            Pause_Button_Panel_GO.SetActive(true);
            Pause_Panel.SetActive(true);
            UI_Panel.SetActive(false);

        }

        if (Panel_Zapisok && Input.GetKeyDown(KeyCode.Escape))
        {
            Panel_Zapisok.SetActive(false);
            Bool_Notepad = false;
        }

        if (Pause_Button_Panel_GO && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_Button_Panel_GO.SetActive(true);
            Exit_Game_Panel_GO.SetActive(false);
        }

        if (Panel_Setting_LVL&& Input.GetKeyDown(KeyCode.Escape))
        {
            Panel_Setting_LVL.SetActive(false);
            Pause_Button_Panel_GO.SetActive(true);
        }

        
    }

    public void Button_Setting_panel()
    {
        Panel_Setting_LVL.SetActive(true);
        Pause_Button_Panel_GO.SetActive(false);
    }

    internal static string Find_Notes_TXT(string Text)
    {
        string TEXT = GameObject.Find("Canvas/NotePad/Text").GetComponent<Text>().text = Text;

        return TEXT;
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
        if (Panel_RESTART)
        {
            Panel_RESTART.SetActive(false);
        }
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

    public void RESTART ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        if (Panel_RESTART)
        {
            Panel_RESTART.SetActive(false);
        }
    }

}
