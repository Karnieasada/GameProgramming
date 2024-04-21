using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class Transpose_Main_Tests
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("transpose_list");
    }

    [UnityTest]
    public IEnumerator Transpose_Main_Check_Objects()
    {
        GameObject txt = GameObject.Find("ttxt");
        Assert.IsNotNull(txt);
        yield return new WaitForSeconds(.3f);

        GameObject returnbtn = GameObject.Find("return2Main");
        Assert.IsNotNull(returnbtn);
        yield return new WaitForSeconds(.3f);

        GameObject tutorial = GameObject.Find("tutorial");
        Assert.IsNotNull(tutorial);
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
        string expected = "transpose_list";
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
        SceneManager.LoadScene("transpose_list");
    }
}
