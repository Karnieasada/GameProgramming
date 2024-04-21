using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Transpose_Puz_1_Tests
{

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("t_puzzle_one");
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
        string expected = "t_puzzle_one";
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

    [TearDown]
    public void TearDown() 
    {
        SceneManager.LoadScene("t_puzzle_one");
    }
}
