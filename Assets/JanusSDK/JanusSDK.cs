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

        void SetupSDK() {
            NativeInterface.SetupSDK();
        }

        int TrackFace_RGBA(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) {
            return NativeInterface.TrackFace_RGBA(ref img, width, height, angle_in_degree, bRecognize);
        }

        int TrackFace_BGRA(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize)
        {
            return NativeInterface.TrackFace_BGRA(ref img, width, height, angle_in_degree, bRecognize);
        }

        int TrackFace_RGB(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize)
        {
            return NativeInterface.TrackFace_RGB(ref img, width, height, angle_in_degree, bRecognize);
        }

        int DetectFace_BGRA(ref byte[] img, int width, int height, bool bRecognize) {
            return NativeInterface.DetectFace_BGRA(ref img, width, height, bRecognize);
        }

        int GetFacialPoints(int idx, ref float[] pts) {
            return NativeInterface.GetFacialPoints(idx, ref pts);
        }

        int GetAlignmentPoints(int idx, ref float[] pts) {
            return NativeInterface.GetAlignmentPoints(idx, ref pts);
        }
        int GetFacialRect(int idx, ref int[] pRect) {
            return NativeInterface.GetFacialRect(idx, ref pRect);
        }
        int GetFDRect(int idx, ref int[] pRect) {
            return NativeInterface.GetFDRect(idx, ref pRect);
        }
        int GetFacialProb(int idx) {
            return NativeInterface.GetFacialProb(idx);
        }

        int GetFaceFeature(int idx, ref float[] feature) {
            return NativeInterface.GetFaceFeature(idx, ref feature);
        }
        int GetFaceAngles(int idx, ref float[] angles) {
            return NativeInterface.GetFaceAngles(idx, ref angles);
        }
        int GetID(int idx) {
            return NativeInterface.GetID(idx);
        }

        int GetLiveness(int idx) {
            return NativeInterface.GetLiveness(idx);
        }
        float GetMaskLevel(int idx) {
            return NativeInterface.GetMaskLevel(idx);
        }
        int GetAttributeEnabled(bool b) {
            return NativeInterface.GetAttributeEnabled(b);
        }

        int GetCurrentPowerState() {
            return NativeInterface.GetCurrentPowerState();
        }
        void SetPowerControl(bool b) {
            NativeInterface.SetPowerControl(b);
        }

        int LoadGalleryFeature(ref byte[] gallery_features, int numOfIdx) {
            return NativeInterface.LoadGalleryFeature(ref gallery_features, numOfIdx);
        }
        int AddGalleryFeature(ref byte[] gallery_features, int numOfIdx) {
            return NativeInterface.AddGalleryFeature(ref gallery_features, numOfIdx);
        }
        string GetRecognizedName(int idx) {
            return NativeInterface.GetRecognizedName(idx);
        }
        string GetPipelineLog() {
            return NativeInterface.GetPipelineLog();
        }
        string GetFaceLog(int idx) {
            return NativeInterface.GetFaceLog(idx);
        }
        int SetFaceRecognitionThreshold(float value) {
            return NativeInterface.SetFaceRecognitionThreshold(value);
        }
        void SetFaceDetectionThreshold(float value) {
            NativeInterface.SetFaceDetectionThreshold(value);
        }
        int SetMaximumFaceNumber(int cnt) {
            return NativeInterface.SetMaximumFaceNumber(cnt);
        }
        int SetMinimumFaceSize(int size) {
            return NativeInterface.SetMinimumFaceSize(size);
        }
        int ClearDB() {
            return NativeInterface.ClearDB();
        }
        int EraseFaceIDFromDB(string pID) {
            return NativeInterface.EraseFaceIDFromDB(pID);
        }

        int DoReInit() {
            return NativeInterface.DoReInit();
        }
        int DoFinalize() {
            return NativeInterface.DoFinalize();
        }
        void DoClose() {
            NativeInterface.DoClose();
        }
        string GetVersion() {
            return NativeInterface.GetVersion();
        }
    }
}
