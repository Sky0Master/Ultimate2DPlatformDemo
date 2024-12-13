using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class LimitDrag2D : MonoBehaviour
{
    public float minX = 0;
    public float maxX = 0;
    public float minY = 0;
    public float maxY = 0;
    private bool isDragging;
    private Vector2 offset;
    private void Start() {
        minX += transform.position.x;
        maxX += transform.position.x;
        minY += transform.position.y;
        maxY += transform.position.y;
    }
    void OnMouseDown()
    { 
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.SetParent(null);
    }
    void OnMouseUp()
    {
        isDragging = false;
    
    }
    public void HandleDrag()
    {
        if(!isDragging) return;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var x = Mathf.Clamp(pos.x + offset.x, minX, maxX);
        var y = Mathf.Clamp(pos.y + offset.y, minY, maxY);
        transform.position = new Vector3(x, y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        HandleDrag();
    }
}
