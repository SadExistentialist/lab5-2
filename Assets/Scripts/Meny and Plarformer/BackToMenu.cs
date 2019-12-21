using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    Character character;

    [SerializeField]
    GameObject button;

   // Button_Show button_Show;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
       // button_Show = FindObjectOfType<Button_Show>();

    }
    
    public void Button_Hide()
    {
        

            button.SetActive(false);

        //  button_Show.Button_Hide();

        
    }

    public void Button_Shows()
    {


        button.SetActive(true);


    }



  

    public void BackToMenu1()
    {
        SceneManager.LoadScene(0);
    }
}
