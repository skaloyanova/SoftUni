package k_ObjectsAndClasses.Songs;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        ArrayList<Song> music = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String input = sc.nextLine();
            String[] songInfo = input.split("_");

            Song currentSong = new Song(songInfo[0], songInfo[1], songInfo[2]);
            music.add(currentSong);
        }

        String filterType = sc.nextLine();

        if (filterType.equals("all")) {
            for (Song song : music) {
                System.out.println(song.getName());
            }
        } else {
            for (Song song : music) {
                if (song.getTypeList().equals(filterType)) {
                    System.out.println(song.getName());
                }
            }
        }
    }
}
