using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OECameraFocus : OnEnableEffect
{

    public float switchDuration = 2f;
    public float focusDuration = 5f;
    public float zoomSize = 3f;
    public bool isFollowWhenFocus = true;
    public override void TakeEffect()
    {
        Camera.main.GetComponent<CameraFollow>().FocusOnForTime(transform,switchDuration,focusDuration,zoomSize,isFollowWhenFocus);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
