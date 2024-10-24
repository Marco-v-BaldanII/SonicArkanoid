using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PaddleControler 
{
    public enum Direction
    {
        LEFT,
        RIGHT
    }


    public void Move(PaddleControler.Direction direction)
    {

    }

}
