package bit.gardits1.musicplayer;

import android.content.Context;
import android.util.SparseBooleanArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by Tim on 27/05/2016.
 */
public class SongsAdapter extends ArrayAdapter<Song> {

    Context mContext;
    private SparseBooleanArray selectedItemsIds;

    public SongsAdapter(Context context, int resource, ArrayList<Song> objects) {
        super(context, resource, objects);
        mContext = context;
        selectedItemsIds = new SparseBooleanArray();

    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        LayoutInflater inflater = LayoutInflater.from(mContext);

        View customView = inflater.inflate(R.layout.song_listview, parent, false);

        TextView songTitle = (TextView) customView.findViewById(R.id.song_title);
        TextView artist = (TextView) customView.findViewById(R.id.song_artist);
        TextView duration = (TextView) customView.findViewById(R.id.song_duration);

        Song currentSong = getItem(position);

        songTitle.setText(currentSong.getName());
        artist.setText(currentSong.getArtist().getName());
        duration.setText(currentSong.getDisplayDuration());

        return customView;
    }

    public void toggleSelected(int position) {
        selectedView(position, !selectedItemsIds.get(position));
    }

    public void selectedView(int position, boolean value) {
        if (value)
            selectedItemsIds.put(position, value);
    }


    public SparseBooleanArray getSelectedItemsIds() {
        return selectedItemsIds;
    }

}
