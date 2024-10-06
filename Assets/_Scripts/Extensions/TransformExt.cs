using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinoUtility{
public class TransformExt : MonoBehaviour
{
    public static List<Transform> GetActiveChildren(Transform node)
    {
        List<Transform> children = new List<Transform>();
        for(int i = 0; i < node.childCount; i++)
        {
            var child = node.GetChild(i);
            if (child.gameObject.activeSelf)
                children.Add(child);
        }
        return children;
    }
    public static List<Transform> GetInactiveChildren(Transform node)
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < node.childCount; i++)
        {
            var child = node.GetChild(i);
            if (!child.gameObject.activeSelf)
                children.Add(child);
        }
        return children;
    }
    public static List<Transform> GetAllChildren(Transform node)
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < node.childCount; i++)
        {
            children.Add(node.GetChild(i));
        }
        return children;
    } 
}
}
