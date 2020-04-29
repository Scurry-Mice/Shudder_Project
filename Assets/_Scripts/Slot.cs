using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Hero_Kitty").GetComponent<Inventory>();
    }

    void Update()
    {
        
    }

    public void DestroyObject()
    {

    }
}
