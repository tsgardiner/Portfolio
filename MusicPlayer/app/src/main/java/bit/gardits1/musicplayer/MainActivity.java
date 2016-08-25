package bit.gardits1.musicplayer;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

// TODO Opening screen of All Songs, All Artists, All Albums, Playlist
// TODO LiST of random album art from storedPlaylistSongs
// TODO Song playing controls?

public class MainActivity extends AppCompatActivity implements ISliderDisplay, IMusicControls {


    LoadSongFiles loadFiles;
    SQLiteDatabase playlistDB;
    PlaylistDatabase playlistDatabase;

    Player player;
    String playingSongName;
    String playingArtistName;
    TextView tvTitle;
    TextView tvClosedSong;
    ArrayList<Song> storedPlaylistSongs;

    private ImageButton btnPlay;
    private ImageButton btnPlayClosed;
    private ImageButton btnNext;
    private ImageButton btnPrevious;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Get instance of Player class
        player = Player.getInstance();

        loadFiles = new LoadSongFiles(getBaseContext());

        playlistDB = openOrCreateDatabase("playlistDB", MODE_PRIVATE, null);

        playlistDatabase = new PlaylistDatabase(playlistDB);


        btnPlay = (ImageButton) findViewById(R.id.btnPlay);
        btnPlayClosed = (ImageButton) findViewById(R.id.btnPlayClosed);
        btnNext = (ImageButton) findViewById(R.id.btnNext);
        btnPrevious = (ImageButton) findViewById(R.id.btnPrevious);

        tvTitle = (TextView) findViewById(R.id.tvSliderSong);
        tvClosedSong = (TextView) findViewById(R.id.tvSliderClosedSong);

        String[] menuItems = getResources().getStringArray(R.array.menu_items);

        ListView menuListView = (ListView) findViewById(R.id.lvMainMenu);
        ArrayAdapter<String> menuAdapter = new ArrayAdapter<>(this, android.R.layout.simple_expandable_list_item_1, menuItems);
        menuListView.setAdapter(menuAdapter);

        menuListView.setOnItemClickListener(new MenuClickedListener());


        PlaylistDatabase.UpdateDatabasePlaylist();
        storedPlaylistSongs = playlistDatabase.CreatePlaylistFromDB();
        Playlist.setPlaylist(storedPlaylistSongs);
        CheckPlayerState();
        UpdateDisplay();

        playlistDB.close();
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

    public class MenuClickedListener implements AdapterView.OnItemClickListener {

        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            String itemClicked = (String) parent.getItemAtPosition(position);
            Intent nextIntent;

            switch (itemClicked) {
                case "All Songs":
                    nextIntent = new Intent(MainActivity.this, AllSongsActivity.class);
                    break;
                case "Albums":
                    nextIntent = new Intent(MainActivity.this, AllAlbumsActivity.class);
                    break;
                case "Artists":
                    nextIntent = new Intent(MainActivity.this, AllArtistsActivity.class);
                    break;
                case "Playlists":
                    nextIntent = new Intent(MainActivity.this, PlaylistsActivity.class);
                    break;
                default:
                    nextIntent = null;
            }

            startActivity(nextIntent);
        }
    }
}
