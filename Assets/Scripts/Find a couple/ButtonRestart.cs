using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour {

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }
}
