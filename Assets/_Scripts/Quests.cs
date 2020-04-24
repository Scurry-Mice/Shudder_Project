using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    internal static readonly string quest1 = "Найти хозяина";
    internal static readonly string quest2 = "Хозяин прижат и не может выбраться, думает о каком то ломе, что это?"; // Найти и принести лом.
    internal static readonly string quest3 = "Хозяин слишком сильно ранен, он не хочет зализывать раны..."; // Найти и принести: бинт, спирт
    internal static readonly string quest4 = "Хозяин выглядит голодным, миска воды и сосиска помогут ему!"; //  Найти и принести: бутылку воды, сосиску
    internal static readonly string quest5 = "Скорее выйти с хозяином из квартиры!";
    internal static readonly string quest6 = "";


    // Start is called before the first frame update
    void Start()
    {
        Quests.RunQuest1();
    }

    internal static void RunQuest1()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest1;
    }

    internal static void RunQuest2()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest2;
    }

    internal static void RunQuest3()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = quest5;
    }
}
