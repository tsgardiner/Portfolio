package bit.gardits1.musicplayer;

import java.io.Serializable;
import java.util.ArrayList;

/**
 * Created by Tim on 24/05/2016.
 */
public class Artist implements Serializable {

    // TODO Artist details class
    // TODO Populate from song and album at read in time

    private ArrayList<Song> songs;
    private String name;

    public Artist(String name) {
        this.name = name;
        songs = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    public ArrayList<Song> getSongs() {
        return songs;
    }

    public void setSongs(ArrayList<Song> songs) {
        for (Song song : songs) {
            this.songs.add(song);
        }
    }
}
