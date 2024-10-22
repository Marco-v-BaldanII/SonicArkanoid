using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AIPaddle : MonoBehaviour
{

    // when the ball bounces it gives the ai it's velocity and the ai makes a prediction of where to be after x time to hit it

    public PaddleAdapter paddleAdapater;

    private Ball ball;
    public Slider slider;
    public Paddle paddle;



    // Start is called before the first frame update
    void Awake()
    {
        paddleAdapater = new PaddleAdapter(paddle, slider);
        ball = paddleAdapater.paddle.ballPrefab;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (paddleAdapater.paddle.GetBallPosition().x > paddleAdapater.paddle.transform.position.x)
        {

            paddleAdapater.Move(PaddleControler.Direction.RIGHT);
        }
        else
        {
            paddleAdapater.Move(PaddleControler.Direction.LEFT);
        }

        Debug.DrawLine(paddle.transform.position, paddleAdapater.paddle.GetBallPosition(), Color.red);


    }
}
