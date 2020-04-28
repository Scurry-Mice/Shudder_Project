using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHuman : MonoBehaviour
{
    public static event Action findHumanDone = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            findHumanDone();
        }
    }
}
