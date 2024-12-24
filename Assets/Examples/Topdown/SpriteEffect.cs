using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteEffect : MonoBehaviour
{

    SpriteRenderer _spr;
    Texture2D _originalTex;
    Sprite _originalSprite;
    public void Grayscale()
    {
        //init texture
        Texture2D tex = new Texture2D(_originalTex.width, _originalTex.height);
        tex.SetPixels(_originalTex.GetPixels());
        
        //create new Sprite
        Sprite grayscaleSprite = Sprite.Create(tex, _spr.sprite.rect, _spr.sprite.pivot, _spr.sprite.pixelsPerUnit);
        grayscaleSprite.name = "Grayscale";
        _spr.sprite = grayscaleSprite;

        var pixelArray = tex.GetPixels();
        Color[] newPixelArray = new Color[_spr.sprite.texture.width * _spr.sprite.texture.height];

        for(int i = 0; i < pixelArray.Length; i++)
        {
            Color c = pixelArray[i];
            float grayscale = (c.r + c.g + c.b) / 3f;
            newPixelArray[i] = new Color(grayscale, grayscale, grayscale, c.a);
        }
        tex.SetPixels(newPixelArray);
        tex.Apply();
        Debug.Log("Grayscale effect applied");
    }
    // Start is called before the first frame update
    void Start()
    {
        _spr = GetComponent<SpriteRenderer>();
        _originalTex = new Texture2D(_spr.sprite.texture.width, _spr.sprite.texture.height);
        _originalTex.SetPixels(_spr.sprite.texture.GetPixels());
        _originalSprite = _spr.sprite;
    }
    public void ResetPixels()
    {
        _spr.sprite = _originalSprite;
        _spr.sprite.texture.SetPixels(_originalTex.GetPixels());
        _spr.sprite.texture.Apply();
        Debug.Log("Reset pixels");
        
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Grayscale();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetPixels();
        }
    }
}
