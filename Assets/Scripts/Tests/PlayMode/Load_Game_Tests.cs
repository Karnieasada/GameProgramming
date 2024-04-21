using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Load_Game_Tests
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("load_game_scene");
    }

    [UnityTest]
    public IEnumerator Find_Load_Game_Objects()
    {
        GameObject loadtxt = GameObject.Find("loadgametxt");
        Assert.IsNotNull(loadtxt);
        yield return new WaitForSeconds(.3f);

        GameObject playertxt = GameObject.Find("playernametxt");
        Assert.IsNotNull(playertxt);
        yield return new WaitForSeconds(.3f);

        GameObject playerName = GameObject.Find("player_name");
        Assert.IsNotNull(playerName);
        yield return new WaitForSeconds(.3f);

        GameObject loadbtn = GameObject.Find("load_btn");
        Assert.IsNotNull(loadbtn);
        yield return new WaitForSeconds(.3f);

        GameObject returnbtn = GameObject.Find("return_btn");
        Assert.IsNotNull(loadtxt);
        yield return new WaitForSeconds(.3f);

        GameObject deletedata = GameObject.Find("you_will_delete_local_data");
        Assert.IsNotNull(loadtxt);
        yield return new WaitForSeconds(.3f);

    }

    [UnityTest]
    public IEnumerator get_Scene_Name()
    {
        string expected = "load_game_scene";
        string sceneName = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, sceneName);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown]
    public void TearDown() 
    {
        SceneManager.LoadScene("load_game_scene");
    }
}
