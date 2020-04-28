using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public GameObject itemButton;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Hero_Kitty").GetComponent<Inventory>();
    }

    public void Interact()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(itemButton, inventory.slots[i].transform, false);

                if (gameObject.name == "Lom_Item")
                {
                    Player.hasLom = true;
                }

                if (gameObject.name == "Bind_Item")
                {
                    Player.hasBind = true;
                }

                Destroy(gameObject);
                break;
            }
        }
    }
}
