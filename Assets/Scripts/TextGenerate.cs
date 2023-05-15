using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TextGenerate : MonoBehaviour
{
    Text text;
    string content;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas/Copyright").GetComponent<Text>();

        content = File.ReadAllText(Application.streamingAssetsPath + "/Copyright.txt");
        text.text = content;

        text = GameObject.Find("Canvas/Promotion").GetComponent<Text>();

        content = File.ReadAllText(Application.streamingAssetsPath + "/Promotion.txt");
        text.text = content;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
