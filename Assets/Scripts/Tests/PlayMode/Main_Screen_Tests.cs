using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

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
    public IEnumerator Main_Screen_T_Puzzle_Check()
    {
        GameObject tbtn = GameObject.Find("transpose");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "transpose_list";
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Main_Screen_R_Puzzle_Check()
    {
        GameObject tbtn = GameObject.Find("row_operations");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "rowOperations_List";
        Assert.AreEqual(expected, name);
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
