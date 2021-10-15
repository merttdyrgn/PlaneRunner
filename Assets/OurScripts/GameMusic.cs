using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource gameMusic;
    
    private static GameMusic music = null;
    
    void Awake()
    {
        if(GetComponent<DeathMenu>().sceneNotice())
            gameMusic.Stop();
        
        if(music == null)
            music = this;
        else if(music != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
