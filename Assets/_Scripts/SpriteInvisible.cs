using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteInvisible : MonoBehaviour
{
    public float duration = 1.0f;
    public float fadeTime = 5f;
    public float minAlpha = 0.1f;
    SpriteRenderer spr;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    IEnumerator<WaitForSeconds> Skill()
    {
        float t = 0;
        float startAlpha = spr.color.a;
        while (t < duration)
        {
            t += Time.deltaTime;
            var alpha = Mathf.Lerp(startAlpha, minAlpha, t / duration);
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, alpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        t = 0;
        while(t < fadeTime)
        {
            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
         while (t < duration)
        {
            t += Time.deltaTime;
            var alpha = Mathf.Lerp(minAlpha, startAlpha, t / duration);
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, alpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Skill());
            anim.SetTrigger("skill1");
        }
    }
}
