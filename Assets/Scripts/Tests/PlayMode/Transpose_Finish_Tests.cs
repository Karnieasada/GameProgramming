using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Transpose_Finish_Tests
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("transpose_Finish");
    }
   
    [UnityTest]
    public IEnumerator Transpose_Finish_TestsWithEnumeratorPasses()
    {
        GameObject txt = GameObject.Find("completetxt");
        Assert.IsNotNull(txt);
        yield return new WaitForSeconds(.3f);

        GameObject returnbtn = GameObject.Find("return_btn");
        Assert.IsNotNull(returnbtn);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Check_Scene_Name()
    {
        string expected = "transpose_Finish";
        string name = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown] 
    public void TearDown() 
    {
        SceneManager.LoadScene("transpose_Finish");
    }
}
