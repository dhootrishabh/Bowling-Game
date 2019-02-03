using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GUISkin scoreSkin;
    
    private int currentScore;
    private int playChances;

    public GameObject roundOverCanvas;
    public Text roundOverText;

    public GameObject gameOverCanvas;
    public Text gameOverText;

    private void Start()
    {
        //PlayerPrefs.SetInt("Score", 0);
        currentScore = 0;
        roundOverCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    public void Score()
    {
        currentScore += 1;
        //PlayerPrefs.SetInt("Score", currentScore);
        //print(currentScore);
    }

    private void OnGUI()
    {
        GUI.skin = scoreSkin;
        GUI.Label(new Rect(20,20, 200, 100), "Score: " + currentScore.ToString());
    }

    public void roundFinish()
    {
        
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + currentScore);
        roundOverCanvas.SetActive(true);
        roundOverText.text = currentScore.ToString();
        Invoke("loadLevel", 2f);
        
    }

    void loadLevel()
    {
        playChances = PlayerPrefs.GetInt("Chances");
        playChances -= 1;

        PlayerPrefs.SetInt("Chances", playChances);
        if(playChances <= 0)
        {
            roundOverCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            gameOverText.text = PlayerPrefs.GetInt("Score").ToString();
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("Chances", 3);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
