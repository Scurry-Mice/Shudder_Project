using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUMANOID : MonoBehaviour
{
    internal static bool ttt = false;
    internal static bool fffff = false;

    internal static Animator AnimHuman;

    private Rigidbody2D RBody_Hum;

    [SerializeField] private float HUM_Move;
    [SerializeField] private float Hum_maxSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        AnimHuman = GetComponent<Animator>();
        RBody_Hum = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fffff)
        {
            if (ttt)
            {
                Flip();
                ttt = false;

            }
            //Flip();
            float Gus_Move = -1;
            RBody_Hum.velocity = new Vector2(Gus_Move * Hum_maxSpeed, RBody_Hum.velocity.y);
        }
    }

    internal static void sss()
    {
        ttt = true;
    }

    void Flip()
    {
        //меняем направление движения персонажа
        //isFacing = !isFacing;
        //получаем размеры персонажа
        Vector3 theScale =  transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
}
