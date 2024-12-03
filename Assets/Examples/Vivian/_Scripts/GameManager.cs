using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace Vivian
{
[Serializable]
public class ScoreData
{
    public int score1;
    public int score2;
    public void Reset()
    {
        score1 = 0;
        score2 = 0;
    }
}

public class GameManager : MonoSingleton<GameManager>
{
    public Action<int> onWinAction;
    public Action<int> onLoseAction;

    public Action<int> onLoadLevelAction;
    public List<LevelData> levelDatas;

    public EventHandler<ScoreData> onScoreChangeHandler;

    bool isPaused = false;

    #region Custom Region
    [Header("Custom Part")]
    public bool isFirstSave = true;
    private ScoreData _curScore;
    #endregion

    void Init()
    {
        
    }
    private void Start() {
        Init();
        //LoadLevel();
        //LoadLevel(curLevel);
    }
    public int curLevel = 0;

    

    public ScoreData curScore{
        get { return _curScore; }
    }

    public void CheckCondition()
    {
       
    }
    
    
    public void NextLevel()
    {
        curLevel++;
        if(curLevel >= levelDatas.Count)
        {    
            GameOver();
            return;
        }
        LoadLevel(curLevel);
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return StartCoroutine(ScreenFader.Instance.FadeOut());
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return StartCoroutine(ScreenFader.Instance.FadeIn());
        yield return new WaitForSeconds(0.2f);
    }

    public void LoadLevel(int level)
    {
        if(levelDatas.Count <= level || level < 0)
           return;
        curLevel = level;
        _curScore.Reset();
        StartCoroutine(LoadSceneAsync(levelDatas[level].sceneName));
        onLoadLevelAction?.Invoke(level);
        
    }

    public void GameOver()
    {

    }

    public void ShowDialogByScore()
    {
        if(curScore.score1 > levelDatas[curLevel].score1Required && curScore.score2 > levelDatas[curLevel].score2Required)
        {

        }
        
    }
    public void Win()
    {
        Debug.Log("Win!");
        onWinAction?.Invoke(curLevel);
        //last level
        //NextLevel();

    }
    public void Lose()
    {
        onLoseAction?.Invoke(curLevel);

    }

    public void SetPaused(bool pause)
    {
        isPaused = pause;
        Time.timeScale = isPaused? 0 : 1;
    }

    void Update()
    {
       KeyDownTest();
    }

    //Do Test
    void KeyDownTest()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.F3))
        {
            
        }
    }

}
}