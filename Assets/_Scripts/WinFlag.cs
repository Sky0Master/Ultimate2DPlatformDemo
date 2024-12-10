using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    public GameObject winUI;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            this.TriggerEvent("Win");
            winUI.SetActive(true);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
