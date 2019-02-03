using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelLoad : MonoBehaviour {

    public string LeveltoLoad;
    // Use this for initialization
    public void loadLevel()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
    
}
