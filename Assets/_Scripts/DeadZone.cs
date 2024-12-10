using UnityEngine;
using DG.Tweening;
using EZCameraShake;

public class DeadZone : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject playerObj;
    public SpriteRenderer playerSpr;
    public float dissovleTime = 1f;
    public bool respawnImmediately = true;

    [Header("Camera Shake")]
    public bool useCameraShake = false;
    public float shakeTime = 0.1f;
    public float shakeStrength = 1f;
    public float shakeRoughness = 10f;
    public void Respawn()
    {
        if(respawnPoint == null)
        {
            respawnPoint = GameObject.FindWithTag("Respawn").transform;
            
        }
        playerObj.transform.position = respawnPoint.position;
        playerSpr.material.DOFloat(0f,"_DissolveAmount",dissovleTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            if(playerSpr == null) playerSpr = other.GetComponentInChildren<SpriteRenderer>();
            playerSpr.material.DOFloat(1f,"_DissolveAmount",dissovleTime);
            if(useCameraShake)
                CameraShaker.Instance.ShakeOnce(shakeStrength,shakeRoughness,0,shakeTime);
            if(playerObj == null) playerObj = other.gameObject;
            if(respawnImmediately)
                Invoke("Respawn", dissovleTime);
            else{
                this.TriggerEvent("PlayerDie");
            }
        }
    }
}
