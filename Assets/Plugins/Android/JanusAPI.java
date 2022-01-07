package Janus;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.content.res.AssetManager;
import com.unity3d.player.UnityPlayer;
import com.kakaoenterprise.janus.JanusFaceIdentifier;

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
}
