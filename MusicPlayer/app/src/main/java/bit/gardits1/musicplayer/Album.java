package bit.gardits1.musicplayer;

import java.io.Serializable;
import java.util.ArrayList;

/**
 * Created by Tim on 24/05/2016.
 */
public class Album implements Serializable {

    //TODO Create list of songs in album
    //TODO Populate based on folder
    //Potentially api search for actual album details
    //Still create album if only one song

    private ArrayList<Song> songsInAlbum;
    private String albumName;

    public Album(String albumName) {
        this.albumName = albumName;
        songsInAlbum = new ArrayList<>();
    }


    public ArrayList<Song> getSongsInAlbum() {
        return songsInAlbum;
    }

    public void setSongsInAlbum(ArrayList<Song> songsInAlbum) {
        for (Song song : songsInAlbum) {
            this.songsInAlbum.add(song);
        }
    }

    public String getAlbumName() {
        return albumName;
    }

}
