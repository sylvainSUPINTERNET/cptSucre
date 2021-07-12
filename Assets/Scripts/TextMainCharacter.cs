using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Net;
using UnityEngine.UI;

      [Serializable]
      public class WeatherInfo
      {
          public int userId;
          public int id;
          public string title;
      }
public class TextMainCharacter : MonoBehaviour
{
    Text nameChar;
    // Start is called before the first frame update
    void Start()
    {
        nameChar = gameObject.GetComponent<Text>();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/todos/1");
        request.Method = "GET";
        request.ContentType = "application/json";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        nameChar.text = info.title;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
