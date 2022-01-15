using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    [SerializeField] float yOffset;
    [SerializeField] float xVelocity;
    [SerializeField] float yVelocity;
    [SerializeField] AudioClip[] ballSounds;

    public bool hasStarted;


    
    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            StickBallOnPaddle();
            LaunchBallOnClick();
        } 

    }

    private void StickBallOnPaddle()
    {
        Vector2 stickedBall = new Vector2(paddle.transform.position.x, paddle.transform.position.y + yOffset);
        transform.position = stickedBall;
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
