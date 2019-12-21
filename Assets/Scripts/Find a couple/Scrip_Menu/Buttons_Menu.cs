using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_Menu : MonoBehaviour
{

    public void Open_Play()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void Open_Main_Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

}
