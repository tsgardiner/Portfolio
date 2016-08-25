package bit.gardits1.musicplayer;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

public class AlbumSongsActivity extends AppCompatActivity implements ISliderDisplay, IMusicControls {


    private static ArrayList<Song> songsList;
    Player player;
    String playingSongName;
    String playingArtistName;
    TextView tvTitle;
    TextView tvAlbum;
    TextView tvClosedSong;
    private ImageButton btnPlay;
    private ImageButton btnPlayClosed;
    private ImageButton btnNext;
    private ImageButton btnPrevious;
    private String albumSelected;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_album_songs);

        player = Player.getInstance();

        albumSelected = (String) getIntent().getExtras().getSerializable("albumSelected");
        songsList = CreateSongList(albumSelected);

        btnPlay = (ImageButton) findViewById(R.id.btnPlay);
        btnPlayClosed = (ImageButton) findViewById(R.id.btnPlayClosed);
        btnNext = (ImageButton) findViewById(R.id.btnNext);
        btnPrevious = (ImageButton) findViewById(R.id.btnPrevious);

        tvTitle = (TextView) findViewById(R.id.tvSliderSong);
        tvAlbum = (TextView) findViewById(R.id.tvSongListTitle);
        tvClosedSong = (TextView) findViewById(R.id.tvSliderClosedSong);

        tvAlbum.setText(albumSelected);

        ListView allSongs = (ListView) findViewById(R.id.lvAllSongs);
        SongsAdapter songsAdapter = new SongsAdapter(this, R.layout.song_listview, songsList);
        allSongs.setAdapter(songsAdapter);

        player.runPlayer(tvTitle, tvClosedSong, allSongs, songsAdapter, songsList);

    }

    private ArrayList<Song> CreateSongList(String albumSelected){

        Album albumClicked = null;
        for (Album album : LoadSongFiles.getAlbumList()) {
            if (album.getAlbumName().equals(albumSelected))
                albumClicked = album;
        }

        ArrayList<Song> albumSongs = new ArrayList<>();

        for (Song s : albumClicked.getSongsInAlbum() ) {
            albumSongs.add(s);
        }

        return albumSongs;
    }

    private void UpdateDisplay() {
        playingArtistName = getPlayingArtistName();
        playingSongName = getSongPlayingName();

        if (playingArtistName != null && playingSongName != null) {
            tvTitle.setText(playingArtistName);
            tvClosedSong.setText(playingSongName);
        }
    }

    @Override
    public void CheckPlayerState() {
        if (player.getPlayerState())
            btnPlay.setImageResource(R.drawable.ic_pause_black_24dp);
        btnPlayClosed.setImageResource(R.drawable.ic_pause_black_24dp);
        if (!player.getPlayerState())
            btnPlay.setImageResource(R.drawable.ic_play_arrow_black_24dp);
        btnPlayClosed.setImageResource(R.drawable.ic_play_arrow_black_24dp);
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
