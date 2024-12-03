using UnityEngine;
using VinoUtility;

public class BirdCollector : CoinCollector
{
    public override void OnCollect(GameObject coinGO)
    {
        base.OnCollect(coinGO);
        //coinGO.transform.SetParent(transform);
        //GetComponent<RotateSon2D>().MakeUniform(transform.GetActiveChildren());
    }
}
