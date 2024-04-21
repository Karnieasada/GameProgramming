using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class new_game : MonoBehaviour
{
    public Text userName;
    public string gameSaveURL = "http://localhost/create_save.php?";
    public string checkSaveURL = "http://localhost/check_save.php?";
    public GameObject return_text, no_data;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_on_Click()
    {
        return_text.SetActive(false);
        string name = userName.text;
        if (name == PlayerPrefs.GetString("name"))
        {
            return_text.SetActive(true);
        }
        if (name != PlayerPrefs.GetString("name"))
        {
            StartCoroutine(new_game_Check_Save_File());
        }
        else
        {
            return_text.SetActive(true);
        }
    }

    public void load_On_Click()
    {
        check_save_file();
        string name = userName.text;
        if (PlayerPrefs.GetString("name") != name)
        {
            PlayerPrefs.SetString("name", name);
            PlayerPrefs.SetString("Puzzle_1_Flag", "");
            PlayerPrefs.SetString("Puzzle_2_Flag", "");
            PlayerPrefs.SetString("Puzzle_3_Flag", "");
            PlayerPrefs.SetString("Puzzle_4_Flag", "");
            PlayerPrefs.SetString("Puzzle_5_Flag", "");
            PlayerPrefs.SetString("Puzzle_1_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_2_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_3_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_4_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_5_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_1_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_2_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_3_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_4_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_5_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_6_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_1_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_2_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_3_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_4_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_5_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_6_Star_Flag", "");
            SceneManager.LoadScene("Main");
        }
        if (PlayerPrefs.GetString("name") == name)
        {
            no_data.SetActive(false);
            return_text.SetActive(true);
        }
    }

    public void return_On_Click()
    {
        SceneManager.LoadScene("game_opening");
    }

    IEnumerator check_save_file()
    {
        string name = userName.text;
        string url = checkSaveURL + "name=" + name;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string dataText = www.downloadHandler.text;

        if (dataText == "found")
        {
            PlayerPrefs.SetString("name", name);
            PlayerPrefs.SetString("Puzzle_1_Flag", "");
            PlayerPrefs.SetString("Puzzle_2_Flag", "");
            PlayerPrefs.SetString("Puzzle_3_Flag", "");
            PlayerPrefs.SetString("Puzzle_4_Flag", "");
            PlayerPrefs.SetString("Puzzle_5_Flag", "");
            PlayerPrefs.SetString("Puzzle_1_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_2_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_3_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_4_Star_Flag", "");
            PlayerPrefs.SetString("Puzzle_5_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_1_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_2_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_3_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_4_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_5_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_6_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_1_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_2_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_3_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_4_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_5_Star_Flag", "");
            PlayerPrefs.SetString("Row_Puzzle_6_Star_Flag", "");
            SceneManager.LoadScene("Main");
        }
        if (dataText == "no file")
        {
            return_text.SetActive(false);
            no_data.SetActive(true);
        }
    }

    IEnumerator new_game_Check_Save_File()
    {
        string name = userName.text;
        string url = checkSaveURL + "name=" + name;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string dataText = www.downloadHandler.text;

        if (dataText == "found")
        {
            return_text.SetActive(true);
        }
        if (dataText == "no file")
        {
            StartCoroutine(connectToPHP());
        }
        else
        {
            StartCoroutine(connectToPHP());
        }
    }

    IEnumerator connectToPHP()
    {
        string name = userName.text;
        string url = gameSaveURL + "name=" + name;
        UnityWebRequest www = UnityWebRequest.Put(url, name);
        yield return www.SendWebRequest();

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("Score", "0");
        PlayerPrefs.SetString("Puzzle_1_Flag", "");
        PlayerPrefs.SetString("Puzzle_2_Flag", "");
        PlayerPrefs.SetString("Puzzle_3_Flag", "");
        PlayerPrefs.SetString("Puzzle_4_Flag", "");
        PlayerPrefs.SetString("Puzzle_5_Flag", "");
        PlayerPrefs.SetString("Puzzle_1_Star_Flag", "");
        PlayerPrefs.SetString("Puzzle_2_Star_Flag", "");
        PlayerPrefs.SetString("Puzzle_3_Star_Flag", "");
        PlayerPrefs.SetString("Puzzle_4_Star_Flag", "");
        PlayerPrefs.SetString("Puzzle_5_Star_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_1_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_2_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_3_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_4_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_5_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_6_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_1_Star_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_2_Star_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_3_Star_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_4_Star_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_5_Star_Flag", "");
        PlayerPrefs.SetString("Row_Puzzle_6_Star_Flag", "");
        SceneManager.LoadScene("Main");
    }

}
