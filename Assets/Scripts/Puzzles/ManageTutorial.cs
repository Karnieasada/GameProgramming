using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageTutorial : MonoBehaviour
{
    public Image piece;
    public Image placeHolder;
    float phWdth, phHeigth;
    float timer;
    public GameObject solvetxt, solvebtn, explaintxt, returnbtn;

    // Start is called before the first frame update
    void Start()
    {
        createPlaceHolders();
        createPieces();
        solvetxt.SetActive(false);
        solvebtn.SetActive(false);
        explaintxt.SetActive(false);
        returnbtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            solvetxt.SetActive(true);
            solvebtn.SetActive(true);
        }
    }

    public void createPlaceHolders()
    {
        phWdth = 100;
        phHeigth = 100;
        float nbRows, nbColumns;
        nbRows = 3;
        nbColumns = 3;
        for (int i = 0; i < 9; i++)
        {
            Vector3 centerPosition = new Vector3();
            centerPosition = GameObject.Find("rightSide").transform.position;
            float row, column;
            row = i % 3;
            column = i / 3;
            Vector3 phPosition = new Vector3(centerPosition.x + phWdth * (row - nbRows / 2), centerPosition.y - phHeigth * (column - nbColumns / 2), centerPosition.z);
            Image ph = (Image)(Instantiate(placeHolder, phPosition, Quaternion.identity));
            ph.tag = "" + (i + 1);
            ph.name = "PH" + (i + 1);
            ph.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }

    public void createPieces()
    {
        phWdth = 100;
        phHeigth = 100;
        float nbRows, nbColumns;
        nbRows = 3;
        nbColumns = 3;
        for (int i = 0; i < 9; i++)
        {
            Vector3 centerPosition = new Vector3();
            centerPosition = GameObject.Find("leftSide").transform.position;
            float row, column;
            row = i % 3;
            column = i / 3;
            Vector3 phPosition = new Vector3(centerPosition.x + phWdth * (row - nbRows / 2), centerPosition.y - phHeigth * (column - nbColumns / 2), centerPosition.z);
            Image ph = (Image)(Instantiate(piece, phPosition, Quaternion.identity));
            ph.tag = "" + (i + 1);
            ph.name = "Piece" + (i + 1);
            ph.transform.SetParent(GameObject.Find("Canvas").transform);
            Sprite[] allSprites = Resources.LoadAll<Sprite>("Tutorial");
            Sprite s1 = allSprites[i];
            ph.GetComponent<UnityEngine.UI.Image>().sprite = s1;
        }
    }

    public void solved()
    {
        GameObject img;
        GameObject ph;
        string tag, phTag;
        for (int i = 0;i < 9;i++) 
        {
            int num = i + 1;
            tag = num.ToString();
            img = GameObject.Find("Piece" + tag);
            phTag = transpose_tag(tag);
            ph = GameObject.Find("PH" +  phTag);

            img.transform.position = ph.transform.position;
        }

        createPieces();
        explaintxt.SetActive(true);
        returnbtn.SetActive(true);
    }

    public string transpose_tag(string tag)
    {
        string t_tag = "";
        if (tag == "1" || tag == "9")
        {
            t_tag = tag;
        }
        if (tag == "2")
        {
            t_tag = "4";
        }
        if (tag == "3")
        {
            t_tag = "7";
        }
        if (tag == "4")
        {
            t_tag = "2";
        }
        if (tag == "5")
        {
            t_tag = "5";
        }
        if (tag == "6")
        {
            t_tag = "8";
        }
        if (tag == "7")
        {
            t_tag = "3";
        }
        if (tag == "8")
        {
            t_tag = "6";
        }

        return t_tag;
    }

    public void backToPick()
    {
        SceneManager.LoadScene("transpose_list");
    }
}
