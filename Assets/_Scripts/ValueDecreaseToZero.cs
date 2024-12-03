using System.Collections;
using DG.Tweening;
using UnityEngine;


public class ValueDecreaseToZero : MonoBehaviour
{
    public SpriteRenderer sr;
    public string variebleName = "Value";
    public float endValue = 0f;
    public float duration = 10f;

    private IEnumerator Transition(SpriteRenderer sr, string variebleName, float speed, float targetValue = 0f)
    {
        var value = sr.material.GetFloat(variebleName);
        while (value > targetValue)
        {
            value -= speed * Time.fixedDeltaTime;
            sr.material.SetFloat(variebleName, value);
            yield return new WaitForFixedUpdate();
        }
    }
    
    void Start()
    {
        sr.material.DOFloat(endValue,variebleName,duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
