using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BackTouch : MonoBehaviour
{
    public GameObject Commodity;
    // Start is called before the first frame update
    void Start()
    {
        Input.multiTouchEnabled = true;//¿ªÆô¶àµã´¥Åö
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0)
            return;
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Back();
                }
                else
                    return;
            }
        }
    }

    public void Back()
    {
        Commodity.SetActive(false);
    }

}
