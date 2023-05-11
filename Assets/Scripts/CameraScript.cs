using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    private int currentCamIndex = 0;
    private WebCamTexture webCamTexture;
    public RawImage rawImage;

    public void SwapCameraClicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
            if (webCamTexture != null)
            {
                StopCamera();
                StartStopCameraClicked();
            }

        }
    }

    public void StartStopCameraClicked()
    {
        if (webCamTexture != null)
        {
            StopCamera();
        }
        else
        {

            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            if (!device.Equals(null))
            {
                int width = 1920;
                int height = 1080;

                webCamTexture = new WebCamTexture(device.name, width, height, 24);
                rawImage.texture = webCamTexture;
                webCamTexture.Play();
                Debug.Log("Stop");
            }
        }
    }

    private void StopCamera()
    {
        rawImage.texture = null;
        webCamTexture.Stop();
        webCamTexture = null;
        Debug.Log("Start");
    }

}