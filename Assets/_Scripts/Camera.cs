using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //типа сглаживание
    public float dumping = 2.5f;
    //размеры смещения камеры относительно персонажа
    public Vector2 offset = new Vector2(0f, 1.5f);

    //положение персонажа
    private Transform Hero_position;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(!Hero_Control.isFacing);
    }

    // Update is called once per frame
    void Update()
    {
        if (Hero_position)
        {
           Vector3 target;

            if (Hero_Control.isFacing)
            {
                target = new Vector3(Hero_position.position.x + offset.x, Hero_position.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(Hero_position.position.x - offset.x, Hero_position.position.y + offset.y, transform.position.z);
            }

            Vector3 CurrentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = CurrentPosition;
        }

    }

    void FindPlayer(bool Hero_is_pos)
    {
        Hero_position = GameObject.FindGameObjectWithTag("Hero_Kitty").transform;

        if(Hero_is_pos)
        {
            transform.position = new Vector3(Hero_position.position.x - offset.x, Hero_position.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Hero_position.position.x + offset.x, Hero_position.position.y + offset.y, transform.position.z);
        }
    }
}
