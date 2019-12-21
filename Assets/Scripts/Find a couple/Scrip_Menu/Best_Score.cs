using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Best_Score : MonoBehaviour
{

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        

    }

    private void Update()
    {
        Set_Best_score();
    }
    

    public void Set_Best_score()
    {
        XmlTextReader xmlTextReader = new XmlTextReader("Assets/Resources/Score_Info.xml");
        while (xmlTextReader.Read())
        {
            if (xmlTextReader.IsStartElement("Best_Score") && !xmlTextReader.IsEmptyElement)
            {
                text.text = xmlTextReader.ReadString();
                
            }

        }
        xmlTextReader.Close();
    }
}
