using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    private readonly string Quest_1 = "Найти хозяина";
    private readonly string Quest_2 = "Хозяин прижат и не может выбраться, думает о каком то ломе, что это?"; // Найти и принести лом.
    private readonly string Quest_3 = "Хозяин слишком сильно ранен, он не хочет зализывать раны..."; // Найти и принести: бинт, спирт
    private readonly string Quest_4 = "Хозяин выглядит голодным, миска воды и сосиска помогут ему!"; //  Найти и принести: бутылку воды, сосиску



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameObject.Find("Canvas/Panel_UI/Text_quest").GetComponent<Text>().text = Quest_1;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject.Find("Canvas/Panel_UI/Text_quest").GetComponent<Text>().text = Quest_2;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject.Find("Canvas/Panel_UI/Text_quest").GetComponent<Text>().text = Quest_3;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject.Find("Canvas/Panel_UI/Text_quest").GetComponent<Text>().text = Quest_4;
        }
    }
}
