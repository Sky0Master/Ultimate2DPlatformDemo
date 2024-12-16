using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinoUtility.Gameplay
{
public class TouchDamage2D : MonoBehaviour
{
    public int damage;
    public bool destroyAfterTouch = true;
    public List<string> exceptTags;

    public GameObject damageSource;

    [Header("Continuous Damage")]
    public bool enableContinuousDamage = false;
    public float damagePerSecond = 1f;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(exceptTags.Contains(other.tag))
            return;
        
        var health = other.GetComponent<Health>();
        if(health==null)
            health = GetComponentInParent<Health>();
        if(health==null)
            return;
        
        if(damageSource==null)
            damageSource = gameObject;
        health.TakeDamage(damage, damageSource);
        if(destroyAfterTouch)
            Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(!enableContinuousDamage)
            return;
        if(exceptTags.Contains(other.tag))
            return;
        var health = other.GetComponent<Health>();
        if(health==null)
            health = GetComponentInParent<Health>();
        if(health==null)
            return;
        if(damageSource==null)
            damageSource = gameObject;
        health.TakeDamage(damagePerSecond * Time.deltaTime, damageSource);
    }

}
}