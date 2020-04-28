using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorSecond : MonoBehaviour, IInteractable
{
    public GameObject openDoor;
    public GameObject closeDoor;

    void Start()
    {
        openDoor.SetActive(false);
        closeDoor.SetActive(true);
    }

    public void Interact()
    {
        if (Player.hasSK)
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());

            openDoor.SetActive(true);
            closeDoor.SetActive(false);
        }
    }
}
