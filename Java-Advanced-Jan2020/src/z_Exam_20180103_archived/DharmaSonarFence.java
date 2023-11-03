package z_Exam_20180103_archived;

import java.util.*;

public class DharmaSonarFence {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Long> resultantDecimals = new ArrayList<>();

        String input = sc.nextLine();

        while (!"Reprogram".equals(input)) {
            int decimal = Integer.parseInt(input);
            String binaryStr = Integer.toBinaryString(decimal);

            String filledBinaryStr = "";
            for (int i = 0; i < 32 - binaryStr.length(); i++) {
                filledBinaryStr += "0";
            }

            filledBinaryStr += binaryStr;

            char[] binary = filledBinaryStr.toCharArray();

            int index = 0;
            while (index < binary.length - 1) {
                char current = binary[index];
                char next = binary[index + 1];

                if (current == next) {
                    if (current == '1') {
                        binary[index] = '0';
                        binary[index + 1] = '0';
                    } else {
                        binary[index] = '1';
                        binary[index + 1] = '1';
                    }
                    index++;
                }

                index++;
            }

            String modifiedBinary = Arrays.toString(binary).replaceAll("[\\[\\], ]", "");
            resultantDecimals.add(Long.parseLong(modifiedBinary, 2));

            input = sc.nextLine();
        }

        //print
        for (Long decimal : resultantDecimals) {
            System.out.println(decimal);
        }
    }
}
