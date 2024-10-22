using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleAdapter : PaddleControler
{
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

            slider.value += 0.02f;

            //moveVector.x = 1;
            //paddle.transform.Translate(moveVector);
        }
        else if (direction == PaddleControler.Direction.LEFT) 
        {

            slider.value -= 0.02f;

            //moveVector.x = -1;
            //paddle.transform.Translate(moveVector);
        }
    }

}
