using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    bool q3 = false;
    internal static bool LOM_IN = false;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float angle;
    private bool isWalkingSideWall;
    public bool flipSprite;


    // Use this for initialization
    void Awake()
    {

        //spriteRenderer = GetComponent<SpriteRenderer>();

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

        Debug.Log(groundNormal.x * 100);
        Debug.Log(isWalkingSideWall);
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

        if (Enter_Collision.gameObject.name == "FINISH_QUEST_1")
        {
            Quests.GO_Q_2();
            Destroy(Enter_Collision.gameObject);
        }

        if (Enter_Collision.gameObject.name == "FINISH_QUEST_2" && LOM_IN)
        {
            Quests.GO_Q_5();
            HUMANOID.AnimHuman.SetTrigger("LomReady");
            Destroy(Enter_Collision.gameObject);
            HUMANOID.fffff = true;
            HUMANOID.sss();
            q3 = true;
        }

        if (Enter_Collision.gameObject.name == "FINISH_QUEST_3")
        {
            if (q3)
            {
                Quests.GO_Q_6();
                Destroy(Enter_Collision.gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }
            
        }
    }

    

}