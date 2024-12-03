using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D{

[RequireComponent(typeof(Rigidbody2D))]
public class TopdownMovement : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed = 1f;

    public float MoveSpeed
    {
        get => _moveSpeed;

    }
    
    Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 dir)
    {
        _rigidBody.velocity = MoveSpeed * dir;
        
    }
    public void ImmediateMoveToPosition(Vector2 pos)
    {
        _rigidBody.MovePosition(pos);
    }
    public void MoveToPosition(Vector2 pos)
    {
        var distance = (pos - _rigidBody.position).magnitude;
        _rigidBody.DOMove(pos, distance / MoveSpeed);
    }
    private void Update() {

        
    }
}

}