using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace tictactoe
{
    public class GameLogic
    {
        public string CurrentPlayer { get; private set; }
        public string TextBox11 { get; set; }
        public string TextBox12 { get; set; }
        public string TextBox13 { get; set; }

        public string TextBox21 { get; set; }
        public string TextBox22 { get; set; }
        public string TextBox23 { get; set; }

        public string TextBox31 { get; set; }
        public string TextBox32 { get; set; }
        public string TextBox33 { get; set; }

        public GameLogic(string textBox11, string textBox12, string textBox13,
            string textBox21, string textBox22, string textBox23,
            string textBox31, string textBox32, string textBox33)
        {
            Random random = new Random();
            int move = random.Next(1, 3);
            if(move == 1) CurrentPlayer = "X";
            else CurrentPlayer = "O";
            TextBox11 = textBox11;
            TextBox12 = textBox12;
            TextBox13 = textBox13;
            TextBox21 = textBox21;
            TextBox22 = textBox22;
            TextBox23 = textBox23;
            TextBox31 = textBox31;
            TextBox32 = textBox32;
            TextBox33 = textBox33;
        }

        public void UpdateValues(string textBox11, string textBox12, string textBox13,
            string textBox21, string textBox22, string textBox23,
            string textBox31, string textBox32, string textBox33)
        {
            TextBox11 = textBox11;
            TextBox12 = textBox12;
            TextBox13 = textBox13;
            TextBox21 = textBox21;
            TextBox22 = textBox22;
            TextBox23 = textBox23;
            TextBox31 = textBox31;
            TextBox32 = textBox32;
            TextBox33 = textBox33;
        }
        public string NextPlayer()
        {
            CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
            return CurrentPlayer;
        }

        public string ShowWinners(string winners)
        {
            string player;
            if (winners == "X") player = "X";
            if (winners == "O") player = "O";
            else player = "Draw";
            return player;
        }

        public string CheckWinners()
        {
            string player = " ";

            string[,] board = new string[,]
            {
                {TextBox11,TextBox12, TextBox13},
                {TextBox21,TextBox22, TextBox23},
                {TextBox31,TextBox32, TextBox33}
            };


                for (int row = 0; row < 3; row++)
                {
                    if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2] && !string.IsNullOrEmpty(board[row, 0]))
                    {
                        if (board[row, 0] == "X") player = "X";
                        else player = "O";
                    }
                }

                for (int column = 0; column < 3; column++)
                {
                    if (board[0, column] == board[1, column] && board[1, column] == board[2, column] && !string.IsNullOrEmpty(board[0, column]))
                    {
                        if (board[0, column] == "X") player = "X";
                        else player = "O";
                    }
                }

                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && !string.IsNullOrEmpty(board[0, 0]))
                {
                    if (board[0, 0] == "X") player = "X";
                    else player = "O";
                }

                if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && !string.IsNullOrEmpty(board[0, 2]))
                {
                    if (board[0, 2] == "X") player = "X";
                    else player = "O";
                }
            
            return player;
        }


    }
}
