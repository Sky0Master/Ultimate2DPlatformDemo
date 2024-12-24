using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VivianGameFlow : MonoBehaviour
{

    public GameObject beginTalk;

    public GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerObj.SetActive(false);
        beginTalk.SetActive(true);
        beginTalk.GetComponentInChildren<UIImageSwitch>().OnEnd += () =>
        {
            playerObj.SetActive(true);
            beginTalk.SetActive(false);
        };
            
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
