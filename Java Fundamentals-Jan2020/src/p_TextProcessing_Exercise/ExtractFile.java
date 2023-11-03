package p_TextProcessing_Exercise;

import java.util.Scanner;

public class ExtractFile {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String filePath = sc.nextLine();

        int lastBackSlashIndex = filePath.lastIndexOf("\\");
        int lastPointIndex = filePath.lastIndexOf(".");

        String fileName = filePath.substring(lastBackSlashIndex + 1, lastPointIndex);
        String fileExt = filePath.substring(lastPointIndex + 1);

        System.out.println("File name: " + fileName);
        System.out.println("File extension: " + fileExt);
    }
}
