using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp4
{
    // 1 = O, 2 = X
    class Game_Board
    {
     
        // Game board represented by a 2D array
        public int[,] board;
        
        // Constructor initializes the game board with zeros
        public Game_Board()
        {
            board = new int[GameConfig.BoardWidth, GameConfig.BoardHeight];

            for (int i = 0; i < GameConfig.BoardWidth; i++)
            {
                for (int j = 0; j < GameConfig.BoardHeight; j++)
                {
                    board[i,j] = GameConfig.EmptyCell;
                }
            }
       
        }

        // Method to get the value at a specific position
        public int getValueInBoard(int i,int j)
        {
            return board[i, j];  
        }

        // Method to set the value at a specific position
        public void setValueInBoard(int i, int j, int value)
        {
            board[i, j] = value;
        }

        // Method to clear the game board (set all positions to 0)
        public void cleanBoardBoard()
        {
            for (int i = 0; i < GameConfig.BoardWidth; i++)
            {
                for (int j = 0; j < GameConfig.BoardHeight; j++)
                {
                    board[i, j] = GameConfig.EmptyCell;
                }
            }
        }

        // Method to count the number of filled positions on the board
        public int getOccupiedCount()
        {
            int countOccupied = 0;
            for (int i = 0; i < GameConfig.BoardWidth; i++)
            {
                for (int j = 0; j < GameConfig.BoardHeight; j++)
                {
                    if (board[i, j] != GameConfig.EmptyCell)
                        countOccupied++;
                }
            }
            return countOccupied;
        }

        // Method to check if there's a winner
        // Returns an array where arr[0] is the winner (1 or 2) and arr[1] is the winning condition number
        public int[] checkwin()
        {
            int[] arr = new int[2];
            arr[0] = 0;
            arr[1] = 0;


            // Check rows for a win
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == board[row, 1] && board[row, 2] == board[row, 0] && (board[row, 0] == 1 || board[row, 0] == 2))
                {
                    arr[0] = board[row, 0];
                    arr[1] = row + 1; // השורה מתווספת ב1 מכיוון שהמערך מתחיל מאינדקס 0
                    return arr;
                }
            }

            // Check columns for a win
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == board[1, col] && board[0, col] == board[2, col] && (board[0, col] == 1 || board[0, col] == 2))
                {
                    arr[0] = board[0, col];
                    arr[1] = col + 4; // העמודה מתווספת ב4 מכיוון שהמערך מתחיל מאינדקס 0 והשורות כבר עברנו בהם
                    return arr;
                }
            }

            // Check diagonals for a win
            // Check left diagonal for a win
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && (board[0, 0] == 1 || board[0, 0] == 2))
            {
                arr[0] = board[0, 0];
                arr[1] = 7;
                return arr;
            }

            // Check right diagonal for a win
            if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && (board[0, 2] == 1 || board[0, 2] == 2))
            {
                arr[0] = board[0, 2];
                arr[1] = 8;
                return arr;
            }

            // No winner found
            return arr;

        }
    }
}

/*
if (board[0, 0] == board[0, 1] && board[0, 2] == board[0, 0] && (board[0, 0] == 1 || board[0, 0] == 2))
{
    arr[0] = board[0, 0];
    arr[1] = 1;
    return arr;
}

// Check second row for a win
if (board[1, 0] == board[1, 1] && board[1, 2] == board[1, 0] && (board[1, 0] == 1 || board[1, 0] == 2))
{
    arr[0] = board[1, 0];
    arr[1] = 2;
    return arr;
}

// Check third row for a win
if (board[2, 0] == board[2, 1] && board[2, 2] == board[2, 0] && (board[2, 0] == 1 || board[2, 0] == 2))
{
    arr[0] = board[2, 0];
    arr[1] = 3;
    return arr;
}
*/



/*
// Check first column for a win
if (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] && (board[0, 0] == 1 || board[0, 0] == 2))
{
    arr[0] = board[0, 0];
    arr[1] = 4;
    return arr;
}

// Check second column for a win
if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && (board[0, 1] == 1 || board[0, 1] == 2))
{
    arr[0] = board[0, 1];
    arr[1] = 5;
    return arr;
}

// Check third column for a win
if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] && (board[0, 2] == 1 || board[0, 2] == 2))
{
    arr[0] = board[0, 2];
    arr[1] = 6;
    return arr;
}
*/



