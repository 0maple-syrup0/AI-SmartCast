using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using TMPro; //for TextMeshPro

public class CSVController : MonoBehaviour
{
    TMP_Text text_name;
    TMP_Text text_price;
    RawImage image;
    private string image_path;
    private string image_str;

    // Start is called before the first frame update
    void Start()
    {
        text_name = GameObject.Find("Canvas/Link/Name").GetComponent<TMP_Text>();
        text_price = GameObject.Find("Canvas/Link/Price").GetComponent<TMP_Text>();
        image = GameObject.Find("Canvas/Link/Icon").GetComponent<RawImage>();

        CSV.GetInstance().loadFile(Application.dataPath + "/StreamingAssets", "Fruit.csv");

        
    }

    // Update is called once per frame
    void Update()
    {
        //if(apple)    if recognized as apple
        image_path = Application.streamingAssetsPath + "/Fruit/Apple.jpg";
        image_str = SetImageToString(image_path);
        image.texture = GetTextureByString(image_str);

        text_name.text = CSV.GetInstance().getString(1, 0);
        text_price.text = CSV.GetInstance().getString(1, 1);
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
