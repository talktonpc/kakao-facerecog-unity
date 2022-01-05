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
using UnityEngine;

namespace Janus
{
    internal class NativeInterface
    {
#if UNITY_EDITOR
        static AndroidJavaObject api = null;
#else
        //static AndroidJavaObject api = new AndroidJavaObject("com.kakaoenterprise.janus.JanusFaceIdentifier");
        static AndroidJavaObject api = new AndroidJavaObject("Janus.JanusAPI");
#endif

        static NativeInterface()
        {
            var _ = JanusSDK.Instance;
        }

        private static bool IsInvalidRuntime(string identifier) {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.Android);
        }

        internal static void SetupSDK()
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            api.Call("janus_init");
        }

        internal static int TrackFace_RGBA(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) { return 0; }
        internal static int TrackFace_BGRA(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) { return 0; }
        internal static int TrackFace_RGB(ref byte[] img, int width, int height, int angle_in_degree, bool bRecognize) { return 0; }

        internal static int DetectFace_BGRA(ref byte[] img, int width, int height, bool bRecognize) { return 0; }

        internal static int GetFacialPoints(int idx, ref float[] pts) { return 0; }

        internal static int GetAlignmentPoints(int idx, ref float[] pts) { return 0; }
        internal static int GetFacialRect(int idx, ref int[] pRect) { return 0; }
        internal static int GetFDRect(int idx, ref int[] pRect) { return 0; }
        internal static int GetFacialProb(int idx) { return 0; }

        internal static int GetFaceFeature(int idx, ref float[] feature) { return 0; }
        internal static int GetFaceAngles(int idx, ref float[] angles) { return 0; }
        internal static int GetID(int idx) { return 0; }

        internal static int GetLiveness(int idx) { return 0; }
        internal static float GetMaskLevel(int idx) { return 0; }
        internal static int GetAttributeEnabled(bool b) { return 0; }

        internal static int GetCurrentPowerState() { return 0; }
        internal static void SetPowerControl(bool b) { }

        internal static int LoadGalleryFeature(ref byte[] gallery_features, int numOfIdx) { return 0; }
        internal static int AddGalleryFeature(ref byte[] gallery_features, int numOfIdx) { return 0; }
        internal static string GetRecognizedName(int idx) { return null; }
        internal static string GetPipelineLog() { return null; }
        internal static string GetFaceLog(int idx) { return null; }
        internal static int SetFaceRecognitionThreshold(float value) { return 0; }
        internal static void SetFaceDetectionThreshold(float value) { }
        internal static int SetMaximumFaceNumber(int cnt) { return 0; }
        internal static int SetMinimumFaceSize(int size) { return 0; }
        internal static int ClearDB() { return 0; }
        internal static int EraseFaceIDFromDB(string pID) { return 0; }

        internal static int DoReInit() { return 0; }
        internal static int DoFinalize() { return 0; }
        internal static void DoClose() { }
        internal static string GetVersion() { return null; }
    }
}
#endif
