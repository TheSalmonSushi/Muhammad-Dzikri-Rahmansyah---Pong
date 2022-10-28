using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public int speed;
    public KeyCode Up;
    public KeyCode Down;


    private void Start()
    {
        
    }
    private void Update()
    {

        // ambil input
        Vector2 movement = GetInput();


        // gerakan object pake input
        MoveObject(movement);

        //Atau kalo mau lebh simpel bisa
        // MovedObject(GetInput());

    }


    private Vector2 GetInput()
    {
       
        

        if (Input.GetKey(Up))
        {

            return  Vector2.up * speed;
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

        transform.Translate(movement * Time.deltaTime);
    }

}

   


