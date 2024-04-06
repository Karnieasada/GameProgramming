using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ManageCalculations3x3 : MonoBehaviour
{
    public string updateURL = "http://localhost/updateRowOpScore.php?";
    public Text row1_1, row1_2, row1_3, row2_1, row2_2, row2_3, row3_1, row3_2, row3_3;
    public Text rIdentity1, rIdentity2, multiplier;
    public GameObject reset_text, start_here, i_might_try_and_trick_you;

    // Start is called before the first frame update
    void Start()
    {
        set_Numbers();
        check_Text();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calculate_onClick()
    {
        remove_Text();

        string id_Main = rIdentity1.text;
        string id_Change = rIdentity2.text;
        string find_row, change_row;
        find_row = "row" + id_Main + "_1";
        change_row = "row" + id_Change + "_1";

        if (find_row == "row1_1")
        {
            string val1, val2, val3;
            val1 = row1_1.text;
            val2 = row1_2.text;
            val3 = row1_3.text;

            calculate(change_row, val1, val2, val3);
        }
        if (find_row == "row2_1")
        {
            string val1, val2, val3;
            val1 = row2_1.text;
            val2 = row2_2.text;
            val3 = row2_3.text;

            calculate(change_row, val1, val2, val3);
        }
        if (find_row == "row3_1")
        {
            string val1, val2, val3;
            val1 = row3_1.text;
            val2 = row3_2.text;
            val3 = row3_3.text;

            calculate(change_row, val1, val2, val3);
        }
    }

    public void calculate(string identity, string val1, string val2, string val3)
    {
        int m_Val1, m_Val2, m_Val3;
        int c_Val1, c_Val2, c_Val3;
        int mod;

        mod = Convert.ToInt32(multiplier.text);
        m_Val1 = Convert.ToInt32(val1) * mod;
        m_Val2 = Convert.ToInt32(val2) * mod;
        m_Val3 = Convert.ToInt32(val3) * mod;

        rIdentity1.gameObject.transform.parent.GetComponent<InputField>().text = "";
        rIdentity2.gameObject.transform.parent.GetComponent<InputField>().text = "";
        multiplier.gameObject.transform.parent.GetComponent<InputField>().text = "";

        if (identity == "row1_1")
        {

            c_Val1 = Convert.ToInt32(row1_1.text) + m_Val1;
            c_Val2 = Convert.ToInt32(row1_2.text) + m_Val2;
            c_Val3 = Convert.ToInt32(row1_3.text) + m_Val3;

            row1_1.text = c_Val1.ToString();
            row1_2.text = c_Val2.ToString();
            row1_3.text = c_Val3.ToString();
        }
        if (identity == "row2_1")
        {

            c_Val1 = Convert.ToInt32(row2_1.text) + m_Val1;
            c_Val2 = Convert.ToInt32(row2_2.text) + m_Val2;
            c_Val3 = Convert.ToInt32(row2_3.text) + m_Val3;

            row2_1.text = c_Val1.ToString();
            row2_2.text = c_Val2.ToString();
            row2_3.text = c_Val3.ToString();
        }
        if (identity == "row3_1")
        {
            c_Val1 = Convert.ToInt32(row3_1.text) + m_Val1;
            c_Val2 = Convert.ToInt32(row3_2.text) + m_Val2;
            c_Val3 = Convert.ToInt32(row3_3.text) + m_Val3;

            row3_1.text = c_Val1.ToString();
            row3_2.text = c_Val2.ToString();
            row3_3.text = c_Val3.ToString();
        }

        check_Done();
    }

    public void set_Numbers()
    {
        string scene_TXT = get_Scene_Name();
        if (scene_TXT == "row_op_puzzle_1")
        {
            row1_1.text = "1";
            row1_2.text = "3";
            row1_3.text = "8";
            row2_1.text = "-4";
            row2_2.text = "-11";
            row2_3.text = "-28";
            row3_1.text = "5";
            row3_2.text = "20";
            row3_3.text = "61";
        }
        if (scene_TXT == "row_op_puzzle_2")
        {
            row1_1.text = "10";
            row1_2.text = "29";
            row1_3.text = "52";
            row2_1.text = "1";
            row2_2.text = "3";
            row2_3.text = "5";
            row3_1.text = "10";
            row3_2.text = "26";
            row3_3.text = "59";
        }
        if (scene_TXT == "row_op_puzzle_3")
        {
            row1_1.text = "14";
            row1_2.text = "43";
            row1_3.text = "84";
            row2_1.text = "13";
            row2_2.text = "40";
            row2_3.text = "78";
            row3_1.text = "8";
            row3_2.text = "15";
            row3_3.text = "49";
        }
    }

    public void reset_On_Click()
    {
        set_Numbers();
    }

    public string get_Scene_Name()
    {
        string scene_TXT = SceneManager.GetActiveScene().name;
        return scene_TXT;
    }

    public void check_Done()
    {
        if (row1_1.text == "1")
        {
            if(row1_2.text == "0")
            {
                if (row1_3.text == "0") 
                {
                    if (row2_1.text == "0")
                    {
                        if (row2_2.text == "1")
                        {
                            if (row2_3.text == "0")
                            {
                                if (row3_1.text == "0")
                                {
                                    if (row3_2.text == "0")
                                    {
                                        if (row3_3.text == "1")
                                        {
                                            StartCoroutine(update_Flags());
                                            SceneManager.LoadScene("row_op_Finish");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator update_Flags()
    {
        string scene_TXT = get_Scene_Name();
        string name = PlayerPrefs.GetString("name");
        if (scene_TXT == "row_op_puzzle_1")
        {
            PlayerPrefs.SetString("Row_Puzzle_1_Flag", "complete");
            PlayerPrefs.SetString("Row_Puzzle_1_Star_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle1";
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
        if (scene_TXT == "row_op_puzzle_2")
        {
            PlayerPrefs.SetString("Row_Puzzle_2_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle2";
            PlayerPrefs.SetString("Row_Puzzle_2_Star_Flag", "complete");
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
        if (scene_TXT == "row_op_puzzle_3")
        {
            PlayerPrefs.SetString("Row_Puzzle_3_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle3";
            PlayerPrefs.SetString("Puzzle_3_Star_Flag", "complete");
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
    }

    public void check_Text()
    {
        string scene_TXT = get_Scene_Name();
        if (scene_TXT == "row_op_puzzle_1")
        {
            reset_text.SetActive(true);
        }
        if (scene_TXT == "row_op_puzzle_2")
        {
            start_here.SetActive(true);
        }
        if (scene_TXT == "row_op_puzzle_3")
        {
            i_might_try_and_trick_you.SetActive(true);
        }
    }

    public void remove_Text()
    {
        string scene_TXT = get_Scene_Name();
        if (scene_TXT == "row_op_puzzle_1" && reset_text.activeSelf == true)
        {
            reset_text.SetActive(false);
        }
        if (scene_TXT == "row_op_puzzle_2" && start_here.activeSelf == true)
        {
            start_here.SetActive(false);
        }
        if (scene_TXT == "row_op_puzzle_3" && i_might_try_and_trick_you.activeSelf == true)
        {
            i_might_try_and_trick_you.SetActive(false);
        }
    }
}
