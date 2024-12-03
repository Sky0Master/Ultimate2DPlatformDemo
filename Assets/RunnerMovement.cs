using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RunnerMovement : MonoBehaviour
{
    public Vector2 runDirection = Vector2.right;
    public float runSpeed = 5f;
    public float jumpForce = 5f;
    public Vector2 gravity;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        rig = GetComponent<Rigidbody2D>();
    }
    public void HandleGravity()
    {
        rig.AddForce(gravity,ForceMode2D.Force);
    }
    public void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(-gravity.normalized * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void HandleRun()
    {
        transform.Translate(new Vector3(runDirection.x * runSpeed * Time.deltaTime, 0,0));
    }
    // Update is called once per frame
    private void Update() 
    {
        //HandleGravity();
        HandleJump();
        HandleRun();
    }
}
