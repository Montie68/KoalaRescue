using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

//Code completed by Gianni & Geoff
public class SetScore : MonoBehaviour
{
   [SerializeField] GetScore getScore = null;
   [SerializeField] InputField playerScore = null;
   [SerializeField] InputField playerName = null;

    public void Submit()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()

    {
        WWWForm form = new WWWForm();
        form.AddField("name", playerName.text);
        form.AddField("score", playerScore.text);
        form.AddField("write", "");

        var www = UnityWebRequest.Post("https://koalarescue.geoffnewman.info/lb.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)   {  
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
        getScore.ReloadScore();
    }
}