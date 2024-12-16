using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VinoUtility.Gameplay;

namespace VinoUtility.Gameplay
{
public class LightDamage2D : MonoBehaviour
{
    
    public float damagePerSecond = 1f;

    public float radius;    
    public int rayCount = 100;
    
    public LayerMask targetLayer;
    [Header("Light Force")]
    public bool lightForce = false;
    public float force = 1f;

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        radius = GetComponent<Light2D>().pointLightOuterRadius;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    #endif

    // Update is called once per frame
    void Update()
    {
        var detectAngle = Mathf.Deg2Rad * (360f / rayCount);
        HashSet<Collider2D> hitColliders = new HashSet<Collider2D>();
        for(int i = 0; i < rayCount; i++)
        {
            var dir = new Vector2(Mathf.Cos(detectAngle * i), Mathf.Sin(detectAngle * i));
            var hitInfo = Physics2D.Raycast(transform.position, dir, radius, targetLayer);
            if(hitInfo.collider == null || hitColliders.Contains(hitInfo.collider))
                continue;
            
            if(hitInfo.collider.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(damagePerSecond * Time.deltaTime, gameObject);
                hitColliders.Add(hitInfo.collider);
            }

            if(lightForce &&  hitInfo.collider.TryGetComponent<Rigidbody2D>(out var rb)) 
            {
                rb.AddForce(force * dir , ForceMode2D.Force);
                hitColliders.Add(hitInfo.collider);
            }
        }
    }
}
}