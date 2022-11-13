using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Disini saya membuat Starting speed agar saat mulai bola tidak bergerak terlalu cepat 
    public float startingSpeed;

    // Disini speed saya ubah ke float agar lebih mudah untuk melakukan set pada speednya.
    //Lalu juga speed ini nanti digunakan ketika bola menyentuh paddle maka bola akan berubah dari startingSpeed yang pelan menjadi speed yang lebih kencang.
    public float speed;
    
    public Vector2 resetPosition;


    
    // Rigid body harus disimpan agar dia gak nyari2 lagii komponen2 yg memang dibutuhkan
    public Rigidbody2D rig;
    
    private void Start()
    {
        // dan dia ngambil komponennya itu di frame pertama
        rig = GetComponent<Rigidbody2D>();


        // alangkah baiknya jika sudah menggunakan physic kita menggerakan objek
        //menggunakan pyshic dan tidak menggunakan transform lagi.
        //ini  juga agar input dari vector speednya antara x=10 atau x=-10 dan antara y=-12 atau y=12
        //rig.velocity = new Vector2((Random.Range(0, 2) == 0 ? -10 : 10), (Random.Range(0, 2) == 0 ? -12 : 12));

        launch();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        // ini agar saat bola menyentuh paddle si bola akan diarahkan sesuai dimana si bola menyentuh paddle
        //Jika bola menyentuh bagian tengah paddle maka bola akan menyerong sedikit dan tidak akan hanya lurus
        //Jika bola menyentuh bagian atas paddle maka bola akan mengarah ke atas dan bukan lurus
        //Jika bola menyentuh bagian bawah paddle maka bola akan diarahkan agak kebawah.
        if (collision.gameObject.name.Equals("Right"))
        {
            float y = hitFactor(
                transform.position,
                collision.gameObject.transform.position,
                collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            rig.velocity = dir * speed;
            Debug.Log("Yhit" + y);
        }
        
        
            
        
        if (collision.gameObject.name.Equals("Left"))
        {
            
            float y = hitFactor(
                transform.position,
                collision.gameObject.transform.position,
                collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            rig.velocity = dir * speed ;
            Debug.Log("Yhit" + y);
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }
 


    public void ResetBall()
    {
        
        //ini untuk me restart posisi
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 0);

        // ini agar setiap mereset bola speednya juga di reset sehingga tidak terjadi bug bola melambat
       //Ini juga agar saat bola di reset posisi dan speednya di buat antara x= -5 atau 5 dan y=-7 atau 7.
        rig.velocity = new Vector2((Random.Range(0, 2) == 0 ? -5 : 5), (Random.Range(0, 2) == 0 ? -7 : 7));

     
 

    }
    
    // Disini saya membuat function baru bernama launch agar di Void Start itu lebih rapih
    private void launch()
    {
        //Disini saya membuat arah launchnya random
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        // Lalu velocity pada rigid body saya kalikan dengan float startingSpeed agar kecepatan bola bukan merupakan vector
        rig.velocity = new Vector2(startingSpeed *x, startingSpeed * y);
    }
    public void ActivePUSpeedUp(float boostedSpeed)
    {

        // Disini saat bola menyentuh powerUpSpeedUp maka kecepatan bola akan bertambah
        //namun ada sedikit bug yaitu setelah bola menambah kecepatan dengan mengenai PU dia akan melambat ke kecepatan normal saat menyentuh si paddle.
        rig.AddForce(rig.velocity * boostedSpeed);
       
        
       
       
    }






}
