using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageCalculationsTutorial2 : MonoBehaviour
{
    public Text row1_1, row1_2, row1_3, row2_1, row2_2, row2_3, row3_1, row3_2, row3_3;
    public Text rIdentity1, rIdentity2, multiplier;
    public Text rSwitchID1, rSwitchID2;
    public GameObject tutText1, tutText2, tutText3, tutText4, tutText5, tutText6, tutText7, tutText8, readyTXT, finTXT;
    public GameObject readyBTN, returnBTN;

    void Start()
    {
        readyTXT.SetActive(true);
        readyBTN.SetActive(true);
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

        tutorial_text();

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

        tutorial_text();

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

    public void ready_onClick()
    {
        readyTXT.SetActive(false);
        readyBTN.SetActive(false);
        tutText1.SetActive(true);
        tutText2.SetActive(true);
    }

    public void tutorial_text()
    {
        while (true)
        {
           if(tutText1.activeSelf == true)
           {
                tutText1.SetActive(false);
                tutText2.SetActive(false);
                tutText3.SetActive(true);
                break;
           }
           if (tutText3.activeSelf == true)
           {
                tutText3.SetActive(false);
                tutText4.SetActive(true);
                break;
           }
           if (tutText4.activeSelf == true)
           {
                tutText4.SetActive(false);
                tutText5.SetActive(true);
                break;
           }
           if (tutText5.activeSelf == true)
           {
                tutText5.SetActive(false);
                tutText6.SetActive(true);
                break;
           }
           if (tutText6.activeSelf == true)
           {
                tutText6.SetActive(false);
                tutText7.SetActive(true);    
                break;
           }
           if (tutText7.activeSelf == true)
           {
                tutText7.SetActive(false);
                tutText8.SetActive(true);
                break;
           }
           if (tutText8.activeSelf == true)
           {
                tutText8.SetActive(false);
                returnBTN.SetActive(true);
                finTXT.SetActive(true);
                break;
           }
        }
    }

    public void return_onClick()
    {
        SceneManager.LoadScene("rowOperations_List");
    }

    public void exit_Puzzle()
    {
        SceneManager.LoadScene("rowOperations_List");
    }
}
