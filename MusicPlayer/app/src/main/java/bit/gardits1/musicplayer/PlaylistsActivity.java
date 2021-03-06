package bit.gardits1.musicplayer;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

public class PlaylistsActivity extends AppCompatActivity implements ISliderDisplay, IMusicControls {

    Player player;

    String playingSongName;
    String playingArtistName;
    TextView tvTitle;
    TextView tvClosedSong;
    private ArrayList<Song> playlistSongs;
    private ImageButton btnPlay;
    private ImageButton btnPlayClosed;
    private ImageButton btnNext;
    private ImageButton btnPrevious;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_playlists);

        player = Player.getInstance();

        btnPlay = (ImageButton) findViewById(R.id.btnPlay);
        btnPlayClosed = (ImageButton) findViewById(R.id.btnPlayClosed);
        btnNext = (ImageButton) findViewById(R.id.btnNext);
        btnPrevious = (ImageButton) findViewById(R.id.btnPrevious);

        tvTitle = (TextView) findViewById(R.id.tvSliderSong);
        tvClosedSong = (TextView) findViewById(R.id.tvSliderClosedSong);

        ListView playlistView = (ListView) findViewById(R.id.lvPlaylist);

        playlistSongs = Playlist.getPlaylist();


        SongsAdapter songsAdapter = new SongsAdapter(this, R.layout.song_listview, playlistSongs);
        playlistView.setAdapter(songsAdapter);

        player.runPlayer(tvTitle, tvClosedSong, playlistView, songsAdapter, playlistSongs);

        CheckPlayerState();
        UpdateDisplay();
    }


    private void UpdateDisplay() {
        playingArtistName = getPlayingArtistName();
        playingSongName = getSongPlayingName();

        tvTitle.setText(playingArtistName);
        tvClosedSong.setText(playingSongName);
    }

    @Override
    public void CheckPlayerState() {
        if (player.getPlayerState())
            btnPlay.setImageResource(R.drawable.ic_pause_black_24dp);
        if (!player.getPlayerState())
            btnPlay.setImageResource(R.drawable.ic_play_arrow_black_24dp);
    }

    @Override
    public void Play(View view) {
        if (!player.getPlayerState()) {
            player.Play(view);
            CheckPlayerState();
        } else {
            player.Pause(view);
            CheckPlayerState();
        }
    }

    @Override
    public void Pause(View view) {
    }

    @Override
    public void Next(View view) {
        player.Next(view);
        UpdateDisplay();
    }

    @Override
    public void Previous(View view) {
        player.Previous(view);
        UpdateDisplay();
    }

    @Override
    public String getSongPlayingName() {
        return player.getSongPlayingName();
    }

    @Override
    public String getSongImage() {
        return player.getSongImage();
    }

    @Override
    public String getPlayingArtistName() {
        return player.getPlayingArtistName();
    }

    @Override
    public String getPlayingAlbumName() {
        return null;
    }


}
