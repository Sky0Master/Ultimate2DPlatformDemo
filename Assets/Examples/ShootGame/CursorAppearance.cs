using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAppearance : MonoSingleton<CursorAppearance>
{
    public List<Sprite> cursorSprites;
    
    public Sprite currentCursorSprite;
    public SpriteRenderer cursorRenderer;
    public void SetCursorByIndex(int index)
    {
        if(index >= cursorSprites.Count) return;
        currentCursorSprite = cursorSprites[index];
        cursorRenderer.sprite = currentCursorSprite;
    }
    public void AddCursorSprite(Sprite sprite)
    {
        cursorSprites.Add(sprite);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCursorByIndex(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
