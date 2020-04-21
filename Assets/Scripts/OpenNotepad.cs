using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNotepad : MonoBehaviour
{
    public void SetActiveNotepad()
    {
        Level_UI.Panel_Zapisok.SetActive(true);
        
    }
}
