package g_StreamsFilesAndDirectories_Lab;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

public class NestedFolders {
    public static void main(String[] args) {
        String rootPath = "src\\g_StreamsFilesAndDirectories_Lab\\resources\\Files-and-Streams";

        File rootFolder = new File(rootPath);
        
        //var1, using queue
//        Deque<File> folders = new ArrayDeque<>();
//        folders.offer(rootFolder);
//
//        int count = 0;
//        while (folders.size() > 0) {
//            File currentRoot = folders.poll();
//            System.out.println(currentRoot.getName());
//            count++;
//
//            File[] subFolders = currentRoot.listFiles(File::isDirectory);
//            for (File subFolder : subFolders) {
//                folders.offer(subFolder);
//            }
//        }
//        System.out.println(count + " folders");
        
        //var2, using recursion
        List<File> folders = new ArrayList<>();
        folders.add(rootFolder);
        scanFolders(rootFolder, folders);
        System.out.println(folders.size() + " folders");
    }

    private static void scanFolders(File dir, List<File> folders) {
        System.out.println(dir.getName());
        for (File file : dir.listFiles()) {
            if (file.isDirectory()){
                folders.add(file);
                scanFolders(file, folders);
            }
        }
    }
}
