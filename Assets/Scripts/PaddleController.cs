using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float horizontalUnits;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    float xPos;
    float yPos;
    private BallController ball;
    private GameStatus status;

    private void Start()
    {
        yPos = transform.position.y;
        ball = FindObjectOfType<BallController>();
        status = FindObjectOfType<GameStatus>();
    }

    private void Update()
    {
        if (status.autoPilot && ball.hasStarted )
        {
            Vector2 paddlePos = new Vector2( Mathf.Clamp(ball.transform.position.x, minX, maxX ) , yPos);
            transform.position = paddlePos;
        } else
        {
            xPos = Mathf.Clamp(Input.mousePosition.x / Screen.width * horizontalUnits, minX, maxX); // value based on mouse's x axis position
            Vector2 paddlePos = new Vector2(xPos, yPos);
            transform.position = paddlePos;
        }
    }
}
