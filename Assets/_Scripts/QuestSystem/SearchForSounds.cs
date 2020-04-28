using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SearchForSounds : MonoBehaviour
{
    public static event Action searchForSoundsDone = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            searchForSoundsDone();
        }
    }
}
