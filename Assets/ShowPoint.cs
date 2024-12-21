using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPoint : MonoBehaviour
{
    TextMeshProUGUI pointText;
    
    private void Start() {
        pointText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        pointText.text = "Score: " + CoinCollector.curPoint;
    }
}
