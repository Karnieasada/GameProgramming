using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Transpose_Puz_2_Tests
{

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("t_puzzle_two");
    }

    [UnityTest]
    public IEnumerator Check_Pieces_Spawn()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject piece = GameObject.Find("Piece" + (i + 1));
            Assert.NotNull(piece);
        }
        yield return new WaitForSeconds(.3f);
        for (int i = 0; i < 9; i++)
        {
            GameObject ph = GameObject.Find("PH" + (i + 1));
            Assert.NotNull(ph);
        }
        yield return new WaitForSeconds(.3f);
    }

    [UnityTest]
    public IEnumerator Check_Scene_Name()
    {
        string expected = "t_puzzle_two";
        string active = SceneManager.GetActiveScene().name;
        Assert.AreEqual(expected, active);
        yield return new WaitForSeconds(.2f);
    }

    [UnityTest]
    public IEnumerator Check_Return_Button()
    {
        GameObject button = GameObject.Find("exit_to_main");
        Assert.NotNull(button);
        yield return new WaitForSeconds(.2f);
    }

    [UnityTest]
    public IEnumerator Check_Sides_Present()
    {
        GameObject leftside = GameObject.Find("leftSide");
        Assert.NotNull(leftside);
        yield return new WaitForSeconds(.2f);

        GameObject rightside = GameObject.Find("rightSide");
        Assert.NotNull(rightside);
        yield return new WaitForSeconds(.2f);
    }

    [UnityTest]
    public IEnumerator Position_Test()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject piece = GameObject.Find("Piece" + (i + 1));
            Vector3 piece_pos = piece.transform.position;
            GameObject ph = GameObject.Find("PH" + (i + 1));
            Vector3 ph_pos = ph.transform.position;
            Assert.AreNotEqual(piece_pos, ph_pos);
        }

        yield return new WaitForSeconds(.2f);
    }

    [UnityTest]
    public IEnumerator T_Puzzle_2_R_Check()
    {
        GameObject tbtn = GameObject.Find("exit_to_main");
        Assert.IsNotNull(tbtn);
        yield return new WaitForSeconds(.3f);

        tbtn.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(1f);

        string name = SceneManager.GetActiveScene().name;
        string expected = "transpose_list";
        Assert.AreEqual(expected, name);
        yield return new WaitForSeconds(.3f);
    }

    [TearDown]
    public void TearDown()
    {
        SceneManager.LoadScene("t_puzzle_two");

    }
}

