using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    private Ball ball;
    private Image image;
    private float ogWidth;

    const float TILE_WIDTH = 52.521f;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindAnyObjectByType<Ball>();
        if (ball)
        {
            ball.missEvent += UpdateHp;
        }

        image = GetComponent<Image>();
        if (image)
        {
            ogWidth = image.rectTransform.rect.width;
            Debug.Log("og width" +  ogWidth.ToString());
        }
    }

    public void UpdateHp(int hp)
    {
        Debug.Log(hp);
        image.rectTransform.sizeDelta = new Vector2( hp * TILE_WIDTH , image.rectTransform.sizeDelta.y);
    }
}
