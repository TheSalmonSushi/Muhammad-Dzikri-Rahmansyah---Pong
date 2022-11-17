using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddeController : MonoBehaviour
{
    public Collider2D ball;

    public int boostedSpeed;

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
                rightPaddle.GetComponent<PaddleController>().ActivePUSpeedUpPaddle(boostedSpeed);
                rightPaddlecontroller.EffectRemaining2 = 5;
                rightPaddlecontroller.runTheTimer2 = true;

            }
            else if (BallController.checkPad.Equals("lPad"))
            {
                leftPaddle.GetComponent<PaddleController>().ActivePUSpeedUpPaddle(boostedSpeed);
                leftPaddleController.EffectRemaining2 = 5;
                leftPaddleController.runTheTimer2 = true;

            }



            manager.RemovePowerUp(gameObject);
            SoundManager.Instance._effectSource7.GetComponent<AudioSource>().Play();
        }
    }
}
