using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Janus;

public class PhoneCamera : MonoBehaviour
{
    private bool _cameraAvailable = false;
    private WebCamTexture _frontCam = null;
    private Texture _defaultBackground = null;

    public RawImage _background;
    public AspectRatioFitter fit;

    public JanusSDK janusSDK;


    void Start()
    {
        //===================================
        //iOS Janus SDK Initialize ...
        //===================================
        //janusSDK.SetupSDK();

        //===================================
        //Confirm iOS Janus SDK Initialized.
        //===================================
        string ver = janusSDK.GetVersion();
        Debug.Log("SDK TEST: " + ver);

        _defaultBackground = _background.texture;

        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            _cameraAvailable = false;

            Debug.Log("No device found.");

            return;
        }

        for (int i = 0; i < devices.Length; i++) {
            if (devices[i].isFrontFacing) {
                _frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (_frontCam == null) {
            Debug.Log("No front camera device found.");
            _cameraAvailable = false;
            return;
        }

        Debug.Log("Camera play ...");

        _frontCam.Play();
        _background.texture = _defaultBackground = _frontCam;
        _cameraAvailable = true;
    }


    void Update()
    {
        if (!_cameraAvailable) {
            return;
        }

        float ratio = (float)_frontCam.width / (float)_frontCam.height;
        fit.aspectRatio = ratio;

        float scaleY = _frontCam.videoVerticallyMirrored ? -1.0f : 1.0f;
        _background.rectTransform.localScale = new Vector3(1.0f, scaleY, 1.0f);

        int orient = -_frontCam.videoRotationAngle;
        _background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    private void LateUpdate()
    {
        if (!_cameraAvailable)
        {
            return;
        }




    }
}
