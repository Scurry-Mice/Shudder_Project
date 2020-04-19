using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Control : MonoBehaviour
{

    private float Speed = 1;
    private Vector2 moveVelocity;
    private Rigidbody2D Hero_RB_2D;

    // Start is called before the first frame update
    void Start()
    {
        Hero_RB_2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput * Speed;

    }

    private void FixedUpdate()
    {
        Hero_RB_2D.MovePosition(Hero_RB_2D.position + moveVelocity * Time.fixedDeltaTime);
    }

}
