using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _gameview;
    [SerializeField] GameObject _gameover;
    [SerializeField] GameObject pausemenupanelref;

    public AudioSource buttonpressed;

    public TMP_Text highscoretext;
    public TMP_Text scoreText;
    public float score;
    int _highScore;
   // [SerializeField] GameObject Mainmenupanelref;
    private void Update()
    {
        UpdateScore();
       
      
    }
    private void Start()
    {
        score = 0;
        _highScore = PlayerPrefs.GetInt("highscore");
    }
    void UpdateScore()
    {
      
            if (!HealthSystem.instance.IsDead())
            {
            
               // score += Time.deltaTime;
                scoreText.text = "Score: " + (int)score;
                if (score > _highScore)
                {
                    highscoretext.text = "Highscore: " + (int)score;
                    PlayerPrefs.SetInt("highscore", (int)(score));
                }
                else
                {
                    highscoretext.text = "Highscore: " + _highScore;

                }
            
            
        }
    }
    
    private void SaveValues()
    {
        PlayerPrefs.Save();
    }
    //public void Playgame()
    //{
    //    //_mainMenu.SetActive(false);
    //    SceneManager.LoadScene(1);
    // _gameview.SetActive(true);
    //   // SceneManager.LoadScene(0);
    //}
    //public void QuitGame()
    //{
    //    SaveValues();
    //     Application.Quit();
    //}
    public void Restartbutton()
    {
        SaveValues();
       // _mainMenu.SetActive(false);
        _gameover.SetActive(false);
        buttonpressed.Play();
        SceneManager.LoadScene(1);
       //_mainMenu.SetActive(false);
    }
    public void MainMenuButton()
    {
        buttonpressed.Play();
        SceneManager.LoadScene(0);
        //_mainMenu.SetActive(true);
    }
    public void resumebutton()
    {
        buttonpressed.Play();
        Time.timeScale = 1f;
        pausemenupanelref.SetActive(false);

    }
    

}
