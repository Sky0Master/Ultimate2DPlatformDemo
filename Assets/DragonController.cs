using UnityEngine;

public class DragonController : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rig;
    public enum DragonState
    {
        Ground,
        Fly,
    }
    public float walkSpeed = 3f;
    public float flySpeedX = 6f;
    public float flySpeedY = 2f;
    public DragonState dragonState;

    bool _skill1;

    [HideInInspector]
    public float xInput;
    [HideInInspector]
    public float yInput;
    
    public BoxCollider2D _collider;
    [Header("Skill")]
    [Space(5)]
    public GameObject skill1Go;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rig = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void GroundUpdate()
    {
        _collider.enabled = true;
        _animator.SetBool("air",false);
        _rig.gravityScale = 2f;
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            dragonState = DragonState.Fly;
        }
        _rig.velocity = new Vector2(xInput * walkSpeed, _rig.velocity.y);
    }
    
    public void FlyUpdate()
    {
        _collider.enabled = false;
        _animator.SetBool("air",true);
        _rig.gravityScale = 0.1f;
        skill1Go.SetActive(_skill1);
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            dragonState = DragonState.Ground;
        }
        
        _rig.velocity = new Vector2(xInput*flySpeedX , yInput*flySpeedY);
    }
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Mouse X");
        yInput = Input.GetAxisRaw("Mouse Y");
        
        _skill1 = dragonState == DragonState.Fly && Input.GetMouseButton(0);

        if(Mathf.Abs(xInput) < 0.05f)
            _animator.SetBool("xmove",false);
        else
            _animator.SetBool("xmove",true);
        
        switch (dragonState)
        {
           case DragonState.Ground:
                GroundUpdate();
                break;
            case DragonState.Fly:
                FlyUpdate();
                break;
        }
    }
    public void Skill1()
    {

    }
    public void Skill2()
    {

    }
}
