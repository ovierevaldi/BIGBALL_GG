using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class inputnama : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] InputField nomorhp;
    [SerializeField] string url;

    WWWForm form;

    string score;
    private void Start()
    {
        score = PlayerPrefs.GetString("Score");
    }

    public void Onsubmit()
    {
        print(username + " " + nomorhp);
        //StartCoroutine(Login());
    }

    IEnumerator Login()
    {       
        form = new WWWForm();
        form.AddField("game_name", "bigball");
        form.AddField("area_id", "1");
        form.AddField("username", username.text);
        form.AddField("nomorhp", nomorhp.text);
        form.AddField("score", score);
        form.AddField("time", "15:30:00");
        form.AddField("code_id", "1");


        // Upload to a cgi script
        using (var w = UnityWebRequest.Post("http://192.168.17.99:3000/player/post-player-score", form))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print("Finished Uploading Score");
            }
        }
    }
}

