package h_StreamsFilesAndDirectories_Exercises;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class CreateZipArchive {
    public static void main(String[] args) throws IOException {
        FileInputStream fis1 = new FileInputStream("src\\h_StreamsFilesAndDirectories_Exercises\\resources\\inputOne.txt");
        FileInputStream fis2 = new FileInputStream("src\\h_StreamsFilesAndDirectories_Exercises\\resources\\inputTwo.txt");
        FileInputStream fis3 = new FileInputStream("src\\h_StreamsFilesAndDirectories_Exercises\\resources\\words.txt");

        ZipOutputStream zip = new ZipOutputStream(new FileOutputStream("src\\h_StreamsFilesAndDirectories_Exercises\\zipped.zip"));
        ZipEntry one = new ZipEntry("inputOne.txt");
        ZipEntry two = new ZipEntry("inputTwo.txt");
        ZipEntry three = new ZipEntry("words.txt");

        zip.putNextEntry(one);
        zip.write(fis1.readAllBytes());
        zip.closeEntry();

        zip.putNextEntry(two);
        zip.write(fis2.readAllBytes());
        zip.closeEntry();

        zip.putNextEntry(three);
        zip.write(fis3.readAllBytes());
        zip.closeEntry();

        zip.close();
    }
}
