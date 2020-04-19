using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    //типа сглаживание
    public float dumping = 1.5f;
    //размеры смещения камеры относительно персонажа
    public Vector2 offset = new Vector2(2f, 1f);
    //проверка куда смотрит перс       ======= переделать ======      взять из скрипта героя
    public bool isLeft; // = Hero_Control.isFacing;

    //положение персонажа
    private Transform Hero_position;
    //куда смотрит перс
    private int last_X;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindPlayer(bool Hero_is_pos)
    {
        Hero_position = GameObject.FindGameObjectWithTag("").transform;
    }
}
