using System;
using UnityEngine;

namespace Janus {
    public class JanusSDK: MonoBehaviour {
        static JanusSDK instance;

        void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            SetupSDK();
        }

        public static JanusSDK Instance {
            get {
                if (instance == null) {
                    GameObject go = new GameObject("JanusSDK");
                    instance = go.AddComponent<JanusSDK>();
                }
                return instance;
            }
        }

        public void SetupSDK() {
            NativeInterface.SetupSDK();
        }

        public int TrackFace_RGBA(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) {
            return NativeInterface.TrackFace_RGBA(ref img, width, height, angle_in_degree, bRecognize);
        }

        public int TrackFace_RGB(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize)
        {
            return NativeInterface.TrackFace_RGB(ref img, width, height, angle_in_degree, bRecognize);
        }

        public int DetectFace_BGRA(ref byte[] img, int width, int height, bool bRecognize) {
            return NativeInterface.DetectFace_BGRA(ref img, width, height, bRecognize);
        }

        public int GetFacialPoints(int idx, ref float[] pts) {
            return NativeInterface.GetFacialPoints(idx, ref pts);
        }

        public int GetAlignmentPoints(int idx, ref float[] pts) {
            return NativeInterface.GetAlignmentPoints(idx, ref pts);
        }
        public int GetFacialRect(int idx, ref int[] pRect) {
            return NativeInterface.GetFacialRect(idx, ref pRect);
        }
        int GetFDRect(int idx, ref int[] pRect) {
            return NativeInterface.GetFDRect(idx, ref pRect);
        }
        public int GetFacialProb(int idx) {
            return NativeInterface.GetFacialProb(idx);
        }

        public int GetFaceFeature(int idx, ref float[] feature) {
            return NativeInterface.GetFaceFeature(idx, ref feature);
        }
        public int GetFaceAngles(int idx, ref float[] angles) {
            return NativeInterface.GetFaceAngles(idx, ref angles);
        }
        public int GetID(int idx) {
            return NativeInterface.GetID(idx);
        }

        public float GetLiveness(int idx) {
            return NativeInterface.GetLiveness(idx);
        }
        public float GetMaskLevel(int idx) {
            return NativeInterface.GetMaskLevel(idx);
        }
        public int GetAttributeEnabled(bool b) {
            return NativeInterface.GetAttributeEnabled(b);
        }

        public int GetCurrentPowerState() {
            return NativeInterface.GetCurrentPowerState();
        }
        public void SetPowerControl(bool b) {
            NativeInterface.SetPowerControl(b);
        }

        // NOT SUPPORTED YET!
        // public int LoadGalleryFeature(ref byte[] gallery_features, int numOfIdx) {
        //     return NativeInterface.LoadGalleryFeature(ref gallery_features, numOfIdx);
        // }
        // public int AddGalleryFeature(ref byte[] gallery_features, int numOfIdx) {
        //    return NativeInterface.AddGalleryFeature(ref gallery_features, numOfIdx);
        // }
        public string GetRecognizedName(int idx) {
            return NativeInterface.GetRecognizedName(idx);
        }
        public string GetPipelineLog() {
            return NativeInterface.GetPipelineLog();
        }
        public string GetFaceLog(int idx) {
            return NativeInterface.GetFaceLog(idx);
        }
        public int SetFaceRecognitionThreshold(float value) {
            return NativeInterface.SetFaceRecognitionThreshold(value);
        }
        public void SetFaceDetectionThreshold(float value) {
            NativeInterface.SetFaceDetectionThreshold(value);
        }
        public int SetMaximumFaceNumber(int cnt) {
            return NativeInterface.SetMaximumFaceNumber(cnt);
        }
        public int SetMinimumFaceSize(int size) {
            return NativeInterface.SetMinimumFaceSize(size);
        }
        public int ClearDB() {
            return NativeInterface.ClearDB();
        }
        public int EraseFaceIDFromDB(string pID) {
            return NativeInterface.EraseFaceIDFromDB(pID);
        }

        public int DoReInit() {
            return NativeInterface.DoReInit();
        }
        public int DoFinalize() {
            return NativeInterface.DoFinalize();
        }
        public void DoClose() {
            NativeInterface.DoClose();
        }
        unsafe public string GetVersion() {
            return NativeInterface.GetVersion();
        }
    }
}
