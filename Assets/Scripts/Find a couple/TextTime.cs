using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextTime : MonoBehaviour {

    [SerializeField]
    private float time;

    private float best_time;

    public float Best_time { set { best_time = value; } get { return best_time; } }

    public float _Time { set { time = value; } get { return time; } }

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update ()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            text.text = time.ToString("f1");

            best_time += Time.deltaTime;
        }
	}
}
