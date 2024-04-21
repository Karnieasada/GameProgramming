using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Main_Screen_Tests
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Main");
    }

    [UnityTest]
    public IEnumerator Main_Screen_TestsWithEnumeratorPasses()
    {
        GameObject maintxt = GameObject.Find("maintxt");
        Assert.IsNotNull(maintxt);
        yield return new WaitForSeconds(.3f);

        GameObject tbtn = GameObject.Find("transpose");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        GameObject rowbtn = GameObject.Find("row_operations");
        Assert.IsNotNull(rowbtn);
        yield return new WaitForSeconds(.3f);

        GameObject exitbtn = GameObject.Find("exit_to_main");
        Assert.IsNotNull(exitbtn);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Get_Scene_Name()
    {
        string expected = "Main";
        string name = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown]
    public void TearDown()
    {
        SceneManager.LoadScene("Main");
    }
}
