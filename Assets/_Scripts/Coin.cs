using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public string coinType = "Coin";

    public virtual void OnCollected()
    {
        Destroy(gameObject);
    }
    
}
