using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using Castle.Components.DictionaryAdapter.Xml;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class Game_Opening_Tests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("game_opening");
    }
    [UnityTest]
    public IEnumerator Game_Opening_Find_Objects()
    {
        GameObject openTXT = GameObject.Find("opening_txt");
        Assert.IsNotNull(openTXT);
        yield return new WaitForSeconds(.3f);

        GameObject new_game_btn = GameObject.Find("new_game_btn");
        Assert.IsNotNull(new_game_btn);
        yield return new WaitForSeconds(.3f);

        GameObject load_game_btn = GameObject.Find("load_game_btn");
        Assert.IsNotNull(load_game_btn);
        yield return new WaitForSeconds(.3f);

        GameObject continue_game_btn = GameObject.Find("continue_game_btn");
        Assert.IsNotNull(continue_game_btn);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Get_Scene_Name()
    {
        string expected = "game_opening";
        string name = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Opening_Screen_N_Button_Check()
    {
        GameObject tbtn = GameObject.Find("new_game_btn");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "new_game_scene";
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Opening_Screen_L_Button_Check()
    {
        GameObject tbtn = GameObject.Find("load_game_btn");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "load_game_scene";
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Opening_Screen_C_Button_Check()
    {
        GameObject tbtn = GameObject.Find("continue_game_btn");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "Main";
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown]
    public void TearDown()
    {
        SceneManager.LoadScene("game_opening");
    }
}
