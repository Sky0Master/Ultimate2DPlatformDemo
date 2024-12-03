using UnityEngine;

namespace UniBT.Examples.Scripts.Behavior
{
    public class IsFarThan : Conditional
    {
        public GameObject target;
        public float distance;
        protected override void OnAwake()
        {
        
        }

        protected override bool IsUpdatable()
        {
            return Vector2.Distance(target.transform.position, gameObject.transform.position) > distance;
        }
    }
}