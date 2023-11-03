package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class SoftUniCoursePlanning {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] consoleRead = sc.nextLine().split(",+\\s+");
        ArrayList<String> data = new ArrayList<>(Arrays.asList(consoleRead));

        while (true) {
            String input = sc.nextLine();
            if ("course start".equals(input)) {
                break;
            }

            String[] tokens = input.split(":+");
            String lessonTitle = tokens[1];
            String exerciseTitle = lessonTitle + "-Exercise";

            switch (tokens[0]) {
                case "Add":
                    if (!data.contains(lessonTitle)) {
                        data.add(lessonTitle);
                    }
                    break;
                case "Insert":
                    int index = Integer.parseInt(tokens[2]);
                    if (!data.contains(lessonTitle)) {
                        data.add(index, lessonTitle);
                    }
                    break;
                case "Remove":
                    data.remove(lessonTitle);
                    data.remove(exerciseTitle);
                    break;
                case "Swap": {
                    String lessonTitle2 = tokens[2];
                    String exerciseTitle2 = lessonTitle2 + "-Exercise";

                    int indexL1 = data.indexOf(lessonTitle);        //if object does not exists, returns "-1"
                    int indexL2 = data.indexOf(lessonTitle2);       //if object does not exists, returns "-1"

                    if (indexL1 >= 0 && indexL2 >= 0) {
                        data.set(indexL1, lessonTitle2);
                        data.set(indexL2, lessonTitle);

                        if (data.remove(exerciseTitle)) {
                            int exerciseIndex = data.indexOf(lessonTitle) + 1;
                            data.add(exerciseIndex, exerciseTitle);
                        }
                        if (data.remove(exerciseTitle2)) {
                            int exerciseIndex = data.indexOf(lessonTitle2) + 1;
                            data.add(exerciseIndex, exerciseTitle2);
                        }
                    }
                }
                break;
                case "Exercise":
                    if (!data.contains(exerciseTitle)) {
                        if (data.contains(lessonTitle)) {
                            int exerciseIndex = data.indexOf(lessonTitle) + 1;
                            data.add(exerciseIndex, exerciseTitle);
                        } else {
                            data.add(lessonTitle);
                            data.add(exerciseTitle);
                        }
                    }
                    break;
            }

        }

        for (int i = 0; i < data.size(); i++) {
            System.out.println((i + 1) + "." + data.get(i));
        }
    }
}
