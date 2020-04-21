using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DownloadMenu : MonoBehaviour
{
    
    void DownloadNext()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    
}
