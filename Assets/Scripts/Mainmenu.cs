using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public AudioSource buttonpressed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Playgame()
    {
        buttonpressed.Play();
        SceneManager.LoadScene(1);
      
    }
    public void QuitGame()
    {
        buttonpressed.Play();
        Application.Quit();
    }
}
