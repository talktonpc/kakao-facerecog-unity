//  Copyright (c) 2019-present, LINE Corporation. All rights reserved.
//
//  You are hereby granted a non-exclusive, worldwide, royalty-free license to use,
//  copy and distribute this software in source code or binary form for use
//  in connection with the web services and APIs provided by LINE Corporation.
//
//  As with any software that integrates with the LINE Corporation platform, your use of this software
//  is subject to the LINE Developers Agreement [http://terms2.line.me/LINE_Developers_Agreement].
//  This copyright notice shall be included in all copies or substantial portions of the software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//  IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//  DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if UNITY_ANDROID
using System;
using UnityEngine;

namespace Janus
{
    internal class NativeInterface
    {
#if UNITY_EDITOR
        static AndroidJavaObject api = null;
        static JanusSDK sdk = null;
#else
        static AndroidJavaObject api = new AndroidJavaObject("Janus.JanusAPI");
        static JanusSDK sdk = null;
#endif

        static NativeInterface()
        {
            sdk = JanusSDK.Instance;
            AndroidJNI.AttachCurrentThread();
        }

        private static bool IsInvalidRuntime(string identifier) {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.Android);
        }

        internal static void SetupSDK()
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            api.CallStatic("janus_init");
        }

        internal static string GetVersion()
        {
            return api.Call<string>("getVersion").ToString();
        }

        internal static int SetFaceRecognitionThreshold(float value)
        {
            object[] parameters = new object[1];
            parameters[0] = value;

            return api.Call<int>("setFaceRecognitionThreshold", parameters);
        }

        internal static void SetFaceDetectionThreshold(float value)
        {
            object[] parameters = new object[1];
            parameters[0] = value;

            api.Call<bool>("setFaceDetectionThreshold", parameters);
        }

        internal static int SetMaximumFaceNumber(int cnt)
        {
            object[] parameters = new object[1];
            parameters[0] = cnt;

            return api.Call<int>("setMaxNumOfFaces", parameters);
        }

        internal static bool SetMinimumFaceSize(int size)
        {
            object[] parameters = new object[1];
            parameters[0] = size;

            return api.Call<bool>("setMinFaceSize", parameters);
        }

        internal static int DetectFace_BGRA(ref byte[] img, int width, int height, bool bRecognize)
        {
            if (!Application.isPlaying) { return -1; }
            if (IsInvalidRuntime(null)) { return -1; }

            object[] parameters = new object[] { img, width, height, bRecognize };

            return api.Call<int>("detectFaceRGBA", parameters);
        }

        internal static int DetectFace_RGBA(sbyte[] img, int width, int height, bool bRecognize)
        {
            if (!Application.isPlaying) { return -1; }
            if (IsInvalidRuntime(null)) { return -1; }

            object[] parameters = new object[] { img, width, height, bRecognize};

            return api.Call<int>("detectFaceRGBA", parameters);
        }

        //=================================================================================================================================
        // NOT IMPLEMENTED YET ! ---[[
        internal static int TrackFace_RGBA(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) { return -1; }
        internal static int TrackFace_BGRA(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) { return -1; }
        internal static int TrackFace_RGB(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) { return -1; }

        internal static int GetFacialPoints(int idx, ref float[] pts) { return -1; }

        internal static int GetAlignmentPoints(int idx, ref float[] pts) { return -1; }
        internal static int GetFacialRect(int idx, ref int[] pRect) { return -1; }
        internal static int GetFDRect(int idx, ref int[] pRect) { return -1; }
        internal static int GetFacialProb(int idx) { return -1; }

        internal static int GetFaceFeature(int idx, ref float[] feature) { return -1; }
        internal static int GetFaceAngles(int idx, ref float[] angles) { return -1; }
        internal static int GetID(int idx) { return -1; }

        internal static int GetLiveness(int idx) { return -1; }
        internal static float GetMaskLevel(int idx) { return -1; }
        internal static int GetAttributeEnabled(bool b) { return -1; }

        internal static int GetCurrentPowerState() { return -1; }
        internal static void SetPowerControl(bool b) {
        }

        internal static int LoadGalleryFeature(ref byte[] gallery_features, int numOfIdx) { return -1; }
        internal static int AddGalleryFeature(ref byte[] gallery_features, int numOfIdx) { return -1; }
        internal static string GetRecognizedName(int idx) { return null; }
        internal static string GetPipelineLog() { return null; }
        internal static string GetFaceLog(int idx) { return null; }

        internal static int ClearDB() { return -1; }
        internal static int EraseFaceIDFromDB(string pID) { return -1; }

        internal static int DoReInit() { return -1; }
        internal static int DoFinalize() { return -1; }
        internal static void DoClose() { }
        // NOT IMPLEMENTED YET ! ---]]
    }
}
#endif
