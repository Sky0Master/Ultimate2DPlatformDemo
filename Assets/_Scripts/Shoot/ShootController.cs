using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    
    public KeyCode shootKey = KeyCode.J;
    public bool shootRight = true;
    public ShootProjectile2D shoot;
    // Start is called before the first frame update
    void Start()
    {
        if (shoot == null)
            shoot = GetComponent<ShootProjectile2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey))
        {
            var p = shoot.Shoot(transform.right);
        }
    }
}
