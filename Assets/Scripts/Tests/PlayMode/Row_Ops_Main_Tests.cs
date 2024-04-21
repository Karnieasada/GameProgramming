using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class Row_Ops_Main_Tests
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("rowOperations_List");
    }

    [UnityTest]
    public IEnumerator Row_Ops_Main_Check_Objects()
    {
        GameObject txt = GameObject.Find("opstxt");
        Assert.IsNotNull(txt);
        yield return new WaitForSeconds(.3f);

        GameObject returnbtn = GameObject.Find("returnbtn");
        Assert.IsNotNull(returnbtn);
        yield return new WaitForSeconds(.3f);

        GameObject tutorial = GameObject.Find("tutorial");
        Assert.IsNotNull(tutorial);
        yield return new WaitForSeconds(.3f);

        GameObject tutorial2 = GameObject.Find("tutorial2");
        Assert.IsNotNull(tutorial2);
        yield return new WaitForSeconds(.3f);

        GameObject puzzle1 = GameObject.Find("puzzle1");
        Assert.IsNotNull(puzzle1);
        yield return new WaitForSeconds(.3f);

        GameObject puzzle2 = GameObject.Find("puzzle2");
        Assert.IsNotNull(puzzle2);
        yield return new WaitForSeconds(.3f);

        GameObject puzzle3 = GameObject.Find("puzzle3");
        Assert.IsNotNull(puzzle3);
        yield return new WaitForSeconds(.3f);

        GameObject puzzle4 = GameObject.Find("puzzle4");
        Assert.IsNotNull(puzzle4);
        yield return new WaitForSeconds(.3f);

        GameObject puzzle5 = GameObject.Find("puzzle5");
        Assert.IsNotNull(puzzle5);
        yield return new WaitForSeconds(.3f);

        GameObject puzzle6 = GameObject.Find("puzzle6");
        Assert.IsNotNull(puzzle6);
        yield return new WaitForSeconds(.3f);

        GameObject name = GameObject.Find("name");
        Assert.IsNotNull(name);
        yield return new WaitForSeconds(.3f);

        GameObject score = GameObject.Find("score");
        Assert.IsNotNull(score);
        yield return new WaitForSeconds(.3f);

        GameObject scorelbl = GameObject.Find("score_lbl");
        Assert.IsNotNull(scorelbl);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator check_Name()
    {
        string expected = "rowOperations_List";
        string name = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator check_Score() 
    {
        string expected = "0";
        string txt = GameObject.Find("score").GetComponent<Text>().text;
        Assert.AreEqual(expected, txt);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown]
    public void TearDown() 
    {
        SceneManager.LoadScene("rowOperations_List");
    }
}
