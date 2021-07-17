using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Net;
using UnityEngine.UI;
using System.Linq;


[Serializable]
public class ProfileWrapper
{
    public List<ProfileBumbleInfo> profiles; 
}


[Serializable]
public class ProfileBumbleInfo
{
    public string _id;
    public string name;
    public string age;

    public string description;
    public string proTitle;
    public string citiesInfo;    
}


public class ProfileSpawner : MonoBehaviour
{
    readonly string API_URL = "https://localhost:3000/unity/profiles";

    ProfileWrapper profilesWrapper;
    // Start is called before the first frame update
    void Start()
    {   
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:3000/unity/profiles");
        request.Method = "GET";
        request.ContentType = "application/json";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Debug.Log("Profile");
        Debug.Log(jsonResponse);
        ProfileWrapper profileWrapper = JsonUtility.FromJson<ProfileWrapper>(jsonResponse);

        this.profilesWrapper = profileWrapper;

        //List<ProfileBumble> profileInfoList = JsonUtility.FromJson<List<ProfileBumble>>(jsonResponse);
        //Debug.Log(profileInfoList[0].name);
        int index = 0;
        this.profilesWrapper.profiles.ForEach( x => {
            index++;
            GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject childText = new GameObject("ProfileName");
            childText.AddComponent<TextMesh>();
            childText.AddComponent<MeshRenderer>();
            childText.GetComponent<TextMesh>().text = x.name;
            childText.transform.parent = cyl.transform;
            cyl.transform.position = new Vector3(index + 2f - 0.7f, 0.5f, 0);
        });

    }

    // Update is called once per frame
    void Update()

    {

    }
}
