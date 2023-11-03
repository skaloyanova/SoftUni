package f_SetsAndMapsAdvanced_Exercises;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class UserLogs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Map<String,Integer>> users = new TreeMap<>();
        //< usr, < ip, count > >

        final String REGEX = "IP=(?<ip>.+) m.*user=(?<usr>.{3,50})";
//        final String REGEX = "IP=(?<ip>[0-9A-F:\\.]+).*user=(?<usr>.{3,50})";
        Pattern pattern = Pattern.compile(REGEX);

        String line = sc.nextLine();
        while (!"end".equals(line)) {
            Matcher matcher = pattern.matcher(line);
            while (matcher.find()) {
                String ip = matcher.group("ip");
                String usr = matcher.group("usr");

                users.putIfAbsent(usr, new LinkedHashMap<>());
                users.get(usr).putIfAbsent(ip,0);
                users.get(usr).put(ip,users.get(usr).get(ip) + 1);
            }

            line = sc.nextLine();
        }

        users.forEach((k,v) -> {
            System.out.println(k + ": ");
            StringBuilder sb = new StringBuilder();
            v.forEach((i,c) -> {
                sb.append(i).append(" => ").append(c).append(", ");
            });
            sb.replace(sb.length() - 2,sb.length(), ".");
            System.out.println(sb);
        });
    }
}
