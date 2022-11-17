using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    
    public float boostedSpeed;
    public PowerUpManager manager;
    public int DeSpawnInterval;

    private float timerNotCollide;


    private void Update()
    {
        timerNotCollide += Time.deltaTime;

        if (timerNotCollide > DeSpawnInterval)
        {
            manager.RemovePowerUp(gameObject);
        }


    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
     

            //Speed up the ball
            ball.GetComponent<BallController>().ActivePUSpeedUp(boostedSpeed);
            manager.RemovePowerUp(gameObject);
            SoundManager.Instance._effectSource5.GetComponent<AudioSource>().Play();
        } 
    }
}
