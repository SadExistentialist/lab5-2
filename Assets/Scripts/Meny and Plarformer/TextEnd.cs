using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextEnd : MonoBehaviour{

    Text text;
    Character character;
    
   

    private void Awake()
    {
        character = FindObjectOfType<Character>();
        text = GetComponent<Text>();
        
    }
    private void Update()
    {
        if(character.Lives==0)
        {
            text.text = "You Lose";

        }
        if(character.coins==7)
        {
            text.text = "You Won";
        }
        
    }
    
   
}
