using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[0]);
    }

    void SetIntro2()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[1]);
    }

    void SetIntro3()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[2]);
    }

    void SetIntro4()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[3]);
    }


}
