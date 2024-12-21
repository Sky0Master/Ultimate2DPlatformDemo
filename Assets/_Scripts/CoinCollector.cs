using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public static int curPoint = 0;
    
    public static Dictionary<string, int> scoreDict = new Dictionary<string, int>();

    [Header("Text Display")]
    public bool textDisplay = true;
    public TextMeshProUGUI coinText;

    [Header("Bar Display")]
    public List<Image> barList;
    
    public void UpdateCoinNum()
    {
        if (textDisplay && coinText != null)
        {
            string str = "";
            foreach(var pair in scoreDict)
            {
                str += string.Format("{0} : {1}\n", pair.Key, pair.Value);
            }
            coinText.text = str;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        var coin = other.GetComponent<Coin>();
        if(coin == null)
            return;
        if(!scoreDict.ContainsKey(coin.coinType))
            scoreDict[coin.coinType] = 0;
        scoreDict[coin.coinType] += coin.value;
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
