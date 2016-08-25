package bit.gardits1.musicplayer;

import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import java.util.ArrayList;
import java.util.PriorityQueue;

/**
 * Created by Tim on 30/05/2016.
 */
public class PlaylistDatabase {

    private static SQLiteDatabase playlistDB;
    private static ArrayList<Song> playlist;

    public PlaylistDatabase(SQLiteDatabase playlistDB) {
        PlaylistDatabase.playlistDB = playlistDB;

        CreatePlaylistTable();
    }

    public static void UpdateDatabasePlaylist() {
        PlaylistDatabase.playlist = Playlist.getPlaylist();
        InsertPlaylistIntoDB();
    }

    private static void Insert(String songID) {
        try {
            String insertQuery = "INSERT INTO tblPlaylist (songID) VALUES('" + songID + "')";
            playlistDB.execSQL(insertQuery);
        } catch (SQLException e) {
            //Insert was throwing a sneaky exception but it wasn't showing up without this.
            Log.e("Insert Exception: ", e.getMessage());
        }

    }

    //Might be needed to insert whole storedPlaylistSongs
    private static void InsertPlaylistIntoDB() {
        for (Song s : playlist) {
            if (!CheckIfSongIsInDB(s)){
                Insert(s.getSongId());
            }
        }
    }

    private static Boolean CheckIfSongIsInDB(Song song){
        Boolean found = false;

        String id = song.getSongId();

        String songQuery = "SELECT songID FROM tblPlaylist " +
                            "WHERE songID = " + id;

        Log.e("query: ", songQuery);

        Cursor songSet = playlistDB.rawQuery(songQuery, null);

        int count = songSet.getCount();

        if (count > 0) {
            int index = songSet.getColumnIndex("songID");

            songSet.moveToFirst();

            String songID = songSet.getString(index);

            if (songID != null)
                found = true;
        }

        return found;
    }

    private void CreatePlaylistTable() {
        String createQuery = "CREATE TABLE IF NOT EXISTS tblPlaylist(" +
                "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "songID TEXT NOT NULL" +
                ");";
        playlistDB.execSQL(createQuery);
    }


    public ArrayList<Song> CreatePlaylistFromDB() {

        ArrayList<Song> storedPlaylist = new ArrayList<>();
        ArrayList<Song> allSongsList = LoadSongFiles.getSongList();

        String selectSongs = "SELECT * FROM tblPlaylist";

        Cursor songSet = playlistDB.rawQuery(selectSongs, null);

        int songCount = songSet.getCount();
        int songIndex = songSet.getColumnIndex("songID");

        songSet.moveToNext();

        for (int i = 0; i < songCount; i++) {
            String songID = songSet.getString(songIndex);
            for (Song song : allSongsList) {
                if (song.getSongId().equals(songID)) {
                    storedPlaylist.add(song);
                }
            }
            songSet.moveToNext();
        }

        return storedPlaylist;
    }


    public ArrayList<Song> getPlaylist() {
        return playlist;
    }
}



