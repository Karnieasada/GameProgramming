using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageTransposeGame : MonoBehaviour
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
        nbRows = 3; 
        nbColumns = 3;
        for (int i = 0; i < 9; i++)
        {
            Vector3 centerPosition = new Vector3();
            centerPosition = GameObject.Find("rightSide").transform.position;
            float row, column;
            row = i % 3;
            column = i / 3;
            Vector3 phPosition = new Vector3(centerPosition.x + phWdth * (row-nbRows/2), centerPosition.y - phHeigth * (column - nbColumns/2), centerPosition.z);
            Image ph = (Image)(Instantiate(placeHolder, phPosition, Quaternion.identity));
            ph.tag = "" + (i + 1);
            ph.name ="PH"+(i + 1);
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

        string scene = get_Scene_Name();
        if (scene == "t_puzzle_one")
        {
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
                Sprite[] allSprites = Resources.LoadAll<Sprite>("Problem_1");
                Sprite s1 = allSprites[i];
                ph.GetComponent<UnityEngine.UI.Image>().sprite = s1;
            }
        }
        if (scene == "t_puzzle_two")
        {
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
                Sprite[] allSprites = Resources.LoadAll<Sprite>("Problem_2");
                Sprite s1 = allSprites[i];
                ph.GetComponent<UnityEngine.UI.Image>().sprite = s1;
            }
        }
        if (scene == "t_puzzle_three")
        {
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
                Sprite[] allSprites = Resources.LoadAll<Sprite>("Problem_3");
                Sprite s1 = allSprites[i];
                ph.GetComponent<UnityEngine.UI.Image>().sprite = s1;
            }
        }
    }

    public void check_Finished()
    {
        for (int i = 0; i < 9; i++)
        {
            string tag = (i + 1).ToString();
            string check_tag = transpose_tag(tag);
            check_img = GameObject.Find("Piece" + tag);
            check_PH = GameObject.Find("PH" + check_tag);
            if (check_img.transform.position != check_PH.transform.position)
            {
                break;
            }
            else if (i == 8 && check_img.transform.position == check_PH.transform.position)
            {
                StartCoroutine(update_Flags());
                SceneManager.LoadScene("transpose_Finish");
            }
        }
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

    IEnumerator update_Flags()
    {
        string scene_TXT = get_Scene_Name();
        string name = PlayerPrefs.GetString("name");
        if (scene_TXT == "t_puzzle_one")
        {
            PlayerPrefs.SetString("Puzzle_1_Flag", "complete");
            PlayerPrefs.SetString("Puzzle_1_Star_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle1";
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
        if (scene_TXT == "t_puzzle_two")
        {
            PlayerPrefs.SetString("Puzzle_2_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle2";
            PlayerPrefs.SetString("Puzzle_2_Star_Flag", "complete");
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
        if (scene_TXT == "t_puzzle_three")
        {
            PlayerPrefs.SetString("Puzzle_3_Flag", "complete");
            string url = updateURL + "name=" + name + "&puzzle=" + "Puzzle3";
            PlayerPrefs.SetString("Puzzle_3_Star_Flag", "complete");
            UnityWebRequest www = UnityWebRequest.Put(url, name);
            yield return www.SendWebRequest();
        }
    }

    public string get_Scene_Name()
    {
        string scene_TXT = SceneManager.GetActiveScene().name;
        return scene_TXT;
    }
}
