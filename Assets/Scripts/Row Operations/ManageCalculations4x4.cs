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

public class ManageCalculations4x4 : MonoBehaviour
{
    public string updateURL = "http://localhost/updateRowOpScore.php?";
    public Text row1_1, row1_2, row1_3, row1_4, row2_1, row2_2, row2_3, row2_4, row3_1, row3_2, row3_3, row3_4, row4_1, row4_2, row4_3, row4_4;
    public Text rIdentity1, rIdentity2, multiplier;

    // Start is called before the first frame update
    void Start()
    {
        set_Numbers();
        check_text();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calculate_onClick()
    {
        string id_Main = rIdentity1.text;
        string id_Change = rIdentity2.text;
        string find_row, change_row;
        find_row = "row" + id_Main + "_1";
        change_row = "row" + id_Change + "_1";

        if (find_row == "row1_1")
        {
            string val1, val2, val3, val4;
            val1 = row1_1.text;
            val2 = row1_2.text;
            val3 = row1_3.text;
            val4 = row1_4.text;

            calculate(change_row, val1, val2, val3, val4);
        }
        if (find_row == "row2_1")
        {
            string val1, val2, val3, val4;
            val1 = row2_1.text;
            val2 = row2_2.text;
            val3 = row2_3.text;
            val4 = row2_4.text;

            calculate(change_row, val1, val2, val3, val4);
        }
        if (find_row == "row3_1")
        {
            string val1, val2, val3, val4;
            val1 = row3_1.text;
            val2 = row3_2.text;
            val3 = row3_3.text;
            val4 = row3_4.text;

            calculate(change_row, val1, val2, val3, val4);
        }
        if (find_row == "row4_1")
        {
            string val1, val2, val3, val4;
            val1 = row4_1.text;
            val2 = row4_2.text;
            val3 = row4_3.text;
            val4 = row4_4.text;

            calculate(change_row, val1, val2, val3, val4);
        }
    }

    public void calculate(string identity, string val1, string val2, string val3, string val4)
    {
        int m_Val1, m_Val2, m_Val3, m_Val4;
        int c_Val1, c_Val2, c_Val3, c_Val4;
        int mod;

        mod = Convert.ToInt32(multiplier.text);
        m_Val1 = Convert.ToInt32(val1) * mod;
        m_Val2 = Convert.ToInt32(val2) * mod;
        m_Val3 = Convert.ToInt32(val3) * mod;
        m_Val4 = Convert.ToInt32(val4) * mod;

        rIdentity1.gameObject.transform.parent.GetComponent<InputField>().text = "";
        rIdentity2.gameObject.transform.parent.GetComponent<InputField>().text = "";
        multiplier.gameObject.transform.parent.GetComponent<InputField>().text = "";

        if (identity == "row1_1")
        {

            c_Val1 = Convert.ToInt32(row1_1.text) + m_Val1;
            c_Val2 = Convert.ToInt32(row1_2.text) + m_Val2;
            c_Val3 = Convert.ToInt32(row1_3.text) + m_Val3;
            c_Val4 = Convert.ToInt32(row1_4.text) + m_Val4;

            row1_1.text = c_Val1.ToString();
            row1_2.text = c_Val2.ToString();
            row1_3.text = c_Val3.ToString();
            row1_4.text = c_Val4.ToString();
        }
        if (identity == "row2_1")
        {

            c_Val1 = Convert.ToInt32(row2_1.text) + m_Val1;
            c_Val2 = Convert.ToInt32(row2_2.text) + m_Val2;
            c_Val3 = Convert.ToInt32(row2_3.text) + m_Val3;
            c_Val4 = Convert.ToInt32(row2_4.text) + m_Val4;

            row2_1.text = c_Val1.ToString();
            row2_2.text = c_Val2.ToString();
            row2_3.text = c_Val3.ToString();
            row2_4.text = c_Val4.ToString();
        }
        if (identity == "row3_1")
        {
            c_Val1 = Convert.ToInt32(row3_1.text) + m_Val1;
            c_Val2 = Convert.ToInt32(row3_2.text) + m_Val2;
            c_Val3 = Convert.ToInt32(row3_3.text) + m_Val3;
            c_Val4 = Convert.ToInt32(row3_4.text) + m_Val4;

            row3_1.text = c_Val1.ToString();
            row3_2.text = c_Val2.ToString();
            row3_3.text = c_Val3.ToString();
            row3_4.text = c_Val4.ToString();
        }
        if (identity == "row4_1")
        {
            c_Val1 = Convert.ToInt32(row4_1.text) + m_Val1;
            c_Val2 = Convert.ToInt32(row4_2.text) + m_Val2;
            c_Val3 = Convert.ToInt32(row4_3.text) + m_Val3;
            c_Val4 = Convert.ToInt32(row4_4.text) + m_Val4;

            row4_1.text = c_Val1.ToString();
            row4_2.text = c_Val2.ToString();
            row4_3.text = c_Val3.ToString();
            row4_4.text = c_Val4.ToString();
        }

        check_Done();
    }

    public void set_Numbers()
    {
        string scene_TXT = get_Scene_Name();
        if (scene_TXT == "row_op_puzzle_4")
        {
            row1_1.text = "1";
            row1_2.text = "1";
            row1_3.text = "1";
            row1_4.text = "-1";
            row2_1.text = "2";
            row2_2.text = "3";
            row2_3.text = "-5";
            row2_4.text = "1";
            row3_1.text = "1";
            row3_2.text = "3";
            row3_3.text = "-12";
            row3_4.text = "-1";
            row4_1.text = "-1";
            row4_2.text = "-1";
            row4_3.text = "-1";
            row4_4.text = "2";
        }
        if (scene_TXT == "row_op_puzzle_5")
        {
            row1_1.text = "1";
            row1_2.text = "7";
            row1_3.text = "3";
            row1_4.text = "9";
            row2_1.text = "6";
            row2_2.text = "43";
            row2_3.text = "18";
            row2_4.text = "32";
            row3_1.text = "8";
            row3_2.text = "56";
            row3_3.text = "25";
            row3_4.text = "67";
            row4_1.text = "5";
            row4_2.text = "40";
            row4_3.text = "15";
            row4_4.text = "-64";
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
            if (row1_2.text == "0")
            {
                if (row1_3.text == "0")
                {
                    if (row1_4.text == "0")
                    {
                        if (row2_1.text == "0")
                        {
                            if (row2_2.text == "1")
                            {
                                if (row2_3.text == "0")
                                {
                                    if (row2_4.text == "0")
                                    {
                                        if (row3_1.text == "0")
                                        {
                                            if (row3_2.text == "0")
                                            {
                                                if (row3_3.text == "1")
                                                {
                                                    if (row3_4.text == "0")
                                                    {
                                                        if (row4_1.text == "0")
                                                        {
                                                            if (row4_2.text == "0")
                                                            {
                                                                if (row4_3.text == "0")
                                                                {
                                                                    if (row4_4.text == "1")
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
        if (scene_TXT == "row_op_puzzle_4")
        {
            PlayerPrefs.SetString("Row_Puzzle_4_Flag", "complete");
            PlayerPrefs.SetString("Row_Puzzle_4_Star_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle4";
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
        if (scene_TXT == "row_op_puzzle_5")
        {
            PlayerPrefs.SetString("Row_Puzzle_5_Flag", "complete");
            PlayerPrefs.SetString("Row_Puzzle_5_Star_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle5";
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
    }

    public void check_text()
    {

    }
}
