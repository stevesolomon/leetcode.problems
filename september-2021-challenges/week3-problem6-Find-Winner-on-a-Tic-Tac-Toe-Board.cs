// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3981/

public class Solution {
    
    private const char A = 'X';
    private const char B = 'O';
    
    public string Tictactoe(int[][] moves) {
        char[,] board = new char[3,3];
        char player = A;
        
        for (int i = 0; i < moves.Length; i++) {
            board[moves[i][0],moves[i][1]] = player;
            
            player = player == A ? B : A;
        }
        
        // Scan for a winning move across rows and columns.
        for (int row = 0; row < 3; row++) {
            int numARow = 0;
            int numBRow = 0;
            int numACol = 0;
            int numBCol = 0;
            for (int col = 0; col < 3; col++) {
                if (board[row,col] == A) {
                    numARow++;
                } else if (board[row,col] == B) {
                    numBRow++;
                }
                
                if (board[col,row] == A) {
                    numACol++;
                } else if (board[col,row] == B) {
                    numBCol++;
                }
            }
            
            if (numARow == 3) {
                return "A";
            } else if (numBRow == 3) {
                return "B";
            } else if (numACol == 3) {
                return "A";
            } else if (numBCol == 3) {
                return "B";
            }
        }
        
        if ((board[0,0] == A && board[1,1] == A && board[2,2] == A) ||
             board[0,2] == A && board[1,1] == A && board[2,0] == A) {
            return "A";
        }
        
        if ((board[0,0] == B && board[1,1] == B && board[2,2] == B) ||
             board[0,2] == B && board[1,1] == B && board[2,0] == B) {
            return "B";
        }
        
        return moves.Length == 9 ? "Draw" : "Pending";
    }
}