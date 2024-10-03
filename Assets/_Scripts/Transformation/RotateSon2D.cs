using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RotateSon2D : MonoBehaviour
{
    //是否让子节点等距
    public bool isMakeSonUniform = true;
    
    //是否让子节点自转
    public bool isSonRotateSelf = true;


    //每秒旋转角度
    public float rotateSpeed = 10f;

    public float rotateSelfSpeed = 20f;

    public float radius = 2f;
    
    

    void Start()
    {
        if(isMakeSonUniform)
            MakeUniform(TransformExt.GetActiveChildren(transform));
        
    }
    private void OnValidate() {
        if(isMakeSonUniform)
            MakeUniform(TransformExt.GetActiveChildren(transform));
    }
    public void MakeUniform(List<Transform> transList)
    {
        int n = transList.Count;
        for(int i = 0;i < n;i++)
        {
            var angle = i * (360f / n);
            Debug.Log(angle);
            var x = transform.position.x + Mathf.Cos(angle) * radius;
            var y = transform.position.y + Mathf.Sin(angle) * radius;
            transList[i].position = new Vector3(x,y,0); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        var list = TransformExt.GetActiveChildren(transform);
        //transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
        foreach(var t in list)
        {
            t.RotateAround(transform.position , Vector3.forward, rotateSpeed * Time.deltaTime);
            if(isSonRotateSelf)
                t.Rotate(0,0,rotateSelfSpeed * Time.deltaTime);
        }
    }
}
