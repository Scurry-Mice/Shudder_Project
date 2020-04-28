using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luke : MonoBehaviour, IInteractable
{
    public Transform LukeRef;
    public bool canMove;
    public bool onDestroy;
    public Vector3 newPos;

    private void FixedUpdate()
    {
        if (canMove)
        {
            LukeRef.transform.position = Vector3.Lerp(LukeRef.transform.position, newPos, 5 * Time.deltaTime);
        }
    }

    public void Interact()
    {
        if (onDestroy == false)
        {
            canMove = true;
            newPos = new Vector3(LukeRef.transform.position.x, LukeRef.transform.position.y - 1.8f, LukeRef.transform.position.z);
            onDestroy = true;
        }
    }
}
