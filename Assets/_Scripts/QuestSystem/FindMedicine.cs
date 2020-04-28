using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FindMedicine : MonoBehaviour
{
    public static event Action findMedicineDone = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Player.hasBind)
            {
                findMedicineDone();
            }
        }
    }
}
