using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
        //引号里写图像识别的水果名称
        //string recognized_fruit = "Apple Braeburn";//用于样例

        //for( int i = 0; i < CSV.GetInstance().m_ArrayData.Count; i++)
        //{
        //    if(String.Compare(recognized_fruit, CSV.GetInstance().getString(i, 0)) == 0)
        //    {
        //        text_name.text = CSV.GetInstance().getString(i, 0);
        //        text_price.text = CSV.GetInstance().getString(i, 1);
        //    }
        //}
        
        string fullPath = "Assets/StreamingAssets/Fruit" + "/";  //路径
        string recognized_fruit = "Apple Braeburn";

        //获取指定路径下面的所有资源文件  
        if (Directory.Exists(fullPath))
        {
            DirectoryInfo direction = new DirectoryInfo(fullPath);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                Debug.Log(files[i].Name);  //打印出来这个文件架下的所有文件
                
                if(String.Compare(recognized_fruit + ".jpg", files[i].Name) == 0)
                {
                    Debug.Log(Application.streamingAssetsPath + "/Fruit" + files[i].Name);
                }
            }

        }

        //if(apple)    if recognized as apple
        image_path = Application.streamingAssetsPath + "/Fruit/Apple Bareburn.jpg";
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
