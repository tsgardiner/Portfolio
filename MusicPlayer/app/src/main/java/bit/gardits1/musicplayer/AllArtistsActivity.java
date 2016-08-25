package bit.gardits1.musicplayer;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

public class AllArtistsActivity extends AppCompatActivity implements ISliderDisplay, IMusicControls {

    Player player;

    String playingSongName;
    String playingArtistName;
    TextView tvTitle;
    TextView tvClosedSong;
    ArrayList<Artist> artistList;
    private ImageButton btnPlay;
    private ImageButton btnPlayClosed;
    private ImageButton btnNext;
    private ImageButton btnPrevious;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_all_artists);

        artistList = LoadSongFiles.getArtistList();

        player = Player.getInstance();

        btnPlay = (ImageButton) findViewById(R.id.btnPlay);
        btnPlayClosed = (ImageButton) findViewById(R.id.btnPlayClosed);
        btnNext = (ImageButton) findViewById(R.id.btnNext);
        btnPrevious = (ImageButton) findViewById(R.id.btnPrevious);

        tvTitle = (TextView) findViewById(R.id.tvSliderSong);
        tvClosedSong = (TextView) findViewById(R.id.tvSliderClosedSong);

        ArrayList<String> artistNames = CreateArtistDisplayList();

        ListView allArtists = (ListView) findViewById(R.id.lvAllArtists);
        ArrayAdapter<String> albumsMenuAdapter = new ArrayAdapter<>(this, android.R.layout.simple_expandable_list_item_1, artistNames);
        allArtists.setAdapter(albumsMenuAdapter);

        allArtists.setOnItemClickListener(new MenuClickedListener());

        CheckPlayerState();
        UpdateDisplay();
    }

    private ArrayList<String> CreateArtistDisplayList() {
        ArrayList<String> artistNames = new ArrayList<>();

        for (Artist artist : artistList) {
            artistNames.add(artist.getName());
        }

        return artistNames;
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


    //Currently breaks app because song list is too large to pass to next activity

    public class MenuClickedListener implements AdapterView.OnItemClickListener {

        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            String artistClickedString = (String) parent.getItemAtPosition(position);

            Intent nextIntent = new Intent(AllArtistsActivity.this, ArtistSongsActivity.class);

            Bundle bundle = new Bundle();
            bundle.putSerializable("artistSelected", artistClickedString);
            nextIntent.putExtras(bundle);
            startActivity(nextIntent);
        }
    }
}
