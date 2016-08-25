package bit.gardits1.musicplayer;

import android.media.MediaPlayer;
import android.util.SparseBooleanArray;
import android.view.ActionMode;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

import java.io.IOException;
import java.util.ArrayList;

/**
 * Created by Tim on 24/05/2016.
 */
public class Player implements MediaPlayer.OnCompletionListener, ISliderDisplay, IMusicControls {

    private static Player player;
    int listPosition;
    MediaPlayer mediaPlayer = new MediaPlayer();
    TextView tvTitle, tvClosedSong;
    ListView currentSongListView;
    SongsAdapter songsAdapter;
    Song songClicked;
    ArrayList<Song> songArrayList;
    boolean playerOn;

    private Player() {
        mediaPlayer = new MediaPlayer();
    }

    public static Player getInstance() {
        if (player == null)
            player = new Player();
        return player;
    }

    public void runPlayer(TextView tvTitle, TextView tvClosedSong, ListView currentSongList, SongsAdapter songsAdapter, ArrayList<Song> songArrayList) {
        this.tvTitle = tvTitle;
        this.songsAdapter = songsAdapter;
        this.currentSongListView = currentSongList;
        this.tvClosedSong = tvClosedSong;
        this.songArrayList = songArrayList;

        mediaPlayer.setOnCompletionListener(this);

        currentSongList.setOnItemLongClickListener(new SelectSongsAddToPlaylistHandler());
        currentSongList.setOnItemClickListener(new PlaySongClickHandler());
    }

    //Uses the MediaPlayer to play the selected song
    public void playSong(Song selectedSong) {
        try {
            mediaPlayer.reset();
            mediaPlayer.setDataSource(selectedSong.getSongData());
            mediaPlayer.prepare();
            mediaPlayer.start();

            playerOn = true;

        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    //Once the song currently playing has finished the player moves to the next song in the list.
    // TODO Insert handling of last song in list.
    @Override
    public void onCompletion(MediaPlayer mp) {
        if (listPosition < (songArrayList.size() - 1)) {
            listPosition++;
            Song nextSong = songArrayList.get(listPosition);
            playSong(nextSong);
            songClicked = nextSong;
        }
    }

    @Override
    public void CheckPlayerState() {

    }

    public boolean getPlayerState() {
        if (playerOn)
            return true;
        else
            return false;
    }

    @Override
    public void Play(View view) {
        if (!mediaPlayer.isPlaying()) {
            mediaPlayer.start();
            playerOn = true;
        }
    }

    @Override
    public void Pause(View view) {
        mediaPlayer.pause();
        playerOn = false;
    }

    @Override
    public void Next(View view) {
        if (listPosition < (songArrayList.size() - 1)) {
            listPosition++;
            Song nextSong = songArrayList.get(listPosition);
            playSong(nextSong);
            songClicked = nextSong;
        }
    }

    @Override
    public void Previous(View view) {
        if (listPosition > 0) {
            listPosition--;
            Song previousSong = songArrayList.get(listPosition);
            playSong(previousSong);
            songClicked = previousSong;
        }
    }

    @Override
    public String getSongPlayingName() {
        if (songClicked != null) {
            String songName = songClicked.getName();
            if (songName != null)
                return songName;
            else
                return "";
        } else
            return null;
    }

    @Override
    public String getSongImage() {
        return null;
    }

    @Override
    public String getPlayingArtistName() {
        if (songClicked != null) {
            String artistName = songClicked.getArtist().getName();
            if (artistName != null)
                return artistName;
            else
                return "";
        } else
            return null;
    }

    @Override
    public String getPlayingAlbumName() {
        return null;
    }

    //Gets song on click of list view and plays the song
    public class PlaySongClickHandler implements AdapterView.OnItemClickListener {
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            songClicked = (Song) parent.getItemAtPosition(position);
            listPosition = position;

            tvTitle.setText(songClicked.getArtist().getName());
            tvClosedSong.setText(songClicked.getName());

            playSong(songClicked);
        }
    }

    // TODO This is currently set to happen on long click but a menu selector might be better suited.
    public class SelectSongsAddToPlaylistHandler implements AdapterView.OnItemLongClickListener {

        @Override
        public boolean onItemLongClick(AdapterView<?> adapterView, View view, int i, long l) {
            //Allows multiple items on the current song list to be selected to add to the storedPlaylistSongs.
            currentSongListView.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE_MODAL);
            currentSongListView.setMultiChoiceModeListener(new SelectMultipleSongs());

            return false;
        }
    }

    public class SelectMultipleSongs implements AbsListView.MultiChoiceModeListener {

        @Override
        public void onItemCheckedStateChanged(ActionMode mode, int position, long id, boolean checked) {
            mode.setTitle(currentSongListView.getCheckedItemCount() + " Songs Selected");
            songsAdapter.toggleSelected(position);
        }

        //Loads the menu for adding selected songs to the storedPlaylistSongs
        //TODO this will need a selection for deletion menu when wanting to remove songs from storedPlaylistSongs
        @Override
        public boolean onCreateActionMode(ActionMode mode, Menu menu) {
            mode.getMenuInflater().inflate(R.menu.add_playlist_menu, menu);
            return true;
        }

        @Override
        public boolean onPrepareActionMode(ActionMode mode, Menu menu) {
            return false;
        }

        @Override
        public boolean onActionItemClicked(ActionMode mode, MenuItem item) {
            if ((item.getItemId() == R.id.add_to_playlist) && (songsAdapter != null)) {
                SparseBooleanArray selected = songsAdapter.getSelectedItemsIds();
                for (int i = 0; i < selected.size(); i++) {
                    if (selected.valueAt(i)) {
                        Song selectedSong = songsAdapter.getItem(selected.keyAt(i));

                        //Add to list
                        Playlist.addSongToPlaylist(selectedSong);
                    }
                }
                mode.finish();
                return true;
            }
            return false;
        }

        @Override
        public void onDestroyActionMode(ActionMode mode) {

        }
    }
}
