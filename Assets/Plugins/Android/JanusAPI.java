package Janus;

import java.nio.ByteBuffer;
import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.content.res.AssetManager;

import com.unity3d.player.UnityPlayer;

import com.kakaoenterprise.janus.IPL;
import com.kakaoenterprise.janus.JanusFaceGallery;
import com.kakaoenterprise.janus.JanusFaceIdentifier;
import com.kakaoenterprise.janus.JanusPolicy;
import com.kakaoenterprise.janus.Measurer;
import com.kakaoenterprise.janus.SceneChangeDetectionPolicy;

public class JanusAPI extends JanusFaceIdentifier
{
    private static Activity activity;
    private static JanusFaceIdentifier detector;

    JanusAPI() {
        super();
        Log.i("V", "JanusSDK: face detector loaded.");
        activity = UnityPlayer.currentActivity;
        detector = this;
    }

    public static void janus_init() {
        Log.i("V","JanusSDK: face detector initialize.");
        Context context = activity.getApplicationContext();
        AssetManager am = context.getResources().getAssets();
        detector.initWithPackageAssetFile(am, "kaen_tflite_models_english.bin");
    }

    public static int janus_detect(byte[] image, int width, int height, boolean detect) {
        Log.i("V","JanusSDK: face detector processing byte[]");

        return detector.detectFaceRGBA(image, width, height, detect);
    }
    public static int janus_detect(byte[] image, int width, int height, boolean detect, int size) {
        Log.i("V","JanusSDK: face detector processing byte[] with size : " + size);

        return detector.detectFaceRGBA(image, width, height, detect);
    }

    public static int janus_detect(ByteBuffer image, int width, int height, boolean detect) {
        Log.i("V","JanusSDK: face detector processing ByteBuffer.");

        return detector.detectFaceRGBA(image, width, height, detect);
    }

    public static int janus_detect_with_bytebuffer(ByteBuffer image, int width, int height, boolean detect) {
        Log.i("V","JanusSDK: face detector processing ByteBuffer.");

        return detector.detectFaceRGBA(image, width, height, detect);
    }
}
