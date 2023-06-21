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

    private string image_path;
    private string image_str;

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

        string recognized_fruit = "Pineapple";
        
        if (recognized_fruit == "Apple")
            row = 1;
        else if(recognized_fruit == "Cherry")
            row = 2;
        else if (recognized_fruit == "Lychee")
            row = 3;
        else if (recognized_fruit == "Orange")
            row = 4;
        else if (recognized_fruit == "Pineapple")
            row = 5;

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
}
