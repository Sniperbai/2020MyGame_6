using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float misSpeed = 5;

    private SpriteRenderer render;
    public Sprite hurt;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)//直接死亡
        {
            Destroy(gameObject);
        }
        else if(collision.relativeVelocity.magnitude > misSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;
        }
    }
}
