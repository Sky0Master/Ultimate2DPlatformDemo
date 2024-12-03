using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchTrigger2D : MonoBehaviour
{

    public UnityEvent touchEvent;
    public UnityEvent exitEvent;
    int counter = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rig = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rig != null)
        {
            counter++;
            touchEvent?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var rig = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rig != null)
        {
            counter--;
            if(counter == 0)
                exitEvent?.Invoke();
        }
    }
}
