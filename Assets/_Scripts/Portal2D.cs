using System.Collections.Generic;
using UnityEngine;

public class Portal2D : MonoBehaviour
{
    public int portalId;
    public static Dictionary<int, Vector3> PortalDict = new Dictionary<int, Vector3>();
    public int targetPortalId;

    public Vector3 CalculatePosition(Vector2 offset)
    {
        return transform.position + transform.right * offset.x + transform.up * offset.y;
    }
    public Vector2 portalOffset = Vector2.zero;

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(CalculatePosition(portalOffset), 0.05f);
    }
    #endif

    public void Portal(Transform passenger)
    {
        if(PortalDict.ContainsKey(targetPortalId))
            passenger.transform.position = PortalDict[targetPortalId];
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Portal(other.gameObject.transform);
    }

    private void FixedUpdate() {
        PortalDict[portalId] = CalculatePosition(portalOffset);
    }
}
