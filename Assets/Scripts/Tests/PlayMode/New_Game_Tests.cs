using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class New_Game_Tests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("new_game_scene");
    }
    [UnityTest]
    public IEnumerator New_Game_Check_Objects()
    {
        GameObject newgametxt = GameObject.Find("newgametxt");
        Assert.IsNotNull(newgametxt);
        yield return new WaitForSeconds(.3f);

        GameObject playernametxt = GameObject.Find("playernametxt");
        Assert.IsNotNull(playernametxt);
        yield return new WaitForSeconds(.3f);

        GameObject playername = GameObject.Find("player_name");
        Assert.IsNotNull(playername);
        yield return new WaitForSeconds(.3f);

        GameObject startbtn = GameObject.Find("start_btn");
        Assert.IsNotNull(startbtn);
        yield return new WaitForSeconds(.3f);

        GameObject returnbtn = GameObject.Find("return_btn");
        Assert.IsNotNull(returnbtn);
        yield return new WaitForSeconds(.3f);

    }

    [UnityTest]
    public IEnumerator check_Scene_Name()
    {
        string expected = "new_game_scene";
        string name = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Opening_Screen_C_Button_Check()
    {
        GameObject tbtn = GameObject.Find("return_btn");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "game_opening";
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown] 
    public void Teardown() 
    {
        SceneManager.LoadScene("new_game_scene");
    }
}
