using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AIPaddle : MonoBehaviour
{
    const float FAST_REACTION_TIME = 0.28f;
    const float SLOW_REACTION_TIME = 0.48f;

    public PaddleAdapter paddleAdapater;

    private Ball ball;
    public Slider slider;
    public Paddle paddle;

    private PaddleControler.Direction direction = PaddleControler.Direction.RIGHT;



    // Start is called before the first frame update
    void Awake()
    {
        paddleAdapater = new PaddleAdapter(paddle, slider);
        ball = paddleAdapater.paddle.ballPrefab;

        StartCoroutine("ReactToBallDirection");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        paddleAdapater.Move(direction);
        
        Debug.DrawLine(paddle.transform.position, paddleAdapater.paddle.GetBallPosition(), Color.red);


    }

    private IEnumerator ReactToBallDirection()
    {

        while (true)
        {

            if (paddleAdapater.paddle.GetBallPosition().x > paddleAdapater.paddle.transform.position.x)
            {

                direction = PaddleControler.Direction.RIGHT;
            }
            else
            {
                direction = PaddleControler.Direction.LEFT;
            }

            yield return new WaitForSeconds(Random.Range(FAST_REACTION_TIME, SLOW_REACTION_TIME));
        }

    }

}
