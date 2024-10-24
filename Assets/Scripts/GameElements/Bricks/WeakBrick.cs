using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeakBrick : IBrick
{
    public Brick brickInstance;

    public WeakBrick(GameObject prefab , RectTransform parent, Tuple<Score, Score> scoreLabels, BrickPlacer placer)
    {
        // Pasar otros parametros
        var instance = GameObject.Instantiate(prefab, parent);
        brickInstance = instance.GetComponent<Brick>();
        brickInstance.scoreDisplays = scoreLabels;

        placer.bricks.Add(brickInstance);
    }

    public void SetHealth()
    {
        brickInstance.HP = 1;

        brickInstance.hpLabel.text = brickInstance.HP.ToString();
    }

    public void SetPosition(float width, float height, Vector2 position)
    {

        RectTransform rect = brickInstance.GetComponent<RectTransform>();
       // brickInstance.transform.position = position;
        rect.anchoredPosition = position;
        rect.sizeDelta = new Vector2(width, height);
    }

    public void Load(Vector2 tranformPosition, int hp)
    {
        brickInstance.transform.position = tranformPosition;
    }

}
