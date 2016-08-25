package bit.gardits1.musicplayer;

import android.content.ContentResolver;
import android.content.Context;
import android.content.ContextWrapper;
import android.database.Cursor;
import android.net.Uri;
import android.provider.MediaStore;

import java.util.ArrayList;

/**
 * Created by Tim on 24/05/2016.
 */

// TODO Read music files from storage populating song list, artist, albums

public class LoadSongFiles extends ContextWrapper {

    private static ArrayList<Song> songList;
    private static ArrayList<Artist> artistList;
    private static ArrayList<Album> albumList;


    // TODO ADD ALBUMS AND CREATE ARTIST ALBUMS LISTS
    // TODO CHECK SONG INDEX ADD TO SONG CLASS


    public LoadSongFiles(Context base) {
        super(base);
        CreateSongList();
        BuildAlbumSongsLists();
        BuildArtistSongsLists();
    }

    public static ArrayList<Song> getSongList() {
        return songList;
    }

    public static ArrayList<Artist> getArtistList() {
        return artistList;
    }

    public static ArrayList<Album> getAlbumList() {
        return albumList;
    }

    private void CreateSongList() {
        songList = new ArrayList<>();
        artistList = new ArrayList<>();
        albumList = new ArrayList<>();

        ContentResolver musicResolver = getContentResolver();
        Uri musicUri = MediaStore.Audio.Media.EXTERNAL_CONTENT_URI;

        String selection = MediaStore.Audio.Media.IS_MUSIC + " = 1";

        Cursor musicCursor = musicResolver.query(musicUri, null, selection, null, null);

        if (musicCursor != null && musicCursor.moveToFirst()) {
            int titleColumn = musicCursor.getColumnIndex(MediaStore.Audio.Media.TITLE);
            int artistColumn = musicCursor.getColumnIndex(MediaStore.Audio.Media.ARTIST);
            int dataColumn = musicCursor.getColumnIndex(MediaStore.Audio.Media.DATA);
            int durationColumn = musicCursor.getColumnIndex(MediaStore.Audio.Media.DURATION);
            int songIdColumn = musicCursor.getColumnIndex(MediaStore.Audio.Media._ID);
            int albumColumn = musicCursor.getColumnIndex(MediaStore.Audio.Media.ALBUM);

            do {
                String songId = musicCursor.getString(songIdColumn);
                String title = musicCursor.getString(titleColumn);
                String artistName = musicCursor.getString(artistColumn);
                String albumName = musicCursor.getString(albumColumn);
                String data = musicCursor.getString(dataColumn);
                long duration = musicCursor.getLong(durationColumn);

                String displayDuration = DurationToMinutes(duration);

                //Unique Artist and Album objects cannot be created this way.
                Artist artist = CreateArtist(artistName);
                Album album = CreateAlbum(albumName);

                songList.add(new Song(songId, title, artist, album, data, duration, displayDuration));


            } while (musicCursor.moveToNext());
        }
        if (musicCursor != null) {
            musicCursor.close();
        }


    }

    private Artist CreateArtist(String name) {

        Boolean found = false;
        Artist artist = null;
        int index = 0;

        for (Artist a : artistList) {
            if (a.getName().equals(name)) {
                found = true;
                index = artistList.indexOf(a);
            }
        }

        if (found) {
            artist = artistList.get(index);
        }
        else if (!found) {
            artist = new Artist(name);
            artistList.add(artist);
        }

        return artist;
    }

    private Album CreateAlbum(String name) {

        Boolean found = false;
        Album album = null;
        int index = 0;

        for (Album a : albumList) {
            if (a.getAlbumName().equals(name)) {
                found = true;
                index = albumList.indexOf(a);
            }
        }

        if (found) {
            album = albumList.get(index);
        }
        else if (!found) {
            album = new Album(name);
            albumList.add(album);
        }

        return album;
    }

    private void BuildAlbumSongsLists() {
        ArrayList<Song> albumSongs = new ArrayList<>();

        for (Album album : albumList) {
            for (Song song : songList) {
                if (album.getAlbumName().equals(song.getAlbum().getAlbumName()))
                    albumSongs.add(song);
            }

            album.setSongsInAlbum(albumSongs);
            albumSongs.clear();
        }
    }

    private void BuildArtistSongsLists() {
        ArrayList<Song> artistSongs = new ArrayList<>();

        for (Artist artist : artistList) {
            for (Song song : songList) {
                if (artist.getName().equals(song.getArtist().getName()))
                    artistSongs.add(song);
            }

            artist.setSongs(artistSongs);
            artistSongs.clear();
        }
    }

    private String DurationToMinutes(long songDuration) {
        long seconds = (songDuration / 1000) % 60;
        long minutes = (songDuration / (1000 * 60)) % 60;

        return String.format("%02d:%02d", minutes, seconds);
    }
}
