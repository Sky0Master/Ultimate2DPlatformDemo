using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan2D : MonoBehaviour
{
    private List<Rigidbody2D> inAreaObjects;
    public float force = 5f;

    private void Start()
    {
        inAreaObjects = new List<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rig = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rig != null)
        {
            inAreaObjects.Add(rig);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var rig = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rig != null)
            inAreaObjects.Remove(rig);
    }
    private void FixedUpdate()
    {
        foreach(var rig in inAreaObjects)
        {
            //让所有在范围内的物体向上移动
            
            rig.transform.Translate(transform.up * force * Time.fixedDeltaTime);
        }
    }
}
