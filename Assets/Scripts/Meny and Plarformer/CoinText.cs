using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour {

    Text text;
    Character character;
    
    private void Awake()
    {
        character = FindObjectOfType<Character>();
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text= character.coins.ToString();
        text.text += "/7";
    }

}
