using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageCalculations : MonoBehaviour
{
    public Text row1_1, row1_2, row1_3, row2_1, row2_2, row2_3, row3_1, row3_2, row3_3;
    public Text rIdentity1, rIdentity2, multiplier;
    public GameObject explain1, explain2, explain3, ready_btn, ready_text, finish_text, return_btn, step1, step1_1, step1_2, step1_3;
    public GameObject step2, step2_1, step2_2, step3, step3_1, step3_2, step3_3, step4, step4_1, step4_2, step5, step5_1, step6, step6_1;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        explain1.SetActive(true);
        explain2.SetActive(true);
        explain3.SetActive(true);
        ready_text.SetActive(true);
        ready_btn.SetActive(true);
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

    public void tutorial_text()
    {
        while (true)
        {
            if (step1.activeSelf == true)
            {
                step1.SetActive(false);
                step1_1.SetActive(false);
                step1_2.SetActive(false);
                step1_3.SetActive(true);
                step2.SetActive(true);
                step2_1.SetActive(true);
                break;
            }
            if (step2.activeSelf == true)
            {
                step1_3.SetActive(false);
                step2.SetActive(false);
                step2_1.SetActive(false);
                step2_2.SetActive(true);
                step3.SetActive(true);
                step3_1.SetActive(true);
                step3_2.SetActive(true);
                break;
            }
            if (step3.activeSelf == true)
            {
                step2_2.SetActive(false);
                step3.SetActive(false);
                step3_1.SetActive(false);
                step3_2.SetActive(false);
                step3_3.SetActive(true);
                step4.SetActive(true);
                step4_1.SetActive(true);
                break;
            }
            if (step4.activeSelf == true)
            {
                step3_3.SetActive(false);
                step4.SetActive(false);
                step4_1.SetActive(false);
                step4_2.SetActive(true);
                step5.SetActive(true);
                step5_1.SetActive(true);
                break;
            }
            if (step5.activeSelf == true)
            {
                step4_2.SetActive(false);
                step5.SetActive(false);
                step5_1.SetActive(false);
                step6.SetActive(true);
                step6_1.SetActive(true);
                break;
            }
            if (step6.activeSelf == true)
            {
                step6.SetActive(false);
                step6_1.SetActive(false);
                finish_text.SetActive(true);
                return_btn.SetActive(true);
                break;
            }
        }
    }

    public void ready_onClick()
    {
        explain1.SetActive(false);
        explain2.SetActive(false);
        explain3.SetActive(false);
        ready_text.SetActive(false);
        ready_btn.SetActive(false);
        step1.SetActive(true);
        step1_1.SetActive(true);
        step1_2.SetActive(true);
    }

    public void return_onClick()
    {
        SceneManager.LoadScene("rowOperations_List");
    }
}
