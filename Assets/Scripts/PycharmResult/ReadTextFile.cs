using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ReadTextFile : MonoBehaviour
{
    [SerializeField]
    private string filePath;  // ָ���ı��ļ���·��
    [SerializeField]
    private LinkController linkController;
    private int category;  // �����һ�������ı���


    void Update()
    {
        ReadFirstLine();
        Debug.Log("First line integer: " + category);
       
        linkController.getCategoty(category);

    }

    void ReadFirstLine()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    int number;
                    if (int.TryParse(line, out number))
                    {
                        category = number;
                    }
                    else
                    {
                        Debug.Log("First line is not a valid number.");
                    }
                }
                else
                {
                    Debug.Log("File is empty.");
                }
            }
        }
        else
        {
            Debug.Log("File does not exist at the specified path.");
        }
    }


}
