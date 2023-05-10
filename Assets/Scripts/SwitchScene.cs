using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SwitchToBeforeLive()
    {
        SceneManager.LoadScene("BeforeLive");
    }
    public void SwichToLive()
    {
        SceneManager.LoadScene("Live");
    }
    
}
