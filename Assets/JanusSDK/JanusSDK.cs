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

        internal void OnApiOk(string result) {
            API._OnApiOk(result);
        }

        internal void OnApiError(string result) {
            API._OnApiError(result);
        }
    }
}
