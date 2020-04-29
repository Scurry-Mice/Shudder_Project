using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour, IInteractable
{
    public GameObject openDoor;
    public GameObject closeDoor;
    private GameObject goldenKeyItem;
    private Inventory inventory;
    private Slot parentSlot;

    void Start()
    {
        openDoor.SetActive(false);
        closeDoor.SetActive(true);

        inventory = GameObject.FindGameObjectWithTag("Hero_Kitty").GetComponent<Inventory>();
    }

    public void Interact()
    {
        if (Player.hasGK)
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());

            Inventory.instance.DestroyObject("GoldenKeyButton");
            Player.hasGK = false;
          
            openDoor.SetActive(true);
            closeDoor.SetActive(false);
        }
    }
}
