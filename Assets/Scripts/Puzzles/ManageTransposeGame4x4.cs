using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageTranspose4x4 : MonoBehaviour
{
    public string updateURL = "http://localhost/updateTransposeScore.php?";
    public Image piece;
    public Image placeHolder;
    float phWdth, phHeigth;
    public GameObject check_img, check_PH;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        createPlaceHolders();
        createPieces();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 30)
        {
            check_Finished();
        }
    }


    public void createPlaceHolders()
    {
        phWdth = 100;
        phHeigth = 100;
        float nbRows, nbColumns;
        nbRows = 4;
        nbColumns = 4;
        for (int i = 0; i < 16; i++)
        {
            Vector3 centerPosition = new Vector3();
            centerPosition = GameObject.Find("rightSide").transform.position;
            float row, column;
            row = i % 4;
            column = i / 4;
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
        nbRows = 4;
        nbColumns = 4;

        string scene = get_Scene_Name();
        if (scene == "t_puzzle_four")
        {
            for (int i = 0; i < 16; i++)
            {
                Vector3 centerPosition = new Vector3();
                centerPosition = GameObject.Find("leftSide").transform.position;
                float row, column;
                row = i % 4;
                column = i / 4;
                Vector3 phPosition = new Vector3(centerPosition.x + phWdth * (row - nbRows / 2), centerPosition.y - phHeigth * (column - nbColumns / 2), centerPosition.z);
                Image ph = (Image)(Instantiate(piece, phPosition, Quaternion.identity));
                ph.tag = "" + (i + 1);
                ph.name = "Piece" + (i + 1);
                ph.transform.SetParent(GameObject.Find("Canvas").transform);
                Sprite[] allSprites = Resources.LoadAll<Sprite>("Problem_4");
                Sprite s1 = allSprites[i];
                ph.GetComponent<UnityEngine.UI.Image>().sprite = s1;
            }
        }
        if (scene == "t_puzzle_five")
        {
            for (int i = 0; i < 16; i++)
            {
                Vector3 centerPosition = new Vector3();
                centerPosition = GameObject.Find("leftSide").transform.position;
                float row, column;
                row = i % 4;
                column = i / 4;
                Vector3 phPosition = new Vector3(centerPosition.x + phWdth * (row - nbRows / 2), centerPosition.y - phHeigth * (column - nbColumns / 2), centerPosition.z);
                Image ph = (Image)(Instantiate(piece, phPosition, Quaternion.identity));
                ph.tag = "" + (i + 1);
                ph.name = "Piece" + (i + 1);
                ph.transform.SetParent(GameObject.Find("Canvas").transform);
                Sprite[] allSprites = Resources.LoadAll<Sprite>("Problem_5");
                Sprite s1 = allSprites[i];
                ph.GetComponent<UnityEngine.UI.Image>().sprite = s1;
            }
        }
    }

    public void check_Finished()
    {
        for (int i = 0; i < 16; i++)
        {
            string tag = (i + 1).ToString();
            string check_tag = transpose_tag(tag);
            check_img = GameObject.Find("Piece" + tag);
            check_PH = GameObject.Find("PH" + check_tag);
            if (check_img.transform.position != check_PH.transform.position)
            {
                break;
            }
            else if (i == 15 && check_img.transform.position == check_PH.transform.position)
            {
                StartCoroutine(update_Flags());
                SceneManager.LoadScene("transpose_Finish");
            }
        }
    }

    public string transpose_tag(string tag)
    {
        string t_tag = "";
        if (tag == "1" || tag == "16")
        {
            t_tag = tag;
        }
        if (tag == "2")
        {
            t_tag = "5";
        }
        if (tag == "3")
        {
            t_tag = "9";
        }
        if (tag == "4")
        {
            t_tag = "13";
        }
        if (tag == "5")
        {
            t_tag = "2";
        }
        if (tag == "6")
        {
            t_tag = "6";
        }
        if (tag == "7")
        {
            t_tag = "10";
        }
        if (tag == "8")
        {
            t_tag = "14";
        }
        if (tag == "9")
        {
            t_tag = "3";
        }
        if (tag == "10")
        {
            t_tag = "7";
        }
        if (tag == "11")
        {
            t_tag = "11";
        }
        if (tag == "12")
        {
            t_tag = "15";
        }
        if (tag == "13")
        {
            t_tag = "4";
        }
        if (tag == "14")
        {
            t_tag = "8";
        }
        if (tag == "15")
        {
            t_tag = "12";
        }

        return t_tag;
    }

    IEnumerator update_Flags()
    {
        string scene_TXT = get_Scene_Name();
        string name = PlayerPrefs.GetString("name");
        if (scene_TXT == "t_puzzle_four")
        {
            PlayerPrefs.SetString("Puzzle_4_Flag", "complete");
            PlayerPrefs.SetString("Puzzle_4_Star_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle4";
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
        if (scene_TXT == "t_puzzle_five")
        {
            PlayerPrefs.SetString("Puzzle_5_Flag", "complete");
            PlayerPrefs.SetString("Puzzle_5_Star_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle5";
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
    }

    public string get_Scene_Name()
    {
        string scene_TXT = SceneManager.GetActiveScene().name;
        return scene_TXT;
    }

    public void exit_Puzzle()
    {
        SceneManager.LoadScene("transpose_list");
    }
}
