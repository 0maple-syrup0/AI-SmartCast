using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linkdetector : MonoBehaviour
{
    public GameObject Link;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if( audio "…œ¡¥Ω”" detected)
        Link.SetActive(true);
    }
}
