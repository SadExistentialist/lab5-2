using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class text_Best_Time : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        Set_Best_time();
       
    }

    private string best_time;
    public string Best_time { set { best_time = value; } get { return best_time; } }

    public void Set_Best_time()
    {
        XmlTextReader xmlTextReader = new XmlTextReader("Assets/Resources/Score_Info.xml");
        while(xmlTextReader.Read())
        {
            if(xmlTextReader.IsStartElement("Best_Time") && !xmlTextReader.IsEmptyElement)
            {
                text.text = xmlTextReader.ReadString();
                best_time= xmlTextReader.ReadString();
            }
        }
        xmlTextReader.Close();
    }


}
