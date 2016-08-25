package bit.gardits1.musicplayer;

import android.view.View;

/**
 * Created by Tim on 31/05/2016.
 */
public interface IMusicControls {

    void CheckPlayerState();

    void Play(View view);

    void Pause(View view);

    void Next(View view);

    void Previous(View view);


}
