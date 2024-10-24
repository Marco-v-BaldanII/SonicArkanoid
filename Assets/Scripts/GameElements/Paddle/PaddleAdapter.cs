using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PaddleAdapter : PaddleControler
{
    const float SPEED = 0.03f;

    public PaddleAdapter(Paddle paddle, Slider slider)
    {
        this.paddle = paddle;
        this.slider = slider;
    }


    private Vector3 moveVector = new Vector3(1, 0, 0);

    public Slider slider;

    public Paddle paddle;

    public void Move(PaddleControler.Direction direction)
    {
        if (direction == PaddleControler.Direction.RIGHT)
        {

            slider.value += SPEED;

        }
        else if (direction == PaddleControler.Direction.LEFT) 
        {

            slider.value -= SPEED;

        }
    }

}
