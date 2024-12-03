using TMPro;
using UnityEngine;
using VinoUtility;

public class CoinCollector : MonoBehaviour
{
    public int curPoint = 0;
    public float pickRadius = 1.1f;
    public TextMeshProUGUI coinText;
    public void UpdateCoinNum()
    {
        if (coinText != null)
        {
            coinText.text = "x " + curPoint.ToString();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        var coin = other.GetComponent<Coin>();
        if(coin == null)
            return;
        curPoint += coin.value;
        coin.OnCollected();
        OnCollect(coin.gameObject);
    }
    public virtual void OnCollect(GameObject coinGO)
    {
        UpdateCoinNum();
        //Custom code
        //GetComponent<AutoGenerator>().Generate();
        //GetComponent<RotateSon2D>().MakeUniform(transform.GetActiveChildren());
    }

    // [Header("Win Condition")]
    // public int winPoint = 10;
    // public GameObject uiWin;
    
    private void Update() {
        
    }

    // private void OnDrawGizmos() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, pickRadius);
    // }

    // void FixedUpdate()
    // {
    //     var coinCollider = Physics2D.OverlapCircle(transform.position, pickRadius);
    //     if(coinCollider != null)
    //     {
    //         var coin = coinCollider.GetComponent<Coin>();
    //         if(coin != null)
    //         {
    //             curPoint += coin.value;
    //             UpdateCoinNum();
    //             Destroy(coin.gameObject);
    //         }
    //     }

    // }
}
