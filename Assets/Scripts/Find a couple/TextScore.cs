using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScore : MonoBehaviour {

    private GameController GC;

    Text text;

	void Start ()
    {
        GC = FindObjectOfType<GameController>();
        text = GetComponent<Text>();
	}

    private void Update()
    {
        text.text = GC.Score.ToString();
    }


}
