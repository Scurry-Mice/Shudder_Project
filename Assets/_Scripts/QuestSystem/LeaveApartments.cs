using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeaveApartments : MonoBehaviour
{
    public static event Action leaveApartmentsDone = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            leaveApartmentsDone();
        }
    }
}

