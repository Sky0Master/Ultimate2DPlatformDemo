using UnityEngine;


namespace VinoUtility.Buff{

[CreateAssetMenu(fileName = "BuffMoveSpeed", menuName = "BuffMoveSpeed", order = 0)]
public class BuffMoveSpeed : ScriptableObject, IBuff {
    public float addSpeed;
    public float addPercentageSpeed;
    public float duration;

        public void Apply()
        {
            
        }

        public void Remove()
        {
            
        }

        public void Update()
        {
            
        }
    }

}