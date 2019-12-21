using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BacktoMenuButton : MonoBehaviour {

    public void BackToMenu()
    {
        SceneManager.LoadScene(3);
    }
}
