package Janus;

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

    JanusAPI() {
        super();
        Log.i("V", "JanusSDK: face detector loaded.");
        activity = UnityPlayer.currentActivity;
    }

    public void janus_init() {
        Log.i("V","JanusSDK: face detector initialize.");
        Context context = activity.getApplicationContext();
        AssetManager am = context.getResources().getAssets();
        initWithPackageAssetFile(am, "kaen_tflite_models_english.bin");
    }
}
