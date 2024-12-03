using System.Collections;
using System.Collections.Generic;
using Game2D;
using UnityEngine;


public enum AttackType{
    None,
    A,
    B,
}

public class PlayerInput : MonoBehaviour
{

    public bool canMove;
    private TopdownMovement _topdownMovement;
    public bool useMouseMove;
    public bool IsMoving {
        get => GetMoveInputVector().magnitude > 0.01f;
    }

    void Start()
    {
        _topdownMovement = GetComponent<TopdownMovement>();
        
    }
    public Vector2 GetMoveInputVector()
    {
        Vector2 result = Vector2.zero;
        result.x = Input.GetAxisRaw("Horizontal");
        result.y = Input.GetAxisRaw("Vertical");
        return result;
    }
    public void Freeze()
    {
        _topdownMovement.SetVelocity(Vector2.zero);
        canMove = false;
    }
    public void UnFreeze()
    {
        canMove = true;
    }

    

    void Update()
    {
        if(!canMove){
            return;
        }
        if(useMouseMove && Input.GetMouseButtonDown(1)){
            _topdownMovement.MoveToPosition(Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition));
        }
        var inputVec = GetMoveInputVector();
        _topdownMovement.SetVelocity(inputVec);
    }
}
