package n_IteratorsAndComparators_Exercises.froggy;

import java.util.Iterator;

public class Lake implements Iterable<Integer> {
    private int[] stones;

    public Lake(int[] stones) {
        this.stones = stones;
    }

    @Override
    public Iterator<Integer> iterator() {
        return new Iterator<Integer>() {
            private int index;

            @Override
            public boolean hasNext() {
                return index < stones.length;
            }

            @Override
            public Integer next() {
                int element = stones[index];

                if (stones.length % 2 == 0 && index == stones.length - 2) {
                    index = -1;
                }
                if (stones.length % 2 != 0 && index == stones.length - 1) {
                    index = -1;
                }

                index += 2;
                return element;
            }
        };
    }
}
