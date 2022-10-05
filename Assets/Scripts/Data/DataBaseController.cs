using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;

public class DataBaseController : MonoBehaviour
{
    public List<string> information;
    public List<string> name;
    public List<string> score;
    public List<string> killed;

    public InputField nameField;

    public Button submitButton;

    public Text textElementName;
    public Text textElementScore;
    public Text textElementKilled;

    public GameObject EnterNameCanva;
    public GameObject ScoreBoardCanva;

    public void Start()
    {

    }

    public void CallgetData()
    {
        StartCoroutine(getData());
    }

    public void CallsaveData()
    {
        StartCoroutine(saveData());
    }

    IEnumerator getData()
    {
        information.Clear();
        name.Clear();
        score.Clear();
        killed.Clear();
        textElementName.text = "";
        textElementScore.text = "";
        textElementKilled.text = "";

        UnityWebRequest www = UnityWebRequest.Get("http://www.zp12463.tld.61.19.247.251.no-domain.name/GetDataBase.php");
        yield return www.SendWebRequest();
        if(www.isHttpError || www.isNetworkError)
        {
            Debug.Log("Connection Error!");
        }
        else
        {
            string s = www.downloadHandler.text;
            information = s.ToString().Split(',').ToList();
            information.RemoveAt(information.Count - 1);

            foreach (string y in information)
            {
                name.Add(y.Split('-')[0]);
                score.Add(y.Split('-')[1]);
                killed.Add(y.Split('-')[2]);
            }

            foreach (string x in name)
            {
                textElementName.text += x + "\n";
            }
            foreach (string x in score)
            {
                textElementScore.text += x + "\n";
            }
            foreach (string x in killed)
            {
                textElementKilled.text += x + "\n";
            }
            www.Dispose();
        }
    }

    IEnumerator saveData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("score", (PlayerMovement.curCoin * 100).ToString());
        form.AddField("killed", (CountZombieDead.Count).ToString());
        WWW www = new WWW("http://www.zp12463.tld.61.19.247.251.no-domain.name/SaveDataBase.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Created suscessfully");
        }
        else
        {
            Debug.Log("Status : " + www.text);
        }

        CallgetData();
        EnterNameCanva.SetActive(false);
        ScoreBoardCanva.SetActive(true);
    }

    public void VerifyInput()
    {
        submitButton.interactable = (nameField.text.Length > 0);
    }
}
