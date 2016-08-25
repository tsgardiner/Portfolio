package bit.gardits1.musicplayer;

import java.io.Serializable;

/**
 * Created by Tim on 24/05/2016.
 */
public class Song implements Serializable {

    // TODO Base song class
    // Created from loading song data from file.

    private String songId;
    private String name;
    private String songData;
    private String displayDuration;
    private long songDuration;

    private Artist artist;
    private Album album;

    public Song(String songId, String name, Artist artistName, Album albumName, String songData, long songDuration, String displayDuration) {
        this.songId = songId;
        this.name = name;
        artist = artistName;
        album = albumName;
        this.songData = songData;
        this.songDuration = songDuration;
        this.displayDuration = displayDuration;
    }

    public String getSongData() {
        return songData;
    }

    public String getName() {
        return name;
    }

    public Album getAlbum() {
        return album;
    }

    public void setAlbum(Album album) {
        this.album = album;
    }

    public Artist getArtist() {
        return artist;
    }

    public void setArtist(Artist artist) {
        this.artist = artist;
    }

    public String getDisplayDuration() {
        return displayDuration;
    }

    public String getSongId() {
        return songId;
    }
}
