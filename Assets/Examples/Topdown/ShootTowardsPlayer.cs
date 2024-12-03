using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootTowardsPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 7f;
    public bool isFacingPlayer = true;
    public string playerTag = "Player";
    float _startTime;
    // Start is called before the first frame update
    
    Transform player;
    void Start()
    {
        _startTime = Time.time;
        player = GameObject.FindWithTag(playerTag)?.transform;
        if(player == null)
        return;
        var dir = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = dir * speed;
        if(isFacingPlayer)
        {
            transform.right = dir;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time - _startTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy() {
        
    }
}
