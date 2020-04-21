using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownloadMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
   

    void DownloadNext()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    void SetIntro1()
    {
        string text = "«Всегда что-то происходит первый раз…»";
        string TEXT = GameObject.Find("Canvas/Text").GetComponent<Text>().text = text;

        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[0]);
    }

    void SetIntro2()
    {
        string text = "«Именно поэтому, никто не ожидал землетрясения в центре России!»";
        string TEXT = GameObject.Find("Canvas/Text").GetComponent<Text>().text = text;

        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[1]);        
    }

    void SetIntro3()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[2]);
    }

    void SetIntro4()
    {
        string TEXT = GameObject.Find("Canvas/Text").GetComponent<Text>().text = null;

        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[3]);
    }


}
