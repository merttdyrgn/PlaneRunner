using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource menuMusic;
    
    private static MenuMusic music = null;

    void Awake()
    {
        if(GetComponent<MainMenu>().sceneNotice())
            menuMusic.Stop();
        
        if(music == null)
            music = this;
        else if(music != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}
