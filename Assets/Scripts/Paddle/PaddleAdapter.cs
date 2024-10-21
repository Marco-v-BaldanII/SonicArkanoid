using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAdapter : PaddleControler
{
    private Vector3 moveVector = new Vector3(1, 0, 0);

    private Paddle paddle;

    public void Move(PaddleControler.Direction direction)
    {
        if (direction == PaddleControler.Direction.RIGHT)
        {
            moveVector.x = 1;
            paddle.transform.Translate(moveVector);
        }
        else if (direction == PaddleControler.Direction.LEFT) 
        {
            moveVector.x = -1;
            paddle.transform.Translate(moveVector);
        }
    }

}
