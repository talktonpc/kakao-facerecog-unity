using UnityEngine;

namespace Janus {
    public static class Helpers {
        internal static bool IsInvalidRuntime(string identifier, RuntimePlatform platform) {
            if (Application.platform != platform) {
                Debug.LogWarning("[JANUS SDK] This RuntimePlatform is not supported. Only iOS and Android devices are supported.");
                var errorJson = @"{""code"":-1, ""message"":""Platform not supported.""}";
                JanusSDK.Instance.OnApiError(errorJson);
                return true;
            }
            return false;
        }
    }
}

