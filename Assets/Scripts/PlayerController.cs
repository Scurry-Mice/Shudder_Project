using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    bool q3 = false;
    internal static bool LOM_IN = false;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

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