#if UNITY_IOS

using UnityEngine;
using System.Runtime.InteropServices;

namespace Janus {
    internal class NativeInterface {

        static NativeInterface()
        {
            var _ = JanusSDK.Instance;
        }

        [DllImport("__Internal")] private static extern void janus_init();

        internal static void SetupSDK() {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            janus_init();
        }

        private static bool IsInvalidRuntime(string identifier) {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.IPhonePlayer);
        }
    }
}

#endif
