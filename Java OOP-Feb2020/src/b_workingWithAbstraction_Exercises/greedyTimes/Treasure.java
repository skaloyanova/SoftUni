package b_workingWithAbstraction_Exercises.greedyTimes;

import java.util.Iterator;

public class Treasure implements Iterable<Treasure.Pair<String, Long>> {

    public static class Pair<K, V> {
        private K first;
        private V second;

        public Pair(K first, V second) {
            this.first = first;
            this.second = second;
        }

        public K getFirst() {
            return first;
        }

        public V getSecond() {
            return second;
        }
    }

    private String[] goods;

    public Treasure(String[] goods) {
        this.goods = goods;
    }

    @Override
    public Iterator<Treasure.Pair<String, Long>> iterator() {
        return new Iterator<>() {

            private int index;

            @Override
            public boolean hasNext() {
                return index < goods.length - 1;
            }

            @Override
            public Treasure.Pair<String, Long> next() {
                String item = goods[index++];
                Long value = Long.parseLong(goods[index++]);
                return new Pair<>(item, value);
            }
        };
    }

}
