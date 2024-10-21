using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeakBrick : IBrick
{
    public Brick brickInstance;

    public WeakBrick(GameObject prefab , RectTransform parent)
    {
        // Pasar otros parametros
        var instance = GameObject.Instantiate(prefab, parent);
        brickInstance = instance.GetComponent<Brick>();
    }

    public void SetHealth()
    {
        brickInstance.HP = 1;
    }

    public void SetPosition(float width, float height, Vector2 position)
    {

        RectTransform rect = brickInstance.GetComponent<RectTransform>();

        rect.anchoredPosition = position;
        rect.sizeDelta = new Vector2(width, height);
    }

}
