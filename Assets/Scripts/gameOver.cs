using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour
{
    [SerializeField] Text Scoretext;
    [SerializeField] Text HighScore;
    int max = 0;

    private void Start()
    {
        //PlayerPrefs.SetInt("Highscore", 0);
        int Pscore = PlayerPrefs.GetInt("Score");
        Scoretext.text = Pscore.ToString();
       
        int max = PlayerPrefs.GetInt("Highscore");
        if (Pscore > max)
        {
            PlayerPrefs.SetInt("Highscore", Pscore);
            HighScore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            HighScore.text = max.ToString();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
