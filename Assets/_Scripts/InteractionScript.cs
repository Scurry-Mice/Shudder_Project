using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public Transform LukeRef;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero_Kitty")
        {
            foreach (Transform eachChild in transform)
            {
                if (eachChild.name == "Luke")
                {
                    eachChild.Translate(-2, 0, 0);
                }
            }
        }
    }
    
}
