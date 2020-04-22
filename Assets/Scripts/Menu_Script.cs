using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Script : MonoBehaviour
{
    public GameObject Menu_Panel;
    public GameObject Setting_Panel;
    public GameObject Level_Panel;
    [SerializeField] private GameObject Autors_Panel;
    public GameObject Exit_Panel;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Panel = GameObject.Find("Canvas/Panel_Menu");
        Setting_Panel = GameObject.Find("Canvas/Panel_Settings");
        Autors_Panel = GameObject.Find("Canvas/Panel_Autors");

        Setting_Panel.SetActive(false);
        Autors_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Setting_Panel && Input.GetKeyDown(KeyCode.Escape) || Level_Panel && Input.GetKeyDown(KeyCode.Escape) || Autors_Panel && Input.GetKeyDown(KeyCode.Escape))
        {
            Back_To_Menu_Button();
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Back_To_Menu_Button()
    {

        Menu_Panel.SetActive(true);

        if (Setting_Panel)
        {
            Setting_Panel.SetActive(false);
        }
   
        if (Autors_Panel)
        {
            Autors_Panel.SetActive(false);
        }

    }

    public void Autors_panel()
    {
        Autors_Panel.SetActive(true);
        Menu_Panel.SetActive(false);
    }


    public void Settings_Button()
    {
        Menu_Panel.SetActive(false);
        Setting_Panel.SetActive(true);
    }

    // кнопка выхода
    public void Exit_Button()
    {
        Application.Quit();
    }

}
