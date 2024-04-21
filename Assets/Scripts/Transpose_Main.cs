using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transpose_Main : MonoBehaviour
{
    public string save_url = "http://localhost/readTranspose.php?";
    public Text playerName;
    public Text Score;
    public int score;
    public int flag_score;
    public GameObject flag1, flag2, flag3, flag4, flag5;

    // Start is called before the first frame update
    void Start()
    {
        Score.text = "0";
        playerName.text = PlayerPrefs.GetString("name");
        if (Score.text == "0" && PlayerPrefs.GetString("Puzzle_1_Flag") == "")
        {
            StartCoroutine(check_save_file());
            update_Score();
        }
        if (Score.text == "0" && PlayerPrefs.GetString("Puzzle_1_Flag") == "complete")
        {
            score = Convert.ToInt32(Score.text) + 10;
            Score.text = score.ToString();
            flag1.SetActive(true);
        }
        if (Score.text != "0" && PlayerPrefs.GetString("Puzzle_1_Star_Flag") == "complete")
        { 
            update_Score();
            flag1.SetActive(true);
        }
        if (Score.text != "0" && PlayerPrefs.GetString("Puzzle_2_Star_Flag") == "complete")
        {
            update_Score();
            flag2.SetActive(true);
        }
        if (Score.text != "0" && PlayerPrefs.GetString("Puzzle_3_Star_Flag") == "complete")
        {
            update_Score();
            flag3.SetActive(true);
        }
        if (Score.text != "0" && PlayerPrefs.GetString("Puzzle_4_Star_Flag") == "complete")
        {
            update_Score();
            flag4.SetActive(true);
        }
        if (Score.text != "0" && PlayerPrefs.GetString("Puzzle_5_Star_Flag") == "complete")
        {
            update_Score();
            flag5.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tutorial()
    {
        SceneManager.LoadScene("t_puzzle_tutorial");
    }

    public void puzzle_One()
    {
        SceneManager.LoadScene("t_puzzle_one");
    }

    public void puzzle_Two()
    {
        SceneManager.LoadScene("t_puzzle_two");
    }

    public void puzzle_Three() 
    {
        SceneManager.LoadScene("t_puzzle_three");
    }

    public void puzzle_Four()
    {
        SceneManager.LoadScene("t_puzzle_four");
    }

    public void puzzle_Five()
    {
        SceneManager.LoadScene("t_puzzle_five");
    }

    public void returnToMain()
    {
        SceneManager.LoadScene("Main");
    }

    IEnumerator check_save_file()
    {
        string check_save = save_url + "name=" + playerName.text;
        UnityWebRequest www = UnityWebRequest.Get(check_save);
        yield return www.SendWebRequest();
        if (www.error != null)
            Debug.Log("There was an error getting the save file: "
                    + www.error);
        else
        {
            string dataText = www.downloadHandler.text;
            MatchCollection mc = Regex.Matches(dataText, @"_");
            if (mc.Count > 0)
            {
                string[] splitData = Regex.Split(dataText, @"_");
                for (int i = 0; i < mc.Count; i++) 
                {
                    if (splitData[i] == "Puzzle 1complete")
                    {
                        score = Convert.ToInt32(Score.text) + 10;
                        flag_score = Convert.ToInt32(Score.text) + 10;
                        PlayerPrefs.SetString("Score", flag_score.ToString());
                        Score.text = score.ToString();
                        PlayerPrefs.SetString("Puzzle_1_Flag", "complete");
                        PlayerPrefs.SetString("Puzzle_1_Star_Flag", "complete");
                        flag1.SetActive(true);
                    }
                    if (splitData[i] == "Puzzle 2complete")
                    {
                        score = Convert.ToInt32(Score.text) + 10;
                        flag_score = Convert.ToInt32(Score.text) + 10;
                        PlayerPrefs.SetString("Score", flag_score.ToString());
                        Score.text = score.ToString();
                        PlayerPrefs.SetString("Puzzle_2_Flag", "complete");
                        PlayerPrefs.SetString("Puzzle_2_Star_Flag", "complete");
                        flag2.SetActive(true);
                    }
                    if (splitData[i] == "Puzzle 3complete")
                    {
                        score = Convert.ToInt32(Score.text) + 10;
                        flag_score = Convert.ToInt32(Score.text) + 10;
                        PlayerPrefs.SetString("Score", flag_score.ToString());
                        Score.text = score.ToString();
                        PlayerPrefs.SetString("Puzzle_3_Flag", "complete");
                        PlayerPrefs.SetString("Puzzle_3_Star_Flag", "complete");
                        flag3.SetActive(true);
                    }
                    if (splitData[i] == "Puzzle 4complete")
                    {
                        score = Convert.ToInt32(Score.text) + 10;
                        flag_score = Convert.ToInt32(Score.text) + 10;
                        PlayerPrefs.SetString("Score", flag_score.ToString());
                        Score.text = score.ToString();
                        PlayerPrefs.SetString("Puzzle_4_Flag", "complete");
                        PlayerPrefs.SetString("Puzzle_4_Star_Flag", "complete");
                        flag4.SetActive(true);
                    }
                    if (splitData[i] == "Puzzle 5complete")
                    {
                        score = Convert.ToInt32(Score.text) + 10;
                        flag_score = Convert.ToInt32(Score.text) + 10;
                        PlayerPrefs.SetString("Score", flag_score.ToString());
                        PlayerPrefs.SetString("Puzzle_5_Flag", "complete");
                        PlayerPrefs.SetString("Puzzle_5_Star_Flag", "complete");
                        Score.text = score.ToString();
                        flag5.SetActive(true);
                    }
                }
            }
        }
    }

    public void update_Score()
    {
        if (PlayerPrefs.GetString("Puzzle_2_Flag") == "complete" && flag2.activeSelf == false)
        {
            score = Convert.ToInt32(Score.text) + 10;
            flag_score = Convert.ToInt32(Score.text) + 10;
            PlayerPrefs.SetString("Score", flag_score.ToString());
            Score.text = score.ToString();
            flag2.SetActive(true);
        }
        if (PlayerPrefs.GetString("Puzzle_3_Flag") == "complete" && flag3.activeSelf == false)
        {
            score = Convert.ToInt32(Score.text) + 10;
            flag_score = Convert.ToInt32(Score.text) + 10;
            PlayerPrefs.SetString("Score", flag_score.ToString());
            Score.text = score.ToString();
            flag3.SetActive(true);
        }
        if (PlayerPrefs.GetString("Puzzle_4_Flag") == "complete" && flag4.activeSelf == false)
        {
            score = Convert.ToInt32(Score.text) + 10;
            flag_score = Convert.ToInt32(Score.text) + 10;
            PlayerPrefs.SetString("Score", flag_score.ToString());
            Score.text = score.ToString();
            flag4.SetActive(true);
        }
        if (PlayerPrefs.GetString("Puzzle_5_Flag") == "complete" && flag5.activeSelf == false)
        {
            score = Convert.ToInt32(Score.text) + 10;
            flag_score = Convert.ToInt32(Score.text) + 10;
            PlayerPrefs.SetString("Score", flag_score.ToString());
            Score.text = score.ToString();
            flag5.SetActive(true);
        }
    }
}
