using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System;

//Code completed by Gianni & Geoff
public class GetScore : MonoBehaviour
{
    public GameObject Row;
    // by Geoff
    [SerializeField] InputField _scoreInput = null;
    public void ReloadScore()
    {

            Transform[] children = GetComponentsInChildren<Transform>();
        List < GameObject > row = new List<GameObject>();
        foreach (Transform r in children)
            if (r.name == "Row(Clone)") row.Add(r.gameObject);

        foreach(GameObject r  in row)
        {
            Destroy(r);
        }
        StartCoroutine(GetRequest("https://koalarescue.geoffnewman.info/lb.php?read"));

    }

    void Start()
    {

        // A correct website page.
        if (Row != null)
        {
            if (_scoreInput == null) throw new Exception();
            _scoreInput.text = ScoreList.playerScore.ToString();
            StartCoroutine(GetRequest("https://koalarescue.geoffnewman.info/lb.php?read"));
        }


    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                    var html = webRequest.downloadHandler.text;
                    var jSON = JSON.Parse(webRequest.downloadHandler.text);
                //jSONArray = (JSONArray)jSON;

                string name;
                string score;
                int pos = 0;

                if (html != "[]")
                        foreach (JSONNode n in jSON)
                        {
                        pos++;
                        GameObject newRow = (GameObject)Instantiate(Row, transform);
                        newRow.gameObject.transform.SetParent(this.gameObject.transform);
                        newRow.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = (pos).ToString();
                        newRow.gameObject.transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>().text = ((n["name"]).ToString().Replace("\"", string.Empty));
                        newRow.gameObject.transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = (n["score"]).ToString();
                        name = n["name"];
                            score = n["score"];
                        }

                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
}
