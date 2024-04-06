using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transpose_On_CLick()
    {
        SceneManager.LoadScene("transpose_list");
    }

    public void row_Operations_On_Click()
    {
        SceneManager.LoadScene("rowOperations_List");
    }

    public void return_To_Game_Opening()
    {
        SceneManager.LoadScene("game_opening");
    }
}
