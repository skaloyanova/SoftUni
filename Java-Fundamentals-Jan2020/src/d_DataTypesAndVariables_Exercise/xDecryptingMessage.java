package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class xDecryptingMessage {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int key = Integer.parseInt(sc.nextLine());
        int n = Integer.parseInt(sc.nextLine());

        StringBuilder decrypted = new StringBuilder();

        for (int i = 0; i < n; i++) {
            char letter = sc.nextLine().charAt(0);

            decrypted.append((char) (letter + key));
        }
        System.out.println(decrypted);
    }
}
