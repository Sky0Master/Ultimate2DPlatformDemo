using UnityEngine;

public class XFollow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
    }
     #if UNITY_EDITOR
    private void OnValidate() {
        if(target != null)
            transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
    
    }
    #endif
}
