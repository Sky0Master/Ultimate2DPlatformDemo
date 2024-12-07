using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent event1;
    public UnityEvent event2; 
    public void Event1()
    {
        event1?.Invoke();
    }
    public void Event2()
    {
        event2?.Invoke();
    }
}
