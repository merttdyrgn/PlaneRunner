using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public DeathMenu deathMenu;
    
    private string hiScore;
    
    private float score = 0.0f;
    private float speedUpAt = 25.0f;

    private bool isDead = false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
            return;
        
        if(score * 5 / GetComponent<Runner>().getSpeed() >= speedUpAt)
            speedUp();
            
        score += Time.deltaTime * GetComponent<Runner>().getSpeed();
        scoreText.text = ((int)score).ToString();        
    }

    void speedUp()
    {
        if (GetComponent<Runner>().getSpeed() == 32.0f)
            return;
        
        speedUpAt += 25;
        GetComponent<Runner>().setSpeed(2);
        
        Debug.Log("Current Speed: " + GetComponent<Runner>().getSpeed());
    }
    
    public void setScore(float scoreUp)
    {
        score += scoreUp;
    }

    public void gg()
    {
        isDead = true;
        
        if(PlayerPrefs.GetFloat("hiScore") < score)
        PlayerPrefs.SetFloat("hiScore", (int)score);
       
       deathMenu.EndMenu(score);
       
        GetComponent<Runner>().setSpeed(-GetComponent<Runner>().getSpeed());
        Debug.Log("Current Speed: " + GetComponent<Runner>().getSpeed());
    }
}

