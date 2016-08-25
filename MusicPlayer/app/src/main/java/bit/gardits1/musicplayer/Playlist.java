package bit.gardits1.musicplayer;

import java.util.ArrayList;

/**
 * Created by Tim on 24/05/2016.
 */
public class Playlist {

    // TODO List view of songs that the user creates.
    // TODO Create database for storedPlaylistSongs
    // TODO Add to storedPlaylistSongs button lets list view of songs be selectable to add to storedPlaylistSongs
    // Look up how to change list box highlighting on tap
    // Create temp add to storedPlaylistSongs list
    // Add Selected to storedPlaylistSongs button
    // Add, Remove, Playlist Name

    private static ArrayList<Song> playlist = new ArrayList<>();
    private String name;

    public static void addSongToPlaylist(Song song) {
        boolean found = false;

        for (Song s : playlist) {
            if (song.getName().equals(s.getName()))
                found = true;
        }

        if (!found){
            playlist.add(song);
        }
    }

    public static ArrayList<Song> getPlaylist() {
        return playlist;
    }

    public static void setPlaylist(ArrayList<Song> playlist) {
        Playlist.playlist = playlist;
    }

    public void removeSongFromPlaylist(Song song) {
        playlist.remove(song);
    }

}



