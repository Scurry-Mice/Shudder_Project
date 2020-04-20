using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUS_lvl_2 : MonoBehaviour
{
    [SerializeField] private float Patrul_A;
    [SerializeField] private float Patrul_B;

    [SerializeField] private float Tek_pos_X;

    [SerializeField] private float Gus_Move;
    [SerializeField] private float Gus_maxSpeed = 2f;

    //направление движения гуся
    [SerializeField]  bool Gus_isFacing; // -> true / <- false

    //ссылки на компоненты гуся
    private Rigidbody2D RBody_Gus;
    private Animator Gus_anim_control; 

    // Start is called before the first frame update
    void Start()
    {
        RBody_Gus = GetComponent<Rigidbody2D>();
        Gus_anim_control = GetComponent<Animator>();

        Tek_pos_X = RBody_Gus.velocity.x;

        Gus_isFacing = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D Enter_Collision)
    {
        if (Enter_Collision.gameObject.name == "Patrul_A")
        {
            Flip();
        }
        if (Enter_Collision.gameObject.name == "Patrul_B")
        {
            Flip();
        }


    }

    private void FixedUpdate()
    {
        if (Gus_isFacing)
        {
            //+ ->
            Gus_Move = 1;
            RBody_Gus.velocity = new Vector2(Gus_Move * Gus_maxSpeed, RBody_Gus.velocity.y);
        }

        if (!Gus_isFacing)
        {
            //- <-
            Gus_Move = -1;
            RBody_Gus.velocity = new Vector2(Gus_Move * Gus_maxSpeed, RBody_Gus.velocity.y);
        }
    }

    // Метод для смены направления движения и его зеркального отражения
    private void Flip()
    {
        //меняем направление движения персонажа
        Gus_isFacing = !Gus_isFacing;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

}
