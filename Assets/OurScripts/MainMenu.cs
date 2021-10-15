using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text highScoreText;
    
    private bool checkScene = false;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("hiScore")).ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ToGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public bool sceneNotice()
    {
        return checkScene;
    }
}
