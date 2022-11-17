using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public int speed;
    public KeyCode Up;
    public KeyCode Down;

    private Rigidbody2D rig;

    // Untuk PULongPaddle
    public bool runTheTimer1 = false;

    // Untuk PUSPeedUpPaddle
    public bool runTheTimer2 = false;

    // Untuk PULongPaddle
    public float EffectRemaining = 5;

    // Untuk PUSPeedUpPaddle
    public float EffectRemaining2 = 5;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {


        if (runTheTimer1)
        {
            if (EffectRemaining > 0)
            {
                EffectRemaining -= Time.deltaTime;
                Debug.Log(EffectRemaining);

            }
            else
            {
                
                gameObject.transform.localScale = new Vector2(0.2f, 2);
                runTheTimer1 = false;
            }
        }

        if (runTheTimer2)
        {
            if (EffectRemaining2 > 0)
            {
                EffectRemaining2 -= Time.deltaTime;
                
                Debug.Log(EffectRemaining2);

            }
            else
            {
                speed = 10;
                runTheTimer2 = false;
            }
        }


        // ambil input
        //Vector2 movement = GetInput();


        // gerakan object pake input
        // MoveObject(movement);

        //Atau kalo mau lebh simpel bisa
        MoveObject(GetInput());

    }


    private Vector2 GetInput()
    {




        if (Input.GetKey(Up))
        {

            return Vector2.up * speed;
            // gerakan ke atas
        }
        else if (Input.GetKey(Down))
        {
            // Gerakan ke bawah
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {


        rig.velocity = movement;
    }

    public void ActivePULongPaddle(Transform paddle)
    {

        // Disini saat paddle menyentuh powerUpLongPaddle maka ukuran paddle akan berubah
        
        paddle.localScale = new Vector2(0.2f, 4);




    }

    public void ActivePUSpeedUpPaddle(int boostedSpeed)
    {

        speed = boostedSpeed;




    }

}




