using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{

    private float moveSpeed = 3f;

    void Update()
    {
        Move();
    }

    //squirrel jalan maju
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

   void OnCollisionEnter2D(Collision2D target)
    {   //squirrel maju mundur
        if (target.gameObject.tag == "SideBound")
        {
            moveSpeed *= -1f;

            //squirrel bisa balik
            Vector3 temp = transform.localScale;
            temp.x *= -1f;
            transform.localScale = temp;
        }
    }

} // class















































