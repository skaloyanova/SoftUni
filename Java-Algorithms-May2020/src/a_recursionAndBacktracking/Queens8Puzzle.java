package a_recursionAndBacktracking;

public class Queens8Puzzle {
    static final int CHESS_SIZE = 8;
    static char[][] chessBoard = new char[CHESS_SIZE][CHESS_SIZE];

    public static void main(String[] args) {
        for (int i = 0; i < CHESS_SIZE; i++) {
            for (int j = 0; j < CHESS_SIZE; j++) {
                chessBoard[i][j] = '-';
            }
        }

        findQueenPosition(0);
    }

    private static void findQueenPosition(int row) {
        if (row == 8) {
            print(chessBoard);
        } else {
            for (int col = 0; col < CHESS_SIZE; col++) {
                if (canPlaceQueen(row, col)) {
                    setQueen(row, col);
                    findQueenPosition(row + 1);
                    unsetQueen(row, col);
                }
            }
        }
    }

    private static boolean canPlaceQueen(int row, int col) {
        int colLeftDiagonal = col - 1;
        int colRightDiagonal = col + 1;

        for (int r = row - 1; r >= 0; r--) {
            if (chessBoard[r][col] == '*') {
                return false;
            }
            if (isValidColumn(colLeftDiagonal) && chessBoard[r][colLeftDiagonal] == '*') {
                return false;
            }
            if (isValidColumn(colRightDiagonal) && chessBoard[r][colRightDiagonal] == '*') {
                return false;
            }
            colLeftDiagonal--;
            colRightDiagonal++;
        }
        return true;
    }

    private static boolean isValidColumn(int col) {
        return col >= 0 && col < CHESS_SIZE;
    }

    private static void setQueen(int row, int col) {
        chessBoard[row][col] = '*';
    }

    private static void unsetQueen(int row, int col) {
        chessBoard[row][col] = '-';
    }

    private static void print(char[][] chessBoard) {
        for (char[] chars : chessBoard) {
            for (char aChar : chars) {
                System.out.print(aChar + " ");
            }
            System.out.println();
        }
        System.out.println();
    }
}
