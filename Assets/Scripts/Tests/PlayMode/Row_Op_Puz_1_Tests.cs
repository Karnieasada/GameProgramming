using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class Row_Op_Puz_1_Tests
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("row_op_puzzle_1");
    }

    [UnityTest]
    public IEnumerator Row_Op_Puz_1_Check_Objects()
    {
        GameObject row1_1 = GameObject.Find("row1_1");
        Assert.IsNotNull(row1_1);
        yield return new WaitForSeconds(.3f);

        GameObject row1_2 = GameObject.Find("row1_2");
        Assert.IsNotNull(row1_2);
        yield return new WaitForSeconds(.3f);

        GameObject row1_3 = GameObject.Find("row1_3");
        Assert.IsNotNull(row1_3);
        yield return new WaitForSeconds(.3f);

        GameObject row2_1 = GameObject.Find("row2_1");
        Assert.IsNotNull(row2_1);
        yield return new WaitForSeconds(.3f);

        GameObject row2_2 = GameObject.Find("row2_2");
        Assert.IsNotNull(row2_2);
        yield return new WaitForSeconds(.3f);

        GameObject row2_3 = GameObject.Find("row2_3");
        Assert.IsNotNull(row2_3);
        yield return new WaitForSeconds(.3f);

        GameObject row3_1 = GameObject.Find("row3_1");
        Assert.IsNotNull(row3_1);
        yield return new WaitForSeconds(.3f);

        GameObject row3_2 = GameObject.Find("row3_2");
        Assert.IsNotNull(row3_2);
        yield return new WaitForSeconds(.3f);

        GameObject row3_3 = GameObject.Find("row3_3");
        Assert.IsNotNull(row3_3);
        yield return new WaitForSeconds(.3f);

        GameObject calc = GameObject.Find("calculate");
        Assert.IsNotNull(calc);
        yield return new WaitForSeconds(.3f);

        GameObject reset = GameObject.Find("reset");
        Assert.IsNotNull(reset);
        yield return new WaitForSeconds(.3f);

        GameObject multi = GameObject.Find("multiplier");
        Assert.IsNotNull(multi);
        yield return new WaitForSeconds(.3f);

        GameObject rowlbl1 = GameObject.Find("row_Label");
        Assert.IsNotNull(rowlbl1);
        yield return new WaitForSeconds(.3f);

        GameObject rowlbl2 = GameObject.Find("row_Label2");
        Assert.IsNotNull(rowlbl2);
        yield return new WaitForSeconds(.3f);

        GameObject rowid = GameObject.Find("row_identity1");
        Assert.IsNotNull(rowid);
        yield return new WaitForSeconds(.3f);

        GameObject rowid2 = GameObject.Find("row_identity2");
        Assert.IsNotNull(rowid2);
        yield return new WaitForSeconds(.3f);

        GameObject sign = GameObject.Find("sign");
        Assert.IsNotNull(sign);
        yield return new WaitForSeconds(.3f);

        GameObject exitbtn = GameObject.Find("exit_to_main");
        Assert.IsNotNull(exitbtn);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Check_Scene_Name()
    {
        string expected = "row_op_puzzle_1";
        string name = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Check_Element_Values()
    {
        string exp1, exp2, exp3, exp4, exp5, exp6, exp7, exp8, exp9;

        exp1 = "1";
        Assert.AreEqual(exp1, GameObject.Find("row1_1").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp2 = "3";
        Assert.AreEqual(exp2, GameObject.Find("row1_2").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp3 = "8";
        Assert.AreEqual(exp3, GameObject.Find("row1_3").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp4 = "-4";
        Assert.AreEqual(exp4, GameObject.Find("row2_1").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp5 = "-11";
        Assert.AreEqual(exp5, GameObject.Find("row2_2").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp6 = "-28";
        Assert.AreEqual(exp6, GameObject.Find("row2_3").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp7 = "5";
        Assert.AreEqual(exp7, GameObject.Find("row3_1").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp8 = "20";
        Assert.AreEqual(exp8, GameObject.Find("row3_2").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);

        exp9 = "61";
        Assert.AreEqual(exp9, GameObject.Find("row3_3").GetComponent<Text>().text);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Check_Finished()
    {
        GameObject.Find("row1_1").GetComponent<Text>().text = "1";
        GameObject.Find("row1_2").GetComponent<Text>().text = "0";
        GameObject.Find("row1_3").GetComponent<Text>().text = "0";
        GameObject.Find("row2_1").GetComponent<Text>().text = "0";
        GameObject.Find("row2_2").GetComponent<Text>().text = "1";
        GameObject.Find("row2_3").GetComponent<Text>().text = "0";
        GameObject.Find("row3_1").GetComponent<Text>().text = "0";
        GameObject.Find("row3_2").GetComponent<Text>().text = "0";
        GameObject.Find("row3_3").GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(3f);
    }

    [UnityTest]
    public IEnumerator Row_Puzzle_1_R_Check()
    {
        GameObject tbtn = GameObject.Find("exit_to_main");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "rowOperations_List";
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown]
    public void Teardown() 
    {
        SceneManager.LoadScene("row_op_puzzle_1");
    }
}
