using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeadZone : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject playerObj;
    public SpriteRenderer playerSpr;
    public float dissovleTime = 1f;

    [Header("Camera Shake")]
    public float shakeTime = 0.1f;
    public float shakeStrength = 1f;
    public void Respawn()
    {
        playerObj.transform.position = respawnPoint.position;
        playerSpr.material.DOFloat(0f,"_DissolveAmount",dissovleTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            playerSpr.material.DOFloat(1f,"_DissolveAmount",dissovleTime);
            Camera.main.DOShakePosition(shakeTime,shakeStrength);
            Camera.main.DOShakeRotation(shakeTime,shakeStrength);
            Invoke("Respawn", dissovleTime);
        }
    }
}
