using UnityEngine;

namespace UniBT
{
    public class IsInRange : Conditional
    {
        public GameObject target;
        public string targetTag;
        public float minDistance;
        public float maxDistance;
        protected override void OnAwake()
        {
        
        }

        protected override bool IsUpdatable()
        {
            if(target == null)
                target = GameObject.FindGameObjectWithTag(targetTag);
            if(target == null) return false;
            var dist = Vector3.Distance(target.transform.position, gameObject.transform.position);
            return dist >= minDistance && dist <= maxDistance;
        }
    }
}