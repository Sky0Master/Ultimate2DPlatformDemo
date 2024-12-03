using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{

    public float duration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.DORotate(new Vector3(0,-90f,0),duration);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            transform.DORotate(new Vector3(0,0,0),duration);
        }
    }
}
