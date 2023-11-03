package h_StreamsFilesAndDirectories_Exercises;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class CopyPicture {
    public static void main(String[] args) throws IOException {
        String picture = "D:\\Sport\\Garmin-personal records.JPG";
        String copyPicture = "src\\h_StreamsFilesAndDirectories_Exercises\\copyOfPicture.jpg";

        FileInputStream fis = new FileInputStream(picture);
        byte[] pictureBytes = fis.readAllBytes();

        FileOutputStream fos = new FileOutputStream(copyPicture);
        fos.write(pictureBytes);
        fos.close();

    }
}
