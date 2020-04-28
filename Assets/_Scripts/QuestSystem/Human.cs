using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public static Human instance;

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
      
    public static bool timeToFlip = false;
    public static bool canMove = false;
    public static Animator AnimHuman;

    private Rigidbody2D rb;
    private float speed = 2f;

    void Start()
    {
        AnimHuman = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            if (timeToFlip)
            {
                Flip();
                timeToFlip = false;
            }
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    internal static void setFlipVariable()
    {
        timeToFlip = true;
    }

    void Flip()
    {
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
}
