using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DragandDrop : MonoBehaviour
{
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Drag()
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void Drop()
    {
        checkMatch();
    }

    public void checkMatch()
    {
        GameObject img = gameObject;
        string tag = transpose_tag(gameObject.tag);
        GameObject ph1 = GameObject.Find("PH" + tag);
        float distance = Vector3.Distance(ph1.transform.position, img.transform.position);
        if (distance <= 50)
        {
            snap(img, ph1);
        }
        else
        {
            moveBack();
        }
    }

    public void moveBack()
    {
        transform.position = originalPosition;
    }

    public void snap(GameObject img, GameObject ph1)
    {
        img.transform.position = ph1.transform.position;
    }

    public void initCardPosition()
    {
        originalPosition = transform.position;
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
        if(tag == "4")
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
}
