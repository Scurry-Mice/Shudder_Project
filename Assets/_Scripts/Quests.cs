﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    internal static readonly string Quest_1 = "Найти хозяина";
    internal static readonly string Quest_2 = "Хозяин прижат и не может выбраться, думает о каком то ломе, что это?"; // Найти и принести лом.
    internal static readonly string Quest_3 = "Хозяин слишком сильно ранен, он не хочет зализывать раны..."; // Найти и принести: бинт, спирт
    internal static readonly string Quest_4 = "Хозяин выглядит голодным, миска воды и сосиска помогут ему!"; //  Найти и принести: бутылку воды, сосиску
    internal static readonly string Quest_5 = "Скорее выйти с хозяином из квартиры!";
    internal static readonly string Quest_6 = "";


    // Start is called before the first frame update
    void Start()
    {

    }

    internal static void GO_Q_1()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = Quest_1;
    }

    internal static void GO_Q_2()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = Quest_2;
    }

    internal static void GO_Q_5()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = Quest_5;
    }

    internal static void GO_Q_6()
    {
        GameObject.Find("Canvas/Panel_UI/QuestName/QuestText").GetComponent<Text>().text = Quest_6;
    }
}