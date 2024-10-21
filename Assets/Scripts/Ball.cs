using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public bool launched = false;
    public int launchForce ;

    [SerializeField] private int hp = 3;
    [SerializeField] private GameObject explosionObject;

    private Rigidbody2D ballRigidbody;

    public Paddle paddle;

    private float velocityFactor = 1.03f;

    bool hit = false;

    public delegate void EventHandler(int hp); /* method ptr , indicates that the delegates that use it take no parameters */
    public event EventHandler missEvent;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        paddle.LaunchEvent += Launch; /*Subscribe to the launch event*/
    }

    // Update is called once per frame
    void Update()
    {
        if(!launched)
        {
            transform.position = paddle.transform.position;
        }


        hit = false;

    }



    public void Launch()
    {
        if (!launched)
        {
            launched = true;
            ballRigidbody.velocity = Vector2.zero;

            ballRigidbody.velocity = Vector2.up * 5;
        }
        else
        {
            paddle.LaunchEvent -= Launch; /* UnSubscribe */
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERRR");


        Debug.Log(ballRigidbody.velocity.y);
        
        if (hit)
        {
            return;
        }


        hit = true;

        if (collision.CompareTag("brick"))
        {
            if (esmerald)
            {
                return;
            }
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x , ballRigidbody.velocity.y * -1) * velocityFactor;

        }

        if (collision.CompareTag("paddle"))
        {
            var distance = Vector2.Distance(transform.position , paddle.transform.position);

            if (transform.position.x < paddle.transform.position.x)
            {
                distance *= -1;
            }

            ballRigidbody.velocity = new Vector2(distance * 5, ballRigidbody.velocity.y * -1) * velocityFactor;

        }

        if (collision.CompareTag("wall"))
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x * -1, ballRigidbody.velocity.y) * velocityFactor;
        }
        else if (collision.CompareTag("ceiling"))
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, ballRigidbody.velocity.y * -1) * velocityFactor;
        }

        else if (collision.CompareTag("teleport"))
        {
            launched = false;
            ballRigidbody.velocity = Vector2.zero;
            hp -= 1;
            missEvent.Invoke(hp);
        }

        ballRigidbody.velocity = Vector2.ClampMagnitude(ballRigidbody.velocity, 10);

        
    }

    public void EsmeraldExplosion()
    {
        StartCoroutine("Explosion");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }

    bool esmerald = false;

    private IEnumerator Explosion()
    {
        explosionObject.gameObject.SetActive(true);
        esmerald = true;

        yield return new WaitForSeconds(0.5f);

        explosionObject.gameObject.SetActive(false);
        esmerald = false;
    }

}
