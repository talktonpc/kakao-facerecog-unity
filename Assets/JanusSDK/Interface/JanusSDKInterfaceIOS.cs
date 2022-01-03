#if UNITY_IOS

using UnityEngine;
using System.Runtime.InteropServices;

namespace Janus {
    internal class NativeInterface {

        static NativeInterface()
        {
            var _ = JanusSDK.Instance;
        }

        //===================================================================================================================================
        // c/c++ APIs
        //===================================================================================================================================

        // Init
        internal static void janus_init();

        // Track
        internal static int trackFace_RGBA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize);
        internal static int trackFace_BGRA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize);
        internal static int trackFace_RGB(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize);

        // Detect
        internal static int detectFace_BGRA(unsigned char* img, int width, int height, bool bRecognize);

        // Alignment
        internal static int getFacialPoints(int idx, float* pts);
        internal static int getAlignmentPoints(int idx, float* pts);
        internal static int getFacialRect(int idx, int* pRect);
        internal static int getFDRect(int idx, int* pRect);
        internal static int getFacialProb(int idx);

        // Recognition
        internal static int getFaceFeature(int idx, float* feature);
        internal static int getFaceAngles(int idx, float* angles);
        internal static int getID(int idx);

        // Attribute
        internal static float getLiveness(int idx);
        internal static float getMaskLevel(int idx);
        internal static int setAttributeEnabled(bool b);

        // power state
        internal static int getCurrentPowerState();
        internal static void setPowerControl(bool b);

        // WTM
        internal static int loadGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx);
        internal static int addGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx);
        internal static char* getRecognizedName(int idx);
        internal static char* getPipelineLog();
        internal static char* getFaceLog(int idx);
        internal static int setFaceRecognitionThreshold(float value);
        internal static void setFaceDetectionThreshold(float value);
        internal static int setMaximumFaceNumber(int cnt);
        internal static int setMinimumFaceSize(int size);
        internal static int clearDB();
        internal static int eraseFaceIDFromDB(char* pID);

        // Basic
        internal static int doReInit();
        internal static int doFinalize();
        internal static void doClose();

        // version
        internal static char* getVersion();

        private static bool IsInvalidRuntime(string identifier) {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.IPhonePlayer);
        }

        //===================================================================================================================================
        // C# APIs
        //===================================================================================================================================
        // Init
        internal static void SetupSDK() {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            janus_init();
        }


        // Track
        internal static int TrackFace_RGBA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize) {
            return trackFace_RGBA(img, width, height, angle_in_degree, bRecognize);
        }

        internal static int TrackFace_BGRA(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize) {
            return trackFace_BGRA(img, width, height, angle_in_degree, bRecognize);
        }

        internal static int TrackFace_RGB(unsigned char* img, int width, int height, int angle_in_degree, bool bRecognize) {
            return trackFace_RGB(img, width, height, angle_in_degree, bRecognize);
        }

        // Detect
        internal static int DetectFace_BGRA(unsigned char* img, int width, int height, bool bRecognize) {
            return detectFace_BGRA(img, width, height, bRecognize);
        }

        // Alignment
        internal static int GetFacialPoints(int idx, float* pts) {
            return getFacialPoints(idx, pts);
        }
        internal static int GetAlignmentPoints(int idx, float* pts) {
            return getAlignmentPoints(idx, pts);
        }
        internal static int GetFacialRect(int idx, int* pRect) {
            return getFacialRect(idx, pRect);
        }
        internal static int GetFDRect(int idx, int* pRect) {
            return getFDRect(idx, pRect);
        }
        internal static int GetFacialProb(int idx) {
            return getFacialProb( idx);
        }

        // Recognition
        internal static int GetFaceFeature(int idx, float* feature) {
            return getFaceFeature(idx, feature);
        }
        internal static int GetFaceAngles(int idx, float* angles) {
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
        internal static int LoadGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx) {
            return loadGalleryFeature(gallery_features, numOfIdx);
        }
        internal static int AddGalleryFeature(galleryInfoWrapper* gallery_features, int numOfIdx) {
            return addGalleryFeature(gallery_features, numOfIdx);
        }
        internal static char* GetRecognizedName(int idx) {
            return getRecognizedName(idx);
        }
        internal static char* GetPipelineLog() {
            return getRecognizedName(getPipelineLog);
        }
        internal static char* GetFaceLog(int idx) {
            return getFaceLog(idx);
        }
        internal static int SetFaceRecognitionThreshold(float value) {
            return setFaceRecognitionThreshold(value);
        }
        internal static void SetFaceDetectionThreshold(float value) {
            setFaceDetectionThreshold(value)
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
        internal static int EraseFaceIDFromDB(char* pID) {
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
            return doClose();
        }

        // version
        internal static char* GetVersion() {
            return getVersion();
        }
    } 
}

#endif
