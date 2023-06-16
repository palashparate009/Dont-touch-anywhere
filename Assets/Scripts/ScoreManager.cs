using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text highscoretext;
    public TMP_Text scoreText;
    public float score;
    public int highscore;

    string HS_Key = "score";

    // Use this for initialization
    void Start()
    {
        score = 0;
        highscore = -1;

        if (PlayerPrefs.HasKey(HS_Key) == true)
        {
            highscore = PlayerPrefs.GetInt(HS_Key);
            //Debug.Log("HIGHSCORE " + highscore);
            highscoretext.text = highscore.ToString();
        }
        else
        {
            PlayerPrefs.SetInt(HS_Key, highscore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            score += Time.deltaTime;

            scoreText.text = " " + (int)score;

        if (score >= highscore)
        {
            highscore = (int)score;
            //SaveVales();
            highscoretext.text = highscore.ToString();

        }

    }

    private void OnDisable()
    {
        SaveValues();
    }

    private void SaveValues()
    {
        PlayerPrefs.SetInt(HS_Key, highscore);
        PlayerPrefs.Save();
    }

    public void OnDelete()
    {
        PlayerPrefs.DeleteAll();
    }

}
