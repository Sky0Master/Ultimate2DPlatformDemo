using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[Serializable]
public struct ChatSentence
{
    public string text;
    public string name;
    public Sprite characterSpr;
}

public class Dialog : MonoBehaviour,IPointerClickHandler
{
    public ChatSentence[] ChatText;
    public int StartIndex = 0;
    int _index;
    public TMP_Text tmp;

    public TMP_Text nameTMP;
    public UnityEvent EndEvent;
    public Image CharacterImage;

    public bool endResetDialog = true;

    public void SetSentence(int index)
    {
        tmp.text = ChatText[index].text;
        CharacterImage.sprite = ChatText[index].characterSpr;
        nameTMP.text = ChatText[index].name;
    }
    void OnEnable()
    {
        StartIndex = 0;
    }

    private void Start()
    {
        _index = StartIndex;
        if(CharacterImage==null)
            CharacterImage = transform.Find("Character").GetComponent<Image>();
        if(nameTMP == null)
            nameTMP = transform.Find("Title").GetComponent<TMP_Text>();
        SetSentence(_index);
    }

    public void NextText()
    {
        if (_index + 1 < ChatText.Length)
        {
            _index++;
           SetSentence(_index);
        }
        else
        {
            EndEvent?.Invoke();
            if(endResetDialog)
                _index = 0;
            gameObject.SetActive(false);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        NextText();
    }
}
