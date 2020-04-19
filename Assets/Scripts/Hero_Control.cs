using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Control : MonoBehaviour
{

    //переменная для установки макс. скорости персонажа
    private float maxSpeed = 2f;
    private Vector2 moveVelocity;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;

    //ссылки на компонент анимаций и физику
    private Rigidbody2D Hero_RB_2D;
    private Animator Hero_Anim_Contr;


    // Start is called before the first frame update
    void Start()
    {
        Hero_RB_2D = GetComponent<Rigidbody2D>();
        Hero_Anim_Contr = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //moveVelocity = moveInput * maxSpeed;

    }

    /// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
    /// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
    private void FixedUpdate()
    {
        //используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        float moveInput = Input.GetAxis("Horizontal");

        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
        Hero_Anim_Contr.SetFloat("speed_anim", Mathf.Abs(moveInput));

        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        Hero_RB_2D.velocity = new Vector2(moveInput * maxSpeed, Hero_RB_2D.velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if (moveInput > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (moveInput < 0 && isFacingRight)
            Flip();

        //Hero_RB_2D.MovePosition(Hero_RB_2D.position + moveVelocity * Time.fixedDeltaTime);
    }

    // Метод для смены направления движения персонажа и его зеркального отражения
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
    
}
