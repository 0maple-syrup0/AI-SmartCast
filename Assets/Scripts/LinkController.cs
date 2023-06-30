using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using UnityEngine.UI;
using TMPro; //for TextMeshPro

public class LinkController : MonoBehaviour
{
    TMP_Text text_name_link;
    TMP_Text text_price_link;
    RawImage image_link;

    public TMP_Text text_name_com;
    public TMP_Text text_price_com;
    public RawImage image_com;

    public GameObject linkUI;

    private string image_path;
    private string image_str;


    //语音识别;
    private bool isSpeechRec=true;

    string recognized_fruit ="pineapple";


    int row;

    // Start is called before the first frame update
    void Start()
    {
        text_name_link = GameObject.Find("Canvas/Link/Name").GetComponent<TMP_Text>();
        text_price_link = GameObject.Find("Canvas/Link/Price").GetComponent<TMP_Text>();
        image_link = GameObject.Find("Canvas/Link/Icon").GetComponent<RawImage>();

        //text_name_com = GameObject.Find("Canvas/Commodity/Name").GetComponent<TMP_Text>();
        //text_price_com = GameObject.Find("Canvas/Commodity/Price").GetComponent<TMP_Text>();
        //image_com = GameObject.Find("Canvas/Commodity/Icon").GetComponent<RawImage>();

        CSV.GetInstance().loadFile(Application.dataPath + "/StreamingAssets", "Fruit.csv");
    }

    // Update is called once per frame
    void Update()
    {
        //---------------------------------
        //引号里写图像识别的水果名称
        //---------------------------------

        //string recognized_fruit = "Apple";//用于样例
        Debug.Log(row);
        chooseFruit();

        
   /*     if (recognized_fruit == "Apple")
            row = 1;
        else if(recognized_fruit == "Cherry")
            row = 2;
        else if (recognized_fruit == "Lychee")
            row = 3;
        else if (recognized_fruit == "Orange")
            row = 4;
        else if (recognized_fruit == "Pineapple")
            row = 5;*/
   
        image_path = Application.streamingAssetsPath + "/Fruit" + "/" + recognized_fruit + ".jpg"; 
        image_str = SetImageToString(image_path);
        
        image_link.texture = GetTextureByString(image_str);

        text_name_link.text = CSV.GetInstance().getString(row, 0);
        text_price_link.text = CSV.GetInstance().getString(row, 1);

        image_com.texture = GetTextureByString(image_str);

        text_name_com.text = CSV.GetInstance().getString(row, 0);
        text_price_com.text = CSV.GetInstance().getString(row, 1);
    }

    private string SetImageToString(string imgPath)
    {
        FileStream fs = new FileStream(imgPath, FileMode.Open);
        byte[] imgByte = new byte[fs.Length];
        fs.Read(imgByte, 0, imgByte.Length);
        fs.Close();
        return Convert.ToBase64String(imgByte);
    }

    //convert string to texture2D
    private Texture2D GetTextureByString(string textureStr)
    {
        Texture2D tex = new Texture2D(1, 1);
        byte[] arr = Convert.FromBase64String(textureStr);
        tex.LoadImage(arr);
        tex.Apply();
        return tex;
    }

    public void getCategoty(int _category)
    {
        row = _category;
    }

    public void getIsSpeechRec(bool _isSpeechRec)
    {
        isSpeechRec = _isSpeechRec;
    }
    private void chooseFruit()
    //'apple0','banana','orange2','cherry3','lychee4','pineapple'
    {
        if (isSpeechRec == true)
        {
          
            linkUI.SetActive(true);
            if (row == 0)
            {
                recognized_fruit = "apple";
                
            }
            else if (row == 1)
            {
                recognized_fruit = "banana";
            }
            else if (row == 2)
            {
                recognized_fruit = "orange";
            }
            else if (row == 3)
            {
                recognized_fruit = "cherry";
            }
            else if (row == 4)
            {
                recognized_fruit = "lychee";
            }
            else if (row == 5)
            {
                recognized_fruit = "pineapple";
            }
            else
            {
                Debug.Log("Can't find this fruit ");
                linkUI.SetActive(false);
            }
        }
        else
        {
            Debug.Log("未检测到目标语音");
            linkUI.SetActive(false);

        }
    }
}
