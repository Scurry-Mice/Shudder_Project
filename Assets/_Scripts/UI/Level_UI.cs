using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_UI : MonoBehaviour
{
    // PAUSE
    [SerializeField] private GameObject Pause_Panel;
    internal static GameObject Panel_RESTART;

    //Notes
    [SerializeField] internal static GameObject Panel_Zapisok;
    [SerializeField] internal static bool Bool_Notepad = false;
    [SerializeField] internal static bool Bool_PauseActive = false;

    // UI
    [SerializeField] private GameObject UI_Panel;

    // Start is called before the first frame update
    void Start()
    {
        //получаем GO на старте.
        Pause_Panel = GameObject.Find("Canvas/Pause_Panel");

        Panel_Zapisok = GameObject.Find("Canvas/NotePad");
        Panel_RESTART = GameObject.Find("Canvas/Panel_Restart");

        UI_Panel = GameObject.Find("Canvas/Panel_UI");
       
        Pause_Panel.SetActive(false);
       
        Panel_RESTART.SetActive(false);

        Panel_Zapisok.SetActive(false);       
    }

    

    internal static void rest()
    {
        Panel_RESTART.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Bool_Notepad)
        {
            Pause_Panel.SetActive(!Bool_PauseActive);
            UI_Panel.SetActive(Bool_PauseActive);
            Bool_PauseActive = !Bool_PauseActive;
        }

        if (Panel_Zapisok && Input.GetKeyDown(KeyCode.Escape))
        {
            Panel_Zapisok.SetActive(false);
            Bool_Notepad = false;
        }

       
    }

    internal static string Find_Notes_TXT(string Text)
    {
        string TEXT = GameObject.Find("Canvas/NotePad/Text").GetComponent<Text>().text = Text;

        return TEXT;
    }

    public void ContinueGame()
    {
        Pause_Panel.SetActive(false);
        UI_Panel.SetActive(true);
        Bool_PauseActive = false;
    }

    //выход в меню
    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        if (Panel_RESTART)
        {
            Panel_RESTART.SetActive(false);
        }
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
