using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VinoUtility.Gameplay;

public class LightDamage2D : MonoBehaviour
{
    public float damagePerSecond = 1f;
    public float radius = 10f;
    
    public int rayCount = 100;
    #if UNITY_EDITOR
    private void OnDrawGizmos() {
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
            var hitInfo = Physics2D.Raycast(transform.position, dir, radius);
            if(!hitColliders.Contains(hitInfo.collider) && hitInfo.collider != null && hitInfo.collider.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(damagePerSecond * Time.deltaTime, gameObject);
                hitColliders.Add(hitInfo.collider);
            }
        }
    }
}
