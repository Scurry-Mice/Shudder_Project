using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private string quest0 = "Найти хозяина";
    private string quest1 = "Хозяин прижат и не может выбраться, думает о каком то ломе, что это?";
    private string quest2 = "Скорее выйти с хозяином из квартиры!";

    public static bool canEnd;
    
    void Start()
    {
        Observer.stageDone += StageActivated;
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest0;      
    }

    void StageActivated(int stage)
    {
        if (stage == 1)
        {
            GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest1;
        }

        if (stage == 2)
        {
            GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest2;
            Human.AnimHuman.SetTrigger("LomReady");
            Human.canMove = true;
            Human.setFlipVariable();
            canEnd = true;
        }

        if (stage == 3)
        { 
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);     
        }
    }
}
