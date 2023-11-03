package z_Exam_20180827_Retake_archived;

import java.util.*;

public class Agency {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        //stack
        ArrayDeque<String> idNumbers = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+")).forEach(idNumbers::push);

        //queue
        ArrayDeque<String> agents = new ArrayDeque<>();
        Arrays.stream(sc.nextLine().split("\\s+")).forEach(agents::offer);

        String command = sc.nextLine();
        while (!"stop".equals(command)) {
            String[] tokens = command.split("\\s+");

            switch (tokens[0]) {
                case "add-ID":
                    idNumbers.push(tokens[1]);
                    break;
                case "add-agent":
                    agents.offer(tokens[1]);
                    break;
                case "remove-ID":
                    System.out.println(idNumbers.pop() + " has been removed.");
                    break;
                case "remove-agent":
                    System.out.println(agents.removeLast() + " has left the queue.");
                    break;
                case "sort-ID":
                    List<String> temp = new ArrayList<>(idNumbers);
                    temp.sort(Comparator.naturalOrder());
                    idNumbers = new ArrayDeque<>();
                    for (String s : temp) {
                        idNumbers.push(s);
                    }
                    break;
            }

            command = sc.nextLine();
        }

        //print
        while (agents.size() > 0 && idNumbers.size() > 0) {
            System.out.println(agents.poll() + " takes ID number: " + idNumbers.pop());
        }

        if (agents.size() == 0 && idNumbers.size() > 0) {
            System.out.println("No more agents left.");
        }

        while (idNumbers.size() > 0) {
            System.out.println("ID number: " + idNumbers.pop());
        }

        while (agents.size() > 0) {
            System.out.println(agents.poll() + " does not have an ID.");
        }
    }
}
