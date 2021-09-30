// By Geoff Newman
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class ScoreList : MonoBehaviour
{
    #region Public
    //public members go here
    public static List<Tuple<string, int>> scoreList = new List<Tuple<string, int>>();
    public static int playerScore = 0;

    #endregion

    #region Private
    //private members go here

    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    void Start()
    {
        StartCoroutine(GetList("https://koalarescue.geoffnewman.info/lb.php?read"));
    }

    #endregion
    #region Public Methods
    //Place your public methods here

    #endregion
    #region Private Methods
    //Place your public methods here
    IEnumerator GetList(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                var html = webRequest.downloadHandler.text;
                var jSON = JSON.Parse(webRequest.downloadHandler.text);

                if (html != "[]")
                    foreach (JSONNode n in jSON)
                    {
                        scoreList.Add(Tuple.Create(n["name"].ToString(), (int)n["score"]));
                    }
            }
        }
    }

    #endregion

}
