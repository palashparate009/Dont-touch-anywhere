using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    bool isDead;
    [SerializeField] GameObject GAMEOVER_panel;
    [SerializeField] GameObject GAMEVIEW_panelref;

    public static HealthSystem instance;
    private void Awake()
    {
        if(instance==null) {
            instance = this;
        }
    }
    void Start()
    {
        isDead = false;
        //GAMEVIEW_panelref.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        healthsystem();
    }
    public void healthsystem()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        if (health <= 0)
        {
            isDead= true;
            PlayerPrefs.Save();
            GAMEOVER_panel.SetActive(true);
            GAMEVIEW_panelref.SetActive(false);
            
        }
    }
    public bool IsDead()
    {
        return isDead;
    }
}
