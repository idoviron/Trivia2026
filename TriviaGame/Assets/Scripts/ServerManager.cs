using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;
using TMPro;
using NUnit.Framework;

[System.Serializable]
public class QuestionList
{
    public List<Question> questions;
}

[System.Serializable]
public class Question
{
    public int id;
    public string text;
    public string ans1; 
    public string ans2; 
    public string ans3;
    public string ans4;
    public int correctAns;
}
public class ServerManager : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text ans1;
    public TMP_Text ans2;
    public TMP_Text ans3;
    public TMP_Text ans4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetQuestions());
    }

    IEnumerator GetQuestions()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:7038/api/Trivia");
        yield return www.SendWebRequest();

        if (www.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            string json = "{\"questions\":" + www.downloadHandler.text + "}";
            Debug.Log(json);
            //string json = www.downloadHandler.text;
            QuestionList data = JsonUtility.FromJson<QuestionList>(json);

            text.text = data.questions[0].text;
            ans1.text = data.questions[0].ans1;
            ans2.text = data.questions[0].ans2;
            ans3.text = data.questions[0].ans3;
            ans4.text = data.questions[0].ans4;
        }
    }

    public void GetQuestionByID(string id)
    {
        StartCoroutine(GetQuestion(id));
    }

    IEnumerator GetQuestion(string id)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:7038/api/Trivia/" + id);
        yield return www.SendWebRequest();

        if (www.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            string json = "{\"questions\":" + www.downloadHandler.text + "}";
            Debug.Log(json);
            //string json = www.downloadHandler.text;
            QuestionList data = JsonUtility.FromJson<QuestionList>(json);

            text.text = data.questions[0].text;
            ans1.text = data.questions[0].ans1;
            ans2.text = data.questions[0].ans2;
            ans3.text = data.questions[0].ans3;
            ans4.text = data.questions[0].ans4;
        }
    }
}
