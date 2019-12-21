using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void StartGame2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
