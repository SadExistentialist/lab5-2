using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;
using System.Linq;

public class TextResult : MonoBehaviour {

    TextTime Tt;
    GameController GC;
    Text _text;

   

    int Best_score_int;
    float Best_time_float;

    string BST;
    string BTF;

    private void Awake()
    {
        _text = GetComponent<Text>();
        GC = FindObjectOfType<GameController>();
        Tt = FindObjectOfType<TextTime>();

        
       
    }

    

    private void Info_Set()
    {

        XmlTextReader xmlTextReader = new XmlTextReader("Assets/Resources/Score_Info.xml");
        while (xmlTextReader.Read())
        {
            if (xmlTextReader.IsStartElement("Best_Score") && !xmlTextReader.IsEmptyElement)
            {
               
                BST = xmlTextReader.ReadString();
            }

            if (xmlTextReader.IsStartElement("Best_Time") && !xmlTextReader.IsEmptyElement)
            {
                BTF = xmlTextReader.ReadString();
            }

        }
        xmlTextReader.Close();
    
        Best_score_int = int.Parse(BST);

        Best_time_float = float.Parse(BTF);

        
        if (Best_score_int < GC.Score)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Assets/Resources/Score_Info.xml");
            xmlDoc.SelectSingleNode("Info_Result/Best_Score").InnerText = GC.Score.ToString();

            

            xmlDoc.Save("Assets/Resources/Score_Info.xml");
        }

        if (Best_time_float>Tt.Best_time)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Assets/Resources/Score_Info.xml");
            

            xmlDoc.SelectSingleNode("Info_Result/Best_Time").InnerText = Tt.Best_time.ToString("f1");

            xmlDoc.Save("Assets/Resources/Score_Info.xml");
        }




    }

    private void Update()
    {
        if(GC.FlagEnum==8 && Tt._Time>0)
        {
            _text.text = "You Won";
            Time.timeScale = 0f;
            _text.color = Color.green;

            Info_Set();

        }
       
        if(GC.FlagEnum<7 && Tt._Time<0)
        {
            _text.color = Color.red;
            _text.text = "You Lose";
            Time.timeScale = 0f;
            
        }

       
    }


}
