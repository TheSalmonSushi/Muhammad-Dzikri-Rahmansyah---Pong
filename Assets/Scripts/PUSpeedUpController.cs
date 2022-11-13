using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float boostedSpeed;
    public PowerUpManager manager;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            //Speed up the ball
            ball.GetComponent<BallController>().ActivePUSpeedUp(boostedSpeed);
            manager.RemovePowerUp(gameObject);
        } 
    }
}
