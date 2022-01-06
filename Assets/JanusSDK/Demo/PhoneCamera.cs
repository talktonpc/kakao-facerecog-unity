using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Janus;
using System.Runtime.InteropServices;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//[StructLayout(LayoutKind.Explicit, Pack = 1)]
//public struct Color32Array
//{
//    [FieldOffset(0)]
//    public Color32[] colors;

//    [FieldOffset(0)]
//    public byte[] byteArray;
//}

public class PhoneCamera : MonoBehaviour
{
    private bool _cameraAvailable = false;
    private WebCamTexture _frontCam = null;
    private Texture2D texture = null;

    public RawImage _background;
    public AspectRatioFitter fit;

    public JanusSDK janusSDK;

    void Start()
    {
        //===================================
        //Confirm iOS Janus SDK Initialized.
        //===================================
        string ver = janusSDK.GetVersion();
        Debug.Log("SDK TEST: " + ver);

        janusSDK.SetPowerControl(false);
        janusSDK.SetMaximumFaceNumber(1);
        janusSDK.SetMinimumFaceSize(100);
        //janusSDK.SetFaceDetectionThreshold(0.9f); bool return call problem !

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

        texture = new Texture2D(_frontCam.width, _frontCam.height, TextureFormat.ARGB32, false);

        _frontCam.Play();
        _background.material.mainTexture = _frontCam;
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

        int width = _frontCam.width;
        int height = _frontCam.height;

        //Color32Array colorArray = new Color32Array();
        //colorArray.colors = new Color32[width * height];
        //_frontCam.GetPixels32(colorArray.colors);

        //byte[] a = colorArray.byteArray;

        Color32[] colors = new Color32[width * height];
        _frontCam.GetPixels32(colors);

        byte[] buffer;
        BinaryFormatter bF = new BinaryFormatter();
        using (MemoryStream mS = new MemoryStream())
        {
            bF.Serialize(mS, colors);
            mS.Position = 0;
            buffer = new byte[mS.Length];
            mS.Read(buffer, 0, buffer.Length);
        }

        //// SDK API Call Test ...
        int numOfFaces = janusSDK.DetectFace_BGRA(ref buffer, width, height, false);
        Debug.Log("SDK TEST: DetectFace_RGBA - face detected : " + numOfFaces);

        //for (int i = 0; i < numOfFaces; i++) {

        //    int id = janusSDK.GetID(i);
        //    Debug.Log("SDK TEST: GetID - face id : " + id);

        //    float[] angles = System.Array.ConvertAll(new float[3], v => 0.0f);

        //    janusSDK.GetFaceAngles(i, ref angles);
        //    Debug.Log("SDK TEST: GetFaceAngles - face angles : " + angles[0] + "/" + angles[1] + "/" + angles[2]);

        //    float[] facearea = System.Array.ConvertAll(new float[10], v => 0.0f);
        //    janusSDK.GetAlignmentPoints(i, ref facearea);

        //}
    }
}
