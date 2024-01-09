package b_workingWithAbstraction_Exercises.jediGalaxy;

public class Galaxy {
    private Field galaxy;

    public Galaxy(int row, int col, int value) {
        this.galaxy = new Field(row, col, value);
    }

    public void destroyStars(int row, int col) {
        while (row >= 0 && col >= 0) {
            if (galaxy.isValidPosition(row, col)) {
                galaxy.setValue(row, col, 0);
            }
            row--;
            col--;
        }
    }

    public long collectStars(int row, int col) {
        long starsCollected = 0;
        while (row >= 0 && col < galaxy.getCols()) {
            if (galaxy.isValidPosition(row, col)) {
                starsCollected += galaxy.getValue(row, col);
            }

            col++;
            row--;
        }
        return starsCollected;
    }


}
