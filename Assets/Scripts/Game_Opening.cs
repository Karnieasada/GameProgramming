using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Opening : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void New_Game()
    {
        SceneManager.LoadScene("new_game_scene");
    }

    public void Load_Game()
    {
        SceneManager.LoadScene("load_game_scene");
    }

    public void Continue_Game()
    {
        if (PlayerPrefs.GetString("name") != null)
        {
            SceneManager.LoadScene("Main");
        }
    }

}
