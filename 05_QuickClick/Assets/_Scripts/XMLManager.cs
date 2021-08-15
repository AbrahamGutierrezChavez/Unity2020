using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class XMLManager : MonoBehaviour
{
    public static XMLManager XML;
  // public ScoreDataBase itemDB;
  // public InputRead inputRead;
  // public InputField inputNameField;
    public GameManager gameManager;
    public string nameToScore;
    public TextMeshProUGUI scoreText;
    
    
    public Button saveButton;
    public Button loadButton;

    public InputField name;
    void Start()
    {
        saveButton.onClick.AddListener(GetInputOnClickHandler);
        loadButton.onClick.AddListener(SetTextScore);
    }
    /// <summary>
    /// métdodo para recuperar el valor de input por medio del boton Save 
    /// </summary>
    public void GetInputOnClickHandler()
    {
        //Debug.Log("log input ok" + name.text + gameManager._score);
        nameToScore = name.text + ": \n"+ gameManager._score;
        //Debug.Log(nameToScore);
        SaveItems(nameToScore);
        scoreText.text = nameToScore;
        scoreText.gameObject.SetActive(true);
        
    }

    public void SetTextScore()
    {
        LoadItems();
        //Debug.Log(scoreText.text);
        scoreText.gameObject.SetActive(true);
    }

    private void Awake()
    {
        XML = this;
    }
    public void SaveItems(string scoreItemToHigh)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(String));
        FileStream stream = new FileStream(Application.dataPath + "/DataBase/DataBase.xml", FileMode.Create);
        serializer.Serialize(stream, scoreItemToHigh);
        stream.Close();
    }

    /*
     public void SaveItems(List<ItemEntry> item)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ScoreDataBase));
        FileStream stream = new FileStream(Application.dataPath + "/DataBase/DataBase.xml",FileMode.Create);
        serializer.Serialize(stream,item);
        stream.Close();
    }
    */
    
    
    public void LoadItems()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(string));
        FileStream stream = new FileStream(Application.dataPath + "/DataBase/DataBase.xml", FileMode.Open);
        scoreText.text = serializer.Deserialize(stream) as string;
        stream.Close();
    }

    
/*
    [System.Serializable]
    public class ItemEntry
    {
        public string name ;
        /* InputField itemEntry5;
          public string _name
          {
              get;
              set;
          }
         public int _score
         {
             get;
             set;
         }
    }

    [System.Serializable]
    public class ScoreDataBase
    {
        public List<ItemEntry> scoreList = new List<ItemEntry>();
    }
*/
   

}
