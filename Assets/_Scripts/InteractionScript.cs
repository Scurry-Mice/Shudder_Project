using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public Transform LukeRef;
    public bool canMove;
    public bool onDestroy;
    public Vector3 newPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero_Kitty")
        {
            if (onDestroy == false)
            {
                canMove = true;
                newPos = new Vector3(LukeRef.transform.position.x, LukeRef.transform.position.y - 1.8f, LukeRef.transform.position.z);
                onDestroy = true;
            }        
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            LukeRef.transform.position = Vector3.Lerp(LukeRef.transform.position, newPos, 5 * Time.deltaTime);
        }
    }

}
