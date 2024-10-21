using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{

    public Slider horizontalSlider;
    public Slider verticalSlider;

    private Slider currentSlider;

    public GameObject leftBorder;
    public GameObject rightBorder;

    private Vector3 leftPos;
    private Vector3 rightPos;

    public Rigidbody2D body;

    public Ball ballPrefab;
    private Ball ball;

    public delegate void EventHandler();
    public event EventHandler LaunchEvent;

    public Canvas canvas;

    public delegate void PowerHandler();
    public event PowerHandler PowerUpEvent;

    // Start is called before the first frame update
    void Awake()
    {
        leftPos = leftBorder.transform.position;
        rightPos = rightBorder.transform.position;


        ball = Instantiate(ballPrefab, canvas.transform,true);
        ball.paddle = this;

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pathVector = (rightBorder.transform.position - leftBorder.transform.position)*0.35f;

        pathVector *= currentSlider.value;

        Debug.DrawLine(rightPos,  pathVector);

        transform.position = new Vector3(pathVector.x, transform.position.y, pathVector.z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchEvent.Invoke();
        }



    }

    public void ChangeOritentation(AlingmentManager.Orientation orientation)
    {
        if (orientation == AlingmentManager.Orientation.LANDSCAPE)
        {
            currentSlider = horizontalSlider;
        }
        else
        {
            currentSlider = verticalSlider;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("esmerald"))
        {
            ball.EsmeraldExplosion();
            collision.gameObject.SetActive(false);
            PowerUpEvent.Invoke();
        }
    }



}
