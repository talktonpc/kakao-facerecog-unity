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
        static AndroidJavaObject sdkWrapper = null;
        #else
        static AndroidJavaObject sdkWrapper = new AndroidJavaObject("com.utop.janus.SdkWrapper");
        #endif

        static NativeInterface()
        {
            var _ = sdk.Instance;
        }

        internal static void SetupSDK()
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            object[] parameters = new object[1];

            sdkWrapper.Call("setupSdk", parameters);
        }

        private static void CallSdkWrapperWithIdentifier(string functionName, string identifier) {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            object[] parameters = new object[1];
            parameters[0] = identifier;
            sdkWrapper.Call(functionName, parameters);
        }

        private static bool IsInvalidRuntime(string identifier) {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.Android);
        }
    }
}
#endif
