using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinoUtility;

public class DontDestroyChildren : MonoBehaviour
{
   private void Awake() {
      var go = GameObject.FindObjectOfType<DontDestroyChildren>();
      if(go != this) 
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(this.gameObject);
   }
}
