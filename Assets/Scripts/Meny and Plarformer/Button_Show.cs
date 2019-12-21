using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Show : MonoBehaviour
{

    Character character;

    [SerializeField]
    GameObject button;

   // BackToMenu backToMenu;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
      //  backToMenu = FindObjectOfType<BackToMenu>();
        
    }
   

    public void Button_Hide()
    {
        

            button.SetActive(false);
        //backToMenu.Button_Hide();

        
    }

        public void Button_Shows()
    {
       
        
         button.SetActive(true);
           
        
    }

        

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

   

}
