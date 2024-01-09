package c_inheritance_Lab.randomArrayList;

public class Main {
    public static void main(String[] args) {
        RandomArrayList<Integer> randomArrayList = new RandomArrayList<>();

        for (int i = 0; i < 10; i++) {
            randomArrayList.add(i);
        }

        System.out.println("list size: " + randomArrayList.size());

        System.out.println(randomArrayList.getRandomElement());
        System.out.println(randomArrayList.getRandomElement());
        System.out.println(randomArrayList.getRandomElement());
        System.out.println(randomArrayList.getRandomElement());
        System.out.println(randomArrayList.getRandomElement());
        System.out.println(randomArrayList.getRandomElement());
        System.out.println(randomArrayList.getRandomElement());
        System.out.println(randomArrayList.getRandomElement());
    }
}
