using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class OESetVelocity : OnEnableEffect
{
    public Vector2 direction = Vector2.right;
    public float speed = 1f;
    public override void TakeEffect()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
