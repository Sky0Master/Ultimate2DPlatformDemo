using DG.Tweening;
using UnityEngine;
using VinoUtility;

public class TurnToMouseSide : MonoBehaviour
{
    public float duration = 0.1f;
    public float angleOnLeft = 90;
    public float angleOnRight = -90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = transform.GetMouseVector2().normalized;
        if(Vector2.Dot(Vector2.right,dir) < 0) 
        {
            transform.DORotate(new Vector3(0,angleOnLeft,0),duration,RotateMode.Fast);
        }
        else{
            transform.DORotate(new Vector3(0,angleOnRight,0),duration,RotateMode.Fast);
        }
    }
}
