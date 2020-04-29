using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FindLom : MonoBehaviour
{
    public static event Action findLomDone = delegate { };
    public GameObject trashWood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Player.hasLom == true)
            {
                Inventory.instance.DestroyObject("LomButton");
                findLomDone();
                trashWood.SetActive(false);
            }
        }
    }
}
