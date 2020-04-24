using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public static PlayerController instance;

    bool q3 = false;
    public static bool hasLom = false;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float angle;
    private bool isWalkingSideWall;
    public bool flipSprite;

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

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            animator.SetTrigger("takeOf");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }    

        if (Mathf.Abs(move.x) >= 0.01f)
        {
           flipSprite  = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        }

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

        if (groundNormal.x * 100 > 0)
        {
            angle = (groundNormal.x * (-100)) + 15;
        }
        else
        {
            angle = (groundNormal.x * (-100)) - 15;
        }
        
        if (grounded == false || !isWalkingSideWall)
        {
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (angle != 0 && grounded == true && isWalkingSideWall == true)
        {
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SideWall"))
        {
            isWalkingSideWall = true;
        }
        else
        {
            isWalkingSideWall = false;
        }
    }

    void OnTriggerEnter2D(Collider2D Enter_Collision)
    {
        if (Enter_Collision.gameObject.name == "DeadZone")
        {
            Level_UI.rest();
        }

        if (Enter_Collision.gameObject.name == "Quest1End")
        {
            Quests.RunQuest2();
            Destroy(Enter_Collision.gameObject);
        }

        if (Enter_Collision.gameObject.name == "Quest2End" && hasLom)
        {
            Quests.RunQuest3();
            Human.AnimHuman.SetTrigger("LomReady");
            Destroy(Enter_Collision.gameObject);
            Human.canMove = true;
            Human.setFlipVariable();
            q3 = true;
        }

        if (Enter_Collision.gameObject.name == "Quest3End")
        {
            if (q3)
            {
                Destroy(Enter_Collision.gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }
            
        }
    }

    

}