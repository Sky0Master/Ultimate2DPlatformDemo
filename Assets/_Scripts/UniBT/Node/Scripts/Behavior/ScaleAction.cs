using UnityEngine;

namespace UniBT
{
    public class ScaleAction: Action
    {
        
        private Transform transform;

        private Vector3 initialScale;

        [SerializeField]
        float scaleMagnitude = 0.5f;

        public override void Awake()
        {
            transform = gameObject.transform;
            initialScale = transform.localScale;
        }

        protected override Status OnUpdate()
        {
            var curScale = initialScale * (1.0f + scaleMagnitude * Mathf.Sin(Time.realtimeSinceStartup));
            transform.localScale = curScale;
            return Status.Running;
        }

        public override void Abort()
        {
            //transform.localScale = initialScale;
        }
    }
}