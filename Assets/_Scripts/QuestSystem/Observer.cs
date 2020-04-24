using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public static event Action<int> stageDone = delegate { };
    public int stage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (stage == 1)
            {
                stageDone(stage);
                this.gameObject.SetActive(false);
            }

            if (stage == 2)
            {
                if (PlayerController.hasLom == true)
                {
                    stageDone(stage);
                    this.gameObject.SetActive(false);
                }
            }

            if (stage == 3 && QuestManager.canEnd == true)
            {
                stageDone(stage);
                this.gameObject.SetActive(false);
            }
        }


    }
}
