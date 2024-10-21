using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MidBrick : IBrick
{
    public Brick brickInstance;

    public MidBrick(GameObject prefab , RectTransform parent, Tuple<Score, Score> scoreLabels)
    {

        var instance = GameObject.Instantiate(prefab, parent);
        brickInstance = instance.GetComponent<Brick>();
        brickInstance.scoreDisplays = scoreLabels;
        
    }

    public void SetHealth()
    {
        brickInstance.HP = 2;
        Image img = brickInstance.GetComponent<Image>();
        //img.color = Color.gray;
    }

    public void SetPosition(float width, float height, Vector2 position)
    {

        RectTransform rect = brickInstance.GetComponent<RectTransform>();

        rect.anchoredPosition = position;
        rect.sizeDelta = new Vector2(width, height);
    }

}
