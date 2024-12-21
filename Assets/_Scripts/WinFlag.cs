using System.Collections;
using System.Collections.Generic;
using DYP;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;
    public int firstGoal;
    public int secondGoal;
    public string firstGoalName = "Health";
    public string secondGoalName = "Score";

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            if(CoinCollector.scoreDict.ContainsKey(firstGoalName) && CoinCollector.scoreDict.ContainsKey(secondGoalName))
            {
                if(CoinCollector.scoreDict[firstGoalName] >= firstGoal && CoinCollector.scoreDict[secondGoalName] >= secondGoal)
                    winUI.SetActive(true);
            }
            else
                loseUI.SetActive(true);
            other.GetComponent<BasicMovementController2D>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
