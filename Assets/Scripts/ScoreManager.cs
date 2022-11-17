using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public int rightScore;
    public int leftScore;
    public int maxScore;

    public BallController ball;

   


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void AddRightScore(int increment)
    {
        ball.ResetBall();

        if (rightScore == maxScore)
        {
            GameOver();
        }

        rightScore += increment;
    }

    public void AddLeftScore(int increment)
    {

        ball.ResetBall();
        if (leftScore == maxScore)
        {
            GameOver();
        }

        leftScore += increment;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
        SoundManager.Instance._musicSource.GetComponent<AudioSource>().Play();
        SoundManager.Instance._musicSource2.GetComponent<AudioSource>().Stop();
    }

}
