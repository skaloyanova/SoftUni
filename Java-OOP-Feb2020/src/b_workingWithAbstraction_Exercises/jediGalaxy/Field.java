package b_workingWithAbstraction_Exercises.jediGalaxy;

public class Field {
    private int[][] matrix;

    public Field(int row, int col, int value) {
        this.matrix = new int[row][col];
        createField(value);
    }

    private void createField(int value) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                this.matrix[i][j] = value++;
            }
        }
    }

    public boolean isValidPosition(int row, int col) {
        return row >= 0 && row < this.matrix.length && col >= 0 && col < this.matrix[row].length;
    }

    public void setValue(int row, int col, int value) {
        this.matrix[row][col] = value;
    }

    public int getValue(int row, int col) {
        return this.matrix[row][col];
    }

    public int getRows() {
        return matrix.length;
    }

    public int getCols() {
        return matrix[0].length;
    }

}
