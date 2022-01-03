#if UNITY_IOS

using UnityEngine;
using System.Runtime.InteropServices;

namespace Janus {
    internal class NativeInterface {

        static NativeInterface()
        {
            var _ = JanusSDK.Instance;
        }

        private static bool IsInvalidRuntime(string identifier) {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.IPhonePlayer);
        }

        //===================================================================================================================================
        // C# APIs
        //===================================================================================================================================
        // Init
        [DllImport("__Internal")] private static extern void janus_init();
        // Track
        [DllImport("__Internal")] private static extern int trackFace_RGBA([In] byte[] img, int width, int height, int angle_in_degree, bool bRecognize);
        [DllImport("__Internal")] private static extern int trackFace_BGRA([In] byte[] img, int width, int height, int angle_in_degree, bool bRecognize);
        [DllImport("__Internal")] private static extern int trackFace_RGB([In] byte[] img, int width, int height, int angle_in_degree, bool bRecognize);

        // Detect
        [DllImport("__Internal")] private static extern int detectFace_BGRA([In] byte[] img, int width, int height, bool bRecognize);

        // Alignment
        [DllImport("__Internal")] private static extern int getFacialPoints(int idx, [Out] float[] pts);
        [DllImport("__Internal")] private static extern int getAlignmentPoints(int idx, [Out] float[] pts);
        [DllImport("__Internal")] private static extern int getFacialRect(int idx, [Out] int[] pRect);
        [DllImport("__Internal")] private static extern int getFDRect(int idx, [Out] int[] pRect);
        [DllImport("__Internal")] private static extern int getFacialProb(int idx);

        // Recognition
        [DllImport("__Internal")] private static extern int getFaceFeature(int idx, [Out] float[] feature);
        [DllImport("__Internal")] private static extern int getFaceAngles(int idx, [Out] float[] angles);
        [DllImport("__Internal")] private static extern int getID(int idx);

        // Attribute
        [DllImport("__Internal")] private static extern float getLiveness(int idx);
        [DllImport("__Internal")] private static extern float getMaskLevel(int idx);
        [DllImport("__Internal")] private static extern int setAttributeEnabled(bool b);

        // power state
        [DllImport("__Internal")] private static extern int getCurrentPowerState();
        [DllImport("__Internal")] private static extern void setPowerControl(bool b);

        // WTM
        //[DllImport("__Internal")] private static extern int loadGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx);
        //[DllImport("__Internal")] private static extern int addGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx);
        [DllImport("__Internal")] private static extern string getRecognizedName(int idx);
        [DllImport("__Internal")] private static extern string getPipelineLog();
        [DllImport("__Internal")] private static extern string getFaceLog(int idx);
        [DllImport("__Internal")] private static extern int setFaceRecognitionThreshold(float value);
        [DllImport("__Internal")] private static extern void setFaceDetectionThreshold(float value);
        [DllImport("__Internal")] private static extern int setMaximumFaceNumber(int cnt);
        [DllImport("__Internal")] private static extern int setMinimumFaceSize(int size);
        [DllImport("__Internal")] private static extern int clearDB();
        [DllImport("__Internal")] private static extern int eraseFaceIDFromDB(string pID);

        // Basic
        [DllImport("__Internal")] private static extern int doReInit();
        [DllImport("__Internal")] private static extern int doFinalize();
        [DllImport("__Internal")] private static extern void doClose();

        // version
        [DllImport("__Internal")] private static extern string getVersion();

        internal static void SetupSDK() {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            janus_init();
        }


        // Track
        internal static int TrackFace_RGBA([In] byte[] img, int width, int height, int angle_in_degree, bool bRecognize) {
            return trackFace_RGBA(img, width, height, angle_in_degree, bRecognize);
        }

        internal static int TrackFace_BGRA([In] byte[] img, int width, int height, int angle_in_degree, bool bRecognize) {
            return trackFace_BGRA(img, width, height, angle_in_degree, bRecognize);
        }

        internal static int TrackFace_RGB([In] byte[] img, int width, int height, int angle_in_degree, bool bRecognize) {
            return trackFace_RGB(img, width, height, angle_in_degree, bRecognize);
        }

        // Detect
        internal static int DetectFace_BGRA([In] byte[] img, int width, int height, bool bRecognize) {
            return detectFace_BGRA(img, width, height, bRecognize);
        }

        // Alignment
        internal static int GetFacialPoints(int idx, [Out] float[] pts) {
            return getFacialPoints(idx, pts);
        }
        internal static int GetAlignmentPoints(int idx, [Out] float[] pts) {
            return getAlignmentPoints(idx, pts);
        }
        internal static int GetFacialRect(int idx, [Out] int[] pRect) {
            return getFacialRect(idx, pRect);
        }
        internal static int GetFDRect(int idx, [Out] int[] pRect) {
            return getFDRect(idx, pRect);
        }
        internal static int GetFacialProb(int idx) {
            return getFacialProb( idx);
        }

        // Recognition
        internal static int GetFaceFeature(int idx, [Out] float[] feature) {
            return getFaceFeature(idx, feature);
        }
        internal static int GetFaceAngles(int idx, [Out] float[] angles) {
            return getFaceAngles(idx, angles);
        }
        internal static int GetID(int idx) {
            return getID(idx);
        }

        // Attribute
        internal static float GetLiveness(int idx) {
            return getLiveness(idx);
        }
        internal static float GetMaskLevel(int idx) {
            return getMaskLevel(idx);
        }
        internal static int GetAttributeEnabled(bool b) {
            return setAttributeEnabled(b);
        }

        // power state
        internal static int GetCurrentPowerState() {
            return getCurrentPowerState();
        }
        internal static void SetPowerControl(bool b) {
            setPowerControl(b);
        }

        // WTM
        //internal static int LoadGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx) {
        //    return loadGalleryFeature(gallery_features, numOfIdx);
        //}
        //internal static int AddGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx) {
        //    return addGalleryFeature(gallery_features, numOfIdx);
        //}
        internal static string GetRecognizedName(int idx) {
            return getRecognizedName(idx);
        }
        internal static string GetPipelineLog() {
            return GetPipelineLog();
        }
        internal static string GetFaceLog(int idx) {
            return getFaceLog(idx);
        }
        internal static int SetFaceRecognitionThreshold(float value) {
            return setFaceRecognitionThreshold(value);
        }
        internal static void SetFaceDetectionThreshold(float value) {
            setFaceDetectionThreshold(value);
        }
        internal static int SetMaximumFaceNumber(int cnt) {
            return setMaximumFaceNumber(cnt);
        }
        internal static int SetMinimumFaceSize(int size) {
            return setMinimumFaceSize(size);
        }
        internal static int ClearDB() {
            return clearDB();
        }
        internal static int EraseFaceIDFromDB(string pID) {
            return eraseFaceIDFromDB(pID);
        }
        // Basic
        internal static int DoReInit() {
            return doReInit();
        }
        internal static int DoFinalize() {
            return doFinalize();
        }
        internal static void DoClose() {
            doClose();
        }

        // version
        internal static string GetVersion() {
            return getVersion();
        }
    } 
}

#endif
