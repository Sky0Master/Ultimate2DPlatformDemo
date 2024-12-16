using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace VinoUtility.Gameplay{
public class ShootController : MonoBehaviour
{

    
    public KeyCode shootKey = KeyCode.J;
    public GameObject projectilePrefab;

    public KeyCode shootKey2 = KeyCode.K;
    public GameObject projectilePrefab2;
    public KeyCode shootKey3 = KeyCode.L;
    public GameObject projectilePrefab3;
    
    public bool shootRight = true;
    public ShootProjectile2D shoot;
    // Start is called before the first frame update

    public Vector2 ultimateOffset;
    void Start()
    {
        if (shoot == null)
            shoot = GetComponent<ShootProjectile2D>();
    }
        #if UNITY_EDITOR
    private void OnDrawGizmos() {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(transform.position + (Vector3)ultimateOffset, Vector3.one * 0.1f);
    }
    #endif
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey) && projectilePrefab != null)
        {
            shoot.SetProjectilePrefab(projectilePrefab);
            var p = shoot.Shoot( transform.localScale.x >0 ? transform.right : -transform.right );
        }
        if(Input.GetKeyDown(shootKey2) && projectilePrefab2 != null)
        {
            shoot.SetProjectilePrefab(projectilePrefab2);
            var p = shoot.Shoot(transform.localScale.x >0 ? transform.right : -transform.right );
        }
        if(Input.GetKeyDown(shootKey3) && projectilePrefab3 != null)
        {

            shoot.SetProjectilePrefab(projectilePrefab3);
            var p = shoot.Shoot(transform.localScale.x >0 ? transform.right : -transform.right);
            p.transform.position = new Vector2(p.transform.position.x, p.transform.position.y) + ultimateOffset;
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadSceneAsync("DragonBoss");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    }
}