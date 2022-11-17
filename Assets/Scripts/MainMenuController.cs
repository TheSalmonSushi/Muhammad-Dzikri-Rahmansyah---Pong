using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

  

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        SoundManager.Instance._musicSource.GetComponent<AudioSource>().Stop();
        SoundManager.Instance._musicSource2.GetComponent<AudioSource>().Play();
        SoundManager.Instance._effectSource2.GetComponent<AudioSource>().Play();
    }


    public void Credit()
    {
        SceneManager.LoadScene("Credit");
        Debug.Log("Gw yang bikin tapi tutor dari AGC tengs AGC");
        SoundManager.Instance._effectSource.GetComponent<AudioSource>().Play();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SoundManager.Instance._effectSource.GetComponent<AudioSource>().Play();
    }

    public void BackToMainMenuFromGame()
    {
        SceneManager.LoadScene("MainMenu");
        SoundManager.Instance._musicSource.GetComponent<AudioSource>().Play();
        SoundManager.Instance._musicSource2.GetComponent<AudioSource>().Stop();

        SoundManager.Instance._effectSource.GetComponent<AudioSource>().Play();

    }
}


