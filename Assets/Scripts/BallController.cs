using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{


    public Vector2 speed;
    public Vector2 resetPosition;



  

    // Rigid body harus disimpan agar dia gak nyari2 lagii komponen2 yg memang dibutuhkan
    private Rigidbody2D rig;
    private void Start()
    {
        // dan dia ngambil komponennya itu di frame pertama
        rig = GetComponent<Rigidbody2D>();


        // alangkah baiknya jika sudah menggunakan physic kita menggerakan objek
        //menggunakan pyshic dan tidak menggunakan transform lagi.
        //ini  juga agar input dari vector speednya antara x=10 atau x=-10 dan antara y=-12 atau y=12
        rig.velocity = new Vector2((Random.Range(0, 2) == 0 ? -10 : 10), (Random.Range(0, 2) == 0 ? -12 : 12));
    }


    public void ResetBall()
    {
        
        //ini untuk me restart posisi
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 1);

        // ini agar setiap mereset bola speednya juga di reset sehingga tidak terjadi bug bola melambat
        //namun masih ada bug diman jika speed bola berubah untuk meresetnya hanya bisa dilakukan saat terjadi goal
        //jika tidak terjadi goal maka speed bola tetap berubah (bug terjadi jika bola mengenai atas paddle yang terjadi adalah speed bola berubah)
        rig.velocity = new Vector2((Random.Range(0, 2) == 0 ? -10 : 10), (Random.Range(0, 2) == 0 ? -12 : 12));
 

    }






}
