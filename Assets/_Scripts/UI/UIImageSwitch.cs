using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIImageSwitch : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] sprites;
    int _currentIndex = 0;
    public Image img;

    
    [Header("End Event")]
    public bool endJumpLevel;
    public string levelName;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_currentIndex < sprites.Length - 1)
        {
            _currentIndex++;
            SetImage();
        }
        else{
            img.enabled = false;
            if(endJumpLevel)
            {
                SceneManager.LoadSceneAsync(levelName);
            }
        }
    }
    public void SetImage()
    {
        if(img == null)
            return;
        
        img.sprite = sprites[_currentIndex];
        img.SetNativeSize();
    }
    public void Reset()
    {
        img.enabled = true;
        _currentIndex = 0;
        SetImage();
    }
    private void Start() {
        Reset();
    }
}
