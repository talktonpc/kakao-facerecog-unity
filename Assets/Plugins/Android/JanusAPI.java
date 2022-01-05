package Janus;

import android.util.Log;

import com.kakaoenterprise.janus.IPL;
import com.kakaoenterprise.janus.JanusFaceGallery;
import com.kakaoenterprise.janus.JanusFaceIdentifier;
import com.kakaoenterprise.janus.JanusPolicy;
import com.kakaoenterprise.janus.Measurer;
import com.kakaoenterprise.janus.SceneChangeDetectionPolicy;

public class JanusAPI extends JanusFaceIdentifier
{
    JanusAPI() {
        super();
        Log.i("V", "JanusSDK: JanusSDK () ...");
    }

    public void janus_init() {
        Log.i("V","JanusSDK: janus_init ...");
    }
}
