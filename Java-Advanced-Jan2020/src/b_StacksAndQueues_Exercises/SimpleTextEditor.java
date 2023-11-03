package b_StacksAndQueues_Exercises;

        import java.util.ArrayDeque;
        import java.util.Scanner;

public class SimpleTextEditor {
    private static ArrayDeque<String> previous;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        previous = new ArrayDeque<>();
        StringBuilder text = new StringBuilder();

        for (int i = 0; i < n; i++) {
            String[]tokens = sc.nextLine().split("\\s+");
            switch (tokens[0]) {
                case "1": appendString(text, tokens[1]); break;
                case "2": eraseCntElements(text, Integer.parseInt(tokens[1])); break;
                case "3":
                    char element = returnElementAtIndex(text, Integer.parseInt(tokens[1]));
                    System.out.println(element);
                    break;
                case "4": undo(text); break;
            }
        }
    }

    private static void undo(StringBuilder text) {
        if (previous.size() > 0) {
            text.setLength(0);
            text.append(previous.pop());
        }
    }

    private static char returnElementAtIndex(StringBuilder text, int index) {
        return text.charAt(index - 1);
    }

    private static void eraseCntElements(StringBuilder text, int count) {
        previous.push(text.toString());
        text.replace(text.length() - count, text.length(), "");
    }

    private static void appendString(StringBuilder text, String string) {
        previous.push(text.toString());
        text.append(string);
    }
}
