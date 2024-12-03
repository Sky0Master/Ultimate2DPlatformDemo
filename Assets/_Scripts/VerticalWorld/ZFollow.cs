using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZFollow : MonoBehaviour
{
    public Transform target;
    #if UNITY_EDITOR
    private void OnValidate() {
        if(target != null)
            transform.position = new Vector3(transform.position.x,transform.position.y,target.position.z); 
    }
    #endif
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,target.position.z);    
    }
    
}
