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

public class ManageSwitch3x3 : MonoBehaviour
{
    public string updateURL = "http://localhost/updateRowOpScore.php?";
    public Text row1_1, row1_2, row1_3, row2_1, row2_2, row2_3, row3_1, row3_2, row3_3;
    public Text rIdentity1, rIdentity2, multiplier;
    public Text rSwitchID1, rSwitchID2;

    void Start()
    {
        set_Numbers();
    }

    // Update is called once per frame
    void Update()
    {
        //check_Done();
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

    public void switch_vals()
    {
        string id_Main = rSwitchID1.text;
        string id_Change = rSwitchID2.text;
        string find_row, change_row;
        find_row = "row" + id_Main + "_1";
        change_row = "row" + id_Change + "_1";
        string temp1, temp2, temp3;

        rSwitchID1.gameObject.transform.parent.GetComponent<InputField>().text = "";
        rSwitchID2.gameObject.transform.parent.GetComponent<InputField>().text = "";

        

        if (find_row == "row1_1")
        {
            temp1 = row1_1.text;
            temp2 = row1_2.text;
            temp3 = row1_3.text;
            if (change_row == "row2_1")
            {
                row1_1.text = row2_1.text;
                row1_2.text = row2_2.text;
                row1_3.text = row2_3.text;
                row2_1.text = temp1;
                row2_2.text = temp2;
                row2_3.text = temp3;
            }
            if (change_row == "row3_1")
            {
                row1_1.text = row3_1.text;
                row1_2.text = row3_2.text;
                row1_3.text = row3_3.text;
                row3_1.text = temp1;
                row3_2.text = temp2;
                row3_3.text = temp3;
            }
            else
            {
                return;
            }
        }
        if (find_row == "row2_1")
        {
            temp1 = row2_1.text;
            temp2 = row2_2.text;
            temp3 = row2_3.text;
            if (change_row == "row1_1")
            {
                row2_1.text = row1_1.text;
                row2_2.text = row1_2.text;
                row2_3.text = row1_3.text;
                row1_1.text = temp1;
                row1_2.text = temp2;
                row1_3.text = temp3;
            }
            if (change_row == "row3_1")
            {
                row2_1.text = row3_1.text;
                row2_2.text = row3_2.text;
                row2_3.text = row3_3.text;
                row3_1.text = temp1;
                row3_2.text = temp2;
                row3_3.text = temp3;
            }
            else
            {
                return;
            }

        }
        if (find_row == "row3_1")
        {
            temp1 = row3_1.text;
            temp2 = row3_2.text;
            temp3 = row3_3.text;
            if (change_row == "row1_1")
            {
                row3_1.text = row1_1.text;
                row3_2.text = row1_2.text;
                row3_3.text = row1_3.text;
                row1_1.text = temp1;
                row1_2.text = temp2;
                row1_3.text = temp3;
            }
            if (change_row == "row2_1")
            {
                row3_1.text = row2_1.text;
                row3_2.text = row2_2.text;
                row3_3.text = row2_3.text;
                row2_1.text = temp1;
                row2_2.text = temp2;
                row2_3.text = temp3;
            }
            else
            {
                return;
            }
        }
    }

    public void set_Numbers()
    {
        string scene_TXT = get_Scene_Name();
        if (scene_TXT == "row_op_puzzle_6")
        {
            row1_1.text = "5";
            row1_2.text = "9";
            row1_3.text = "36";
            row2_1.text = "1";
            row2_2.text = "6";
            row2_3.text = "7";
            row3_1.text = "3";
            row3_2.text = "19";
            row3_3.text = "21";
        }
    }

    public void check_Done()
    {
        if (row1_1.text == "1")
        {
            if (row1_2.text == "0")
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
        if (scene_TXT == "row_op_puzzle_6")
        {
            PlayerPrefs.SetString("Row_Puzzle_6_Flag", "complete");
            PlayerPrefs.SetString("Row_Puzzle_6_Star_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle6";
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
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

    public void exit_Puzzle()
    {
        SceneManager.LoadScene("rowOperations_List");
    }
}
