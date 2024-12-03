using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinoUtility;

public class Dash2D : MonoBehaviour
{
    public float dashCoolTime = 0.5f;
    public float dashDistance = 2f;
    public float dashDuration = 0.1f;

    private float _lastDashTime;
    private Vector2 _lastPos;

    public MonoBehaviour moveScript;
    public void OnDashUpdate(Vector2 curPos)
    {
        transform.position = curPos;
    }
    public void OnDashComplete()
    {
        moveScript.enabled = true;
    }
    public void Dash(Vector2 direction)
    {
        if(Time.time - _lastDashTime < dashCoolTime)
        {
            return;
        }
        var stPos = (Vector2)transform.position;
        var endPos = stPos + direction * dashDistance;
        StartCoroutine(LerpUtility.LerpPhysics(stPos,endPos,dashDuration,OnDashUpdate,OnDashComplete));
        moveScript.enabled = false;
        _lastDashTime = Time.time;
        _lastPos = stPos;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            var dir = transform.GetMouseVector2().normalized;
            Dash(dir);
        }
    }
}
