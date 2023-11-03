package p_TextProcessing_Exercise;

import java.util.Scanner;

public class xHTML {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String title = sc.nextLine();
        String article = sc.nextLine();

        StringBuilder sb = new StringBuilder();
        title = String.format("<h1>%n%s%n</h1>%n", title);
        article = String.format("<article>%n%s%n</article>%n", article);
        sb.append(title);
        sb.append(article);

        String comments = sc.nextLine();

        while (!"end of comments".equals(comments)) {
            comments = String.format("<div>%n%s%n</div>%n", comments);
            sb.append(comments);

            comments = sc.nextLine();
        }
        System.out.println(sb);
    }
}
