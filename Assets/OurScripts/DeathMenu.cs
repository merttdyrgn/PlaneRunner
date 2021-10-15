using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private AudioSource audioSource;
    public Text scoreText;

    public Image backgroundImage;

    private bool isShowned = false;

    private float transition = 0.0f;
    
    private bool checkScene = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Action action = audioSource.Play;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShowned)
            return;

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }
    
    public void EndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowned = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public bool sceneNotice()
    {
        return checkScene;
    }
}
