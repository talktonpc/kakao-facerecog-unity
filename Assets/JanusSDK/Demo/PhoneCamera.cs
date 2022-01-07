using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using Janus;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
public struct Color32Array
{
    [FieldOffset(0)]
    public Color32[] colors;

    [FieldOffset(0)]
    public byte[] byteArray;

    [FieldOffset(0)]
    public sbyte[] sbyteArray;
}

public class PhoneCamera : MonoBehaviour
{
    private bool _cameraAvailable = false;
    private WebCamTexture _frontCam = null;

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
        janusSDK.SetFaceDetectionThreshold(0.9f);

        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            _cameraAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++) {
            if (devices[i].isFrontFacing) {
                _frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (_frontCam == null) {
            _cameraAvailable = false;
            return;
        }

        Debug.Log("Camera play ...");

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

#if UNITY_ANDROID
    private byte[] Color32ArrayToByteArray(Color32[] colors)
    {
        if (colors == null || colors.Length == 0)
            return null;

        int lengthOfColor32 = Marshal.SizeOf(typeof(Color32));
        int length = lengthOfColor32 * colors.Length;
        byte[] bytes = new byte[length];

        GCHandle handle = default(GCHandle);
        try
        {
            handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();
            Marshal.Copy(ptr, bytes, 0, length);
        }
        finally
        {
            if (handle != default(GCHandle))
                handle.Free();
        }

        return bytes;
    }
#endif

    private void LateUpdate()
    {
        if (!_cameraAvailable)
        {
            return;
        }

        int width = _frontCam.width;
        int height = _frontCam.height;

        Color32Array colorArray = new Color32Array();
        colorArray.colors = new Color32[width * height];
        _frontCam.GetPixels32(colorArray.colors);

#if UNITY_ANDROID
        colorArray.byteArray = Color32ArrayToByteArray(colorArray.colors);
        sbyte[] data = Array.ConvertAll(colorArray.byteArray, b => unchecked((sbyte)b));

        int numOfFaces = janusSDK.DetectFace_RGBA(data, width, height, false);
#endif

#if UNITY_IOS
        int numOfFaces = janusSDK.DetectFace_GBRA(ref colorArray.byteArray, width, height, false);
#endif

        Debug.Log("SDK TEST: face detected : " + numOfFaces);

#if UNITY_IOS
        for (int i = 0; i < numOfFaces; i++) {

            float[] angles = System.Array.ConvertAll(new float[3], v => 0.0f);
            janusSDK.GetFaceAngles(i, ref angles);
            Debug.Log("SDK TEST: GetFaceAngles - face angles : " + angles[0] + "/" + angles[1] + "/" + angles[2]);

            float[] facearea = System.Array.ConvertAll(new float[10], v => 0.0f);
            janusSDK.GetAlignmentPoints(i, ref facearea);
        }
#endif
    }
}
