using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UIShowValue : MonoBehaviour
{

    public static Dictionary<string, float> Blackboard = new Dictionary<string, float>();
    // Start is called before the first frame update
    public string key;
    public float maxValue = 100f;
    public Image fillImage;

    private void Start() {
        if(!Blackboard.ContainsKey(key))
            Blackboard.Add(key, 0f);
    }
    // Update is called once per frame
    void Update()
    {   
        float value = Blackboard[key];
        float percentage = value / maxValue;
        fillImage.fillAmount = percentage;
    }
}
