using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public bool[] isFull;
    public GameObject[] slots;

    private GameObject itemButton;
    private GameObject itemSlot;

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (slots[i].transform.childCount <= 0)
            {
                isFull[i] = false;
            }
        }
    }

    public void DestroyObject(string buttonName)
    {
        itemButton = GameObject.FindGameObjectWithTag(buttonName);
        itemSlot = itemButton.transform.parent.gameObject;

        foreach (GameObject i in slots)
        {
            if (i == itemSlot)
            {
                foreach (Transform child in i.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                
            }
        }
    }
}
