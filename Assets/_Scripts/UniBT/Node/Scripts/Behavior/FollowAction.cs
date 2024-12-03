using UnityEngine;
using UnityEngine.AI;

namespace UniBT
{
    public class FollowAction : Action
    {

        [SerializeField] 
        private string targetTag = "Player";

        [SerializeField] 
        private float speed = 5f;

        [SerializeField] 
        private float stoppingDistance = 5f;

        private Transform target;


        public override void Awake()
        {
            
        }

        protected override Status OnUpdate()
        {
            if (target == null){
                target = GameObject.FindGameObjectWithTag(targetTag).transform;
            }
            if(target == null) return Status.Failure;
            var dir = (target.position - gameObject.transform.position).normalized;
            gameObject.transform.Translate(dir * speed * Time.deltaTime);
            if (IsDone)
            {
                return Status.Success;
            }
            return Status.Running;
        }

        public override void Abort()
        {
            
        }
        private bool IsDone => Vector2.Distance(gameObject.transform.position,target.transform.position) <= stoppingDistance; 
    }
}