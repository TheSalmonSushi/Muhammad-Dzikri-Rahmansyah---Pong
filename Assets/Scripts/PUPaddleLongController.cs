using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleLongController : MonoBehaviour
{
    public Collider2D ball;


    public PaddleController leftPaddleController;
    public PaddleController rightPaddlecontroller;
    public Transform rightPaddle;
    public Transform leftPaddle;



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
            if (BallController.checkPad == null)
            {
                return;
            }

            if (BallController.checkPad.Equals("rPad"))
            {
                rightPaddle.GetComponent<PaddleController>().ActivePULongPaddle(rightPaddle);
                rightPaddlecontroller.EffectRemaining = 5;
                rightPaddlecontroller.runTheTimer1 = true;

            }
            else if (BallController.checkPad.Equals("lPad"))
            {
                leftPaddle.GetComponent<PaddleController>().ActivePULongPaddle(leftPaddle);
                leftPaddleController.EffectRemaining = 5;
                leftPaddleController.runTheTimer1 = true;

            }



            manager.RemovePowerUp(gameObject);
            SoundManager.Instance._effectSource6.GetComponent<AudioSource>().Play();
        }
    }
}
