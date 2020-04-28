using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public static bool hasLom;
    public static bool hasBind;

    public float maxSpeed = 3;
    public float jumpTakeOffSpeed = 3;

    private bool grounded;
    private Vector2 move;
    private bool isJumping;
    private bool isSecondJumping;

    private List<GameObject> touchingObjects;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb2d;

    public Transform GroundCheck;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        touchingObjects = new List<GameObject>();
    }

    private void Update()
    {
        Inputs();
    }

    
    void FixedUpdate()
    {
        if (isJumping)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpTakeOffSpeed);
            isJumping = false;
        }
        else if (isSecondJumping)
        {
            if (rb2d.velocity.y > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
            }

            isSecondJumping = false;
        }

        rb2d.velocity = new Vector2(move.x, rb2d.velocity.y);

        animator.SetFloat("velocityX", Math.Abs(rb2d.velocity.x));
        animator.SetFloat("velocityY", rb2d.velocity.y);
        animator.SetBool("grounded", grounded);
    }

    public void InteractingWithObjects()
    {
        if (touchingObjects.Count > 0)
        {
            int lastObject = touchingObjects.Count - 1;
            IInteractable interactingObject = touchingObjects[lastObject].GetComponent<IInteractable>();
            interactingObject.Interact();
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractable>() != null)
        {
            if (!touchingObjects.Contains(collision.gameObject))
            {
                touchingObjects.Add(collision.gameObject);
            }
        }

        if (collision.gameObject.name == "DeadZone")
        {
            Level_UI.rest();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (touchingObjects.Contains(collision.gameObject))
        {
            touchingObjects.Remove(collision.gameObject);
        }
    }  

    public void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractingWithObjects();
        }

        if (Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKey("d"))
        {
            move.x = maxSpeed;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a"))
        {
            move.x = -maxSpeed;
            spriteRenderer.flipX = true;
        }
        else
        {
            move.x = 0;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            isJumping = true;
            animator.SetTrigger("takeOf");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            isSecondJumping = true;
        }
    }   
}

