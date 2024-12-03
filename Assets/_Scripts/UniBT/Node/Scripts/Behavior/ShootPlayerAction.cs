using UnityEngine;
using UniBT;
namespace UniBT{
    public class ShootAction : Action
    {

        
        [SerializeField] 
        private string targetTag = "Player";

        [SerializeField] 
        private ShootProjectile2D shoot; 


        //private float 
        private Transform target;
        public override void Start()
        {
            shoot = gameObject.GetComponent<ShootProjectile2D>();
        }
        protected override Status OnUpdate()
        {
            if(target == null) 
                target = GameObject.FindGameObjectWithTag(targetTag).transform;
            if(shoot == null || target == null) 
                return Status.Failure;
            
            shoot.ShootAt(target.position);
            return Status.Success;
        }

        public override void Abort()
        {
            
        }
    }
}
