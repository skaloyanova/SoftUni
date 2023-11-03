package j_DefiningClasses_Exercises.FamilyTree;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<String> allData = new ArrayList<>();

        //read and save all data input
        String line = sc.nextLine().trim();
        while (!"End".equals(line)) {
            allData.add(line);
            line = sc.nextLine();
        }

        //create target Person with either bDay or name
        Person target;
        if (allData.get(0).contains("/")) {
            target = new Person("?", allData.get(0));
        } else {
            target = new Person(allData.get(0), "?");
        }

        //collect all people with name and birthday related, skipping 1st line
        Map<String,String> people = new HashMap<>();
        for (int i = 1; i < allData.size(); i++) {
            String entry = allData.get(i);
            if (!entry.contains("-")) {
                String[] tokens = entry.split("\\s+");
                String name = tokens[0] + " " + tokens[1];
                String birthday = tokens[2];
                people.put(name, birthday);
            }
        }

        //fill the other field in target Person
        for (Map.Entry<String, String> entry : people.entrySet()) {
            if (entry.getKey().equals(target.getFullName())) {
                target.setBirthday(entry.getValue());
                break;
            }
            if (entry.getValue().equals(target.getBirthday())) {
                target.setFullName(entry.getKey());
                break;
            }
        }

        //collect Parents and Children
        List<Person> parents = new ArrayList<>();
        List<Person> children = new ArrayList<>();

        for (int i = 1; i < allData.size(); i++) {
            String currentLine = allData.get(i);
            String[] tokens = currentLine.split(" - ");
            if (tokens.length > 1) {
                String parent = tokens[0];
                String child = tokens[1];
                //check if parent is target, i.e. we have "target - child" relation
                if (parent.contains("/")) {     //so this is Parent bDay
                    if (parent.equals(target.getBirthday())) {
                        addChild(people, children, child);
                    }
                } else {    //so this is Parent name
                    if (parent.equals(target.getFullName())) {
                        addChild(people, children, child);
                    }
                }

                //check if child is target, i.e. we have "parent - target" relation
                if (child.contains("/")) {     //so this is Parent bDay
                    if (child.equals(target.getBirthday())) {
                        addParent(people, parents, parent);
                    }
                } else {    //so this is Parent name
                    if (child.equals(target.getFullName())) {
                        addParent(people, parents, parent);
                    }
                }
            }
        }

        //print
        System.out.println(target);
        System.out.println("Parents:");
        parents.forEach(System.out::println);
        System.out.println("Children:");
        children.forEach(System.out::println);
    }

    private static void addChild(Map<String, String> people, List<Person> children, String child) {
        if (child.contains("/")) {
            for (Map.Entry<String, String> entry : people.entrySet()) {
                if (child.equals(entry.getValue())) {
                    children.add(new Person(entry.getKey(), child));
                    break;
                }
            }
        } else {
            children.add(new Person (child, people.get(child)));
        }
    }

    private static void addParent(Map<String, String> people, List<Person> parents, String parent) {
        if (parent.contains("/")) {
            for (Map.Entry<String, String> entry : people.entrySet()) {
                if (parent.equals(entry.getValue())) {
                    parents.add(new Person(entry.getKey(), parent));
                    break;
                }
            }
        } else {
            parents.add(new Person (parent, people.get(parent)));
        }
    }
}
