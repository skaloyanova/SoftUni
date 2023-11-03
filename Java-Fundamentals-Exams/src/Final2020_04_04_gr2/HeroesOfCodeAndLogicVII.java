package Final2020_04_04_gr2;

import java.util.*;

public class HeroesOfCodeAndLogicVII {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        final int HP = 100;
        final int MP = 200;

        Map<String, List<Integer>> heroes = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String heroName = tokens[0];
            int health = Integer.parseInt(tokens[1]);
            int mana = Integer.parseInt(tokens[2]);

            heroes.put(heroName, new ArrayList<>());
            heroes.get(heroName).add(health);
            heroes.get(heroName).add(mana);
        }

        String input = sc.nextLine();
        while (!"End".equals(input)) {
            String[] tokens = input.split(" - ");
            String action = tokens[0];
            String heroName = tokens[1];

            switch (action) {
                case "CastSpell":
                    int manaNeeded = Integer.parseInt(tokens[2]);
                    String spellName = tokens[3];
                    int manaLeft = heroes.get(heroName).get(1) - manaNeeded;
                    if (manaLeft >= 0) {
                        heroes.get(heroName).set(1, manaLeft);
                        System.out.println(String.format("%s has successfully cast %s and now has %d MP!",
                                heroName, spellName, manaLeft));
                    } else {
                        System.out.println(String.format("%s does not have enough MP to cast %s!", heroName, spellName));
                    }
                    break;
                case "TakeDamage":
                    int damage = Integer.parseInt(tokens[2]);
                    String attacker = tokens[3];
                    int healthLeft = heroes.get(heroName).get(0) - damage;
                    if (healthLeft > 0) {
                        heroes.get(heroName).set(0, healthLeft);
                        System.out.println(String.format("%s was hit for %d HP by %s and now has %d HP left!",
                                heroName, damage, attacker, healthLeft));
                    } else {
                        heroes.remove(heroName);
                        System.out.println(String.format("%s has been killed by %s!", heroName, attacker));
                    }
                    break;
                case "Recharge":
                    int manaAdd = Integer.parseInt(tokens[2]);
                    int newMana = heroes.get(heroName).get(1) + manaAdd;
                    if (newMana > MP) {
                        newMana = MP;
                        manaAdd = MP - heroes.get(heroName).get(1);
                    }
                    heroes.get(heroName).set(1, newMana);
                    System.out.println(String.format("%s recharged for %d MP!", heroName, manaAdd));
                    break;
                case "Heal":
                    int healthAdd = Integer.parseInt(tokens[2]);
                    int newHealth = heroes.get(heroName).get(0) + healthAdd;
                    if (newHealth > HP) {
                        newHealth = HP;
                        healthAdd = HP - heroes.get(heroName).get(0);
                    }
                    heroes.get(heroName).set(0, newHealth);
                    System.out.println(String.format("%s healed for %d HP!", heroName, healthAdd));
                    break;
            }

            input = sc.nextLine();
        }

        heroes.entrySet()
                .stream()
                .sorted((h1, h2) -> {
                    int result = h2.getValue().get(0).compareTo(h1.getValue().get(0));
                    if (result == 0) {
                        result = h1.getKey().compareTo(h2.getKey());
                    }
                    return result;
                })
                .forEach(e -> {
                    System.out.println(e.getKey());
                    System.out.println("HP: " + e.getValue().get(0));
                    System.out.println("MP: " + e.getValue().get(1));
                });
    }
}
