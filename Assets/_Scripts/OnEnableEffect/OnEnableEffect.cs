using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableEffect : MonoBehaviour
{


    virtual public void TakeEffect()
    {

    }

    protected void OnEnable() {
        TakeEffect();
    }

    void Update()
    {
        
    }
}
