using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{


    public Vector2 speed;

  

    // Rigid body harus disimpan agar dia gak nyari2 lagii komponen2 yg memang dibutuhkan
    private Rigidbody2D rig;
    private void Start()
    {
        // dan dia ngambil komponennya itu di frame pertama
        rig = GetComponent<Rigidbody2D>();



        




        // alangkah baiknya jika sudah menggunakan physic kita menggerakan objek
        //menggunakan pyshic dan tidak menggunakan transform lagi.
        rig.velocity = speed;
    }

    
  

   

     

   
}
