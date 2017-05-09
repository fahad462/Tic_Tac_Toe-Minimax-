using System;
using System.Windows.Forms;



/*

A simple Tic Tac Toe Game based on MiniMax Theorem
Author : Fahad

In single player or versus computer mode you have less than 1% chance to win

Have doubts Be my guest try it and good luck with that


*/


namespace Tic_Tac_Toe
{
    public partial class Tic_tac_toe : Form
    {
        private class Moves
        {
            public int row;
            public int column;
            public Moves (int a,int b)
            {
                row = a;
                column = b;
            }
        }

        private bool flag = true;
        private bool [,] checker = new bool[3 , 3];
        private int[,] who = new int[3, 3];
        private bool gameMode;
        private char[,] board = new char[3, 3]; 
        char first = 'X', computer = 'O';

        private bool isMovesLeft (char[,]  table )
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (table[i, j] == '_')
                        return true;
            return false;
        }

        private int evaluate (char [,] table)
        {
            for (int i=0;i<3;i++)
            {
                if (table[i,0]==table[i,1] && 
                    table[i,1]==table[i,2])
                {
                    if (table[i, 0] == first)
                        return 10;
                    else if (table[i, 0] == computer)
                        return -10;
                }
            }

            for (int j=0;j<3;j++)
            {
                if (table[0,j]==table[1,j] &&
                    table[1,j]==table[2,j])
                {
                    if (table[0, j] == first)
                        return 10;
                    else if (table[0, j] == computer)
                        return -10;
                }
            }

            if (table[0,0]==table[1,1] && table[1,1]==table[2,2])
            {
                if (table[0, 0] == first)
                {
                    return 10;
                }
                else if (table[0, 0] == computer)
                    return -10;
            }

            if (table[0, 2] == table[1, 1] && table[1, 1] == table[2, 0])
            {
                if (table[0, 2] == first)
                {
                    return 10;
                }
                else if (table[0, 2] == computer)
                    return -10;
            }

            return 0;
        }

        public int max (int a,int b)
        {
            if (a > b) return a; else  return b;
        }

        public int min (int a,int b)
        {
            if (a < b) return a; else return b;
        }

        private int minimax (char[,] table,int depth , bool ismax)
        {
            int res = evaluate(table);

            if (res == 10)
                return 10;
            if (res == -10)
                return -10;
            if (isMovesLeft(table) == false)
                return 0;

            if (ismax)
            {
                int best = -1000;

                for (int i=0;i<3;i++)
                    for (int j=0;j<3;j++)
                        if (table[i,j]=='_')
                        {
                            table[i,j] = first;
                            best = max(best, minimax(table, depth + 1, !ismax));
                            table[i, j] = '_';
                        }
                return best;
            }

            else
            {
                int best = 1000;

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (table[i, j] == '_')
                        {
                            table[i, j] = computer;
                            best = min(best, minimax(table, depth + 1, !ismax));
                            table[i, j] = '_';
                        }
                return best;
            }
        }

        private Moves findbestmove (char[,] table)
        {
            int bests = -10000;
            Moves best = new Moves(-1, -1);
            for (int i=0;i<3;i++)
                for (int j=0;j<3;j++)
                {
                    if (table[i,j] == '_')
                    {
                        table[i, j] = first;
                        int temp = minimax(table, 0, false);
                        table[i, j] = '_';
                        if (temp>bests)
                        {
                            best.row = i;
                            best.column = j;
                            bests = temp;
                        }
                    }
                }
            return best;
        }

        public Tic_tac_toe()
        {
            InitializeComponent();
        }
        private bool Nes_checker ()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (!checker[i, j])
                        return false;
            return true;
        }
        private void Reset ()
        {
            Choose.Enabled = true;
            start.Enabled = false;
            r1c1.Enabled = false;
            r1c2.Enabled = false;
            r1c3.Enabled = false;

            r2c1.Enabled = false;
            r2c2.Enabled = false;
            r2c3.Enabled = false;

            r3c1.Enabled = false;
            r3c2.Enabled = false;
            r3c3.Enabled = false;

            r1c1.Text = "";
            r1c2.Text = "";
            r1c3.Text = "";

            r2c1.Text = "";
            r2c2.Text = "";
            r2c3.Text = "";

            r3c1.Text = "";
            r3c2.Text = "";
            r3c3.Text = "";
            for (int i = 0; i < 3; i++)
                 for (int j = 0; j < 3; j++)
                  {
                      checker[i, j] = false;
                      who[i, j] = 0;
                 }
            move.Text = "Reseted: Initialize Game Mode And Press Start";
        }
        private int WinsC()
        {
            if (board[0, 0] == 'X' && board[1, 0] == 'X' && board[2, 0] == 'X')
                return 1;
            else if (board[0, 1] == 'X' && board[1, 1] == 'X' && board[2, 1] == 'X')
                return 1;
            else if (board[0, 2] == 'X' && board[1, 2] == 'X' && board[2, 2] == 'X')
                return 1;
            else if (board[0, 0] == 'X' && board[0, 1] == 'X' && board[0, 2] == 'X')
                return 1;
            else if (board[1, 0] == 'X' && board[1, 1] == 'X' && board[1, 2] == 'X')
                return 1;
            else if (board[2, 0] == 'X' && board[2, 1] == 'X' && board[2, 2] == 'X')
                return 1;
            else if (board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X')
                return 1;
            else if (board[0, 2] == 'X' && board[1, 1] == 'X' && board[2, 0] == 'X')
                return 1;


            else if (board[0, 0] == 'O' && board[1, 0] == 'O' && board[2, 0] == 'O')
                return 2;
            else if (board[0, 1] == 'O' && board[1, 1] == 'O' && board[2, 1] == 'O')
                return 2;
            else if (board[0, 2] == 'O' && board[1, 2] == 'O' && board[2, 2] == 'O')
                return 2;
            else if (board[0, 0] == 'O' && board[0, 1] == 'O' && board[0, 2] == 'O')
                return 2;
            else if (board[1, 0] == 'O' && board[1, 1] == 'O' && board[1, 2] == 'O')
                return 2;
            else if (board[2, 0] == 'O' && board[2, 1] == 'O' && board[2, 2] == 'O')
                return 2;
            else if (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O')
                return 2;
            else if (board[0, 2] == 'O' && board[1, 1] == 'O' && board[2, 0] == 'O')
                return 2;
            return 0;
        }
        private int Wins ()
        {
            if (who[0, 0] == 1 && who[1, 0] == 1 && who[2, 0] == 1)
                return 1;
            else if (who[0,1] == 1 && who[1,1] == 1 && who[2,1] == 1)
                return 1;
            else if (who[0, 2] == 1 && who[1, 2] == 1 && who[2, 2] == 1)
                return 1;
            else if (who[0, 0] == 1 && who[0, 1] == 1 && who[0, 2] == 1)
                return 1;
            else if (who[1, 0] == 1 && who[1, 1] == 1 && who[1, 2] == 1)
                return 1;
            else if (who[2, 0] == 1 && who[2, 1] == 1 && who[2, 2] == 1)
                return 1;
            else if (who[0, 0] == 1 && who[1, 1] == 1 && who[2, 2] == 1)
                return 1;
            else if (who[0, 2] == 1 && who[1, 1] == 1 && who[2, 0] == 1)
                return 1;


            else if (who[0, 0] == 2 && who[1, 0] == 2 && who[2, 0] == 2)
                return 2;
            else if (who[0, 1] == 2 && who[1, 1] == 2 && who[2, 1] == 2)
                return 2;
            else if (who[0, 2] == 2 && who[1, 2] == 2 && who[2, 2] == 2)
                return 2;
            else if (who[0, 0] == 2 && who[0, 1] == 2 && who[0, 2] == 2)
                return 2;
            else if (who[1, 0] == 2 && who[1, 1] == 2 && who[1, 2] == 2)
                return 2;
            else if (who[2, 0] == 2 && who[2, 1] == 2 && who[2, 2] == 2)
                return 2;
            else if (who[0, 0] == 2 && who[1, 1] == 2 && who[2, 2] == 2)
                return 2;
            else if (who[0, 2] == 2 && who[1, 1] == 2 && who[2, 0] == 2)
                return 2;
            return 0;
        }
        private void Set (int i = 0)
        {
            //reset.Enabled = false;
            r1c1.Enabled = false;
            r1c2.Enabled = false;
            r1c3.Enabled = false;

            r2c1.Enabled = false;
            r2c2.Enabled = false;
            r2c3.Enabled = false;

            r3c1.Enabled = false;
            r3c2.Enabled = false;
            r3c3.Enabled = false;
            move.Text = "Game over";
            if (i!=0)
            {
                move.Text = "Player " + i + " Wins";
                start.Text = "Restart";
            }
            else
            {
                move.Text = "Game Over" +  " Draw";
                start.Text = "Restart";
            }
        }

        private void Setc (int i=0)
        {
            //reset.Enabled = false;
            r1c1.Enabled = false;
            r1c2.Enabled = false;
            r1c3.Enabled = false;

            r2c1.Enabled = false;
            r2c2.Enabled = false;
            r2c3.Enabled = false;

            r3c1.Enabled = false;
            r3c2.Enabled = false;
            r3c3.Enabled = false;
            move.Text = "Game over";
            if (i == 1)
            {
                move.Text = "Computer Wins";
                start.Text = "Restart";
            }
            else if (i == 2)
            {
                move.Text = "You Wins! Impossible 8( well Congratulations";
                start.Text = "Restart";
            }
            else
            {
                move.Text = "Game Over" + " Draw";
                start.Text = "Restart";
            }
            for (int ii = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    board[ii, j] = '_';
                    checker[ii, j] = false;
                }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                reset.Enabled = true;

                r1c1.Enabled = true;
                r1c2.Enabled = true;
                r1c3.Enabled = true;

                r2c1.Enabled = true;
                r2c2.Enabled = true;
                r2c3.Enabled = true;

                r3c1.Enabled = true;
                r3c2.Enabled = true;
                r3c3.Enabled = true;

                r1c1.Text = "";
                r1c2.Text = "";
                r1c3.Text = "";

                r2c1.Text = "";
                r2c2.Text = "";
                r2c3.Text = "";

                r3c1.Text = "";
                r3c2.Text = "";
                r3c3.Text = "";
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        checker[i, j] = false;
                        who[i, j] = 0;
                    }
                move.Text = "Player 1 Please Give Input";
                flag = false;
            }
            else if (gameMode == false)
            {
                move.Text = "Game Started : Player 1 Please Give Input";
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = '_';
                        checker[i, j] = false;
                    }
                reset.Enabled = true;

                r1c1.Enabled = true;
                r1c2.Enabled = true;
                r1c3.Enabled = true;

                r2c1.Enabled = true;
                r2c2.Enabled = true;
                r2c3.Enabled = true;

                r3c1.Enabled = true;
                r3c2.Enabled = true;
                r3c3.Enabled = true;
                r1c1.Text = "";
                r1c2.Text = "";
                r1c3.Text = "";

                r2c1.Text = "";
                r2c2.Text = "";
                r2c3.Text = "";

                r3c1.Text = "";
                r3c2.Text = "";
                r3c3.Text = "";
                flag = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r1c2.Text = "X";
                    move.Text = "Player 2 please Give input";
                    who[0, 1] = 1;
                    flag = true;
                    checker[0, 1] = true;
                    r1c2.Enabled = false;
                }
                else if (flag == true)
                {
                    r1c2.Text = "O";
                    move.Text = "Player 1 please Give input";
                    who[0, 1] = 2;
                    flag = false;
                    checker[0, 1] = true;
                    r1c2.Enabled = false;
                }
                if (Wins() == 1)
                {
                    Set(1);
                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r1c2.Text = "X";
                r1c2.Enabled = false;
                checker[0, 1] = true;
                board[0, 1] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Reset();
        }

        void setter (int i,int j)
        {
            if (i==0 && j==0)
            {
                r1c1.Text = "O";
                r1c1.Enabled = false;
                checker[0, 0] = true;
                board[0, 0] = 'X';
                move.Text = "Again Your Turn :P";
            }
            if (i==0 && j==1)
            {
                r1c2.Text = "O";
                r1c2.Enabled = false;
                checker[0, 1] = true;
                board[0, 1] = 'X';
                move.Text = "Again Your Turn :P";
            }
            if (i==0 && j==2)
            {
                r1c3.Text = "O";
                r1c3.Enabled = false;
                checker[0, 2] = true;
                board[0, 2] = 'X';
                move.Text = "Again Your Turn :P";
            }

            if (i == 1 && j == 0)
            {
                r2c1.Text = "O";
                r2c1.Enabled = false;
                checker[1, 0] = true;
                board[1, 0] = 'X';
                move.Text = "Again Your Turn :P";
            }
            if (i == 1 && j == 1)
            {
                r2c2.Text = "O";
                r2c2.Enabled = false;
                checker[1, 1] = true;
                board[1, 1] = 'X';
                move.Text = "Again Your Turn :P";
            }
            if (i == 1 && j == 2)
            {
                r2c3.Text = "O";
                r2c3.Enabled = false;
                checker[1, 2] = true;
                board[1, 2] = 'X';
                move.Text = "Again Your Turn :P";
            }

            if (i == 2 && j == 0)
            {
                r3c1.Text = "O";
                r3c1.Enabled = false;
                checker[2, 0] = true;
                board[2, 0] = 'X';
                move.Text = "Again Your Turn :P";
            }
            if (i == 2 && j == 1)
            {
                r3c2.Text = "O";
                r3c2.Enabled = false;
                checker[2, 1] = true;
                board[2, 1] = 'X';
                move.Text = "Again Your Turn :P";
            }
            if (i == 2 && j == 2)
            {
                r3c3.Text = "O";
                r3c3.Enabled = false;
                checker[2, 2] = true;
                board[2, 2] = 'X';
                move.Text = "Again Your Turn :P";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r1c1.Text = "X";
                    r1c1.Enabled = false;
                    checker[0, 0] = true;
                    move.Text = "Player 2 please Give input";
                    who[0, 0] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r1c1.Text = "O";
                    r1c1.Enabled = false;
                    checker[0, 0] = true;
                    move.Text = "Player 1 please Give input";
                    who[0, 0] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);

                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r1c1.Text = "X";
                r1c1.Enabled = false;
                checker[0, 0] = true;
                board[0, 0] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove (board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC()==1)
                {
                    Setc(1);
                }
                if (WinsC ()==2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r1c3.Text = "X";
                    r1c3.Enabled = false;
                    checker[0, 2] = true;
                    move.Text = "Player 2 please Give input";
                    who[0, 2] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r1c3.Text = "O";
                    r1c3.Enabled = false;
                    checker[0, 2] = true;
                    move.Text = "Player 1 please Give input";
                    who[0, 2] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);

                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r1c3.Text = "X";
                r1c3.Enabled = false;
                checker[0, 2] = true;
                board[0, 2] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r2c1.Text = "X";
                    r2c1.Enabled = false;
                    checker[1, 0] = true;
                    move.Text = "Player 2 please Give input";
                    who[1, 0] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r2c1.Text = "O";
                    r2c1.Enabled = false;
                    checker[1, 0] = true;
                    move.Text = "Player 1 please Give input";
                    who[1, 0] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);
                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r2c1.Text = "X";
                r2c1.Enabled = false;
                checker[1, 0] = true;
                board[1, 0] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r2c2.Text = "X";
                    r2c2.Enabled = false;
                    checker[1, 1] = true;
                    move.Text = "Player 2 please Give input";
                    who[1, 1] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r2c2.Text = "O";
                    r2c2.Enabled = false;
                    checker[1, 1] = true;
                    move.Text = "Player 1 please Give input";
                    who[1, 1] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);

                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r2c2.Text = "X";
                r2c2.Enabled = false;
                checker[1, 1] = true;
                board[1, 1] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r2c3.Text = "X";
                    r2c3.Enabled = false;
                    checker[1, 2] = true;
                    move.Text = "Player 2 please Give input";
                    who[1, 2] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r2c3.Text = "O";
                    r2c3.Enabled = false;
                    checker[1, 2] = true;
                    move.Text = "Player 1 please Give input";
                    who[1, 2] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);
                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r2c3.Text = "X";
                r2c3.Enabled = false;
                checker[1, 2] = true;
                board[1, 2] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r3c1.Text = "X";
                    r3c1.Enabled = false;
                    checker[2, 0] = true;
                    move.Text = "Player 2 please Give input";
                    who[2, 0] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r3c1.Text = "O";
                    r3c1.Enabled = false;
                    checker[2, 0] = true;
                    move.Text = "Player 1 please Give input";
                    who[2, 0] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);

                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r3c1.Text = "X";
                r3c1.Enabled = false;
                checker[2, 0] = true;
                board[2, 0] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r3c2.Text = "X";
                    r3c2.Enabled = false;
                    checker[2, 1] = true;
                    move.Text = "Player 2 please Give input";
                    who[2, 1] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r3c2.Text = "O";
                    r3c2.Enabled = false;
                    checker[2, 1] = true;
                    move.Text = "Player 1 please Give input";
                    who[2, 1] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);

                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r3c2.Text = "X";
                r3c2.Enabled = false;
                checker[2, 1] = true;
                board[2, 1] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (gameMode == true)
            {
                if (flag == false)
                {
                    r3c3.Text = "X";
                    r3c3.Enabled = false;
                    checker[2, 2] = true;
                    move.Text = "Player 2 please Give input";
                    who[2, 2] = 1;
                    flag = true;
                }
                else if (flag == true)
                {
                    r3c3.Text = "O";
                    r3c3.Enabled = false;
                    checker[2, 2] = true;
                    move.Text = "Player 1 please Give input";
                    who[2, 2] = 2;
                    flag = false;
                }
                if (Wins() == 1)
                {
                    Set(1);

                }
                else if (Wins() == 2)
                {
                    Set(2);
                }
                else if (Nes_checker())
                {
                    Set();
                }
            }
            else
            {
                r3c3.Text = "X";
                r3c3.Enabled = false;
                checker[2, 2] = true;
                board[2, 2] = 'O';
                int i = 0;
                while (i < 3)
                {
                    move.Text = "Computer is Thinking :P";
                    i++;
                }
                Moves temp = findbestmove(board);
                i = temp.row;
                int j = temp.column;

                setter(i, j);
                if (WinsC() == 1)
                {
                    Setc(1);
                }
                if (WinsC() == 2)
                {
                    Setc(2);
                }
                if (Nes_checker())
                {
                    Setc();
                }
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void author_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = "A simple Tic Tac Toe Game based on MiniMax Theorem\n\nAuthor: Fahad\n\t\n\nIn single player or versus computer mode you have less than 1 % chance to win\n\nHave doubts Be my guest try it and good luck with that";
            MessageBox.Show(temp,"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fahad.web we = new Fahad.web();
            we.Show();
        }

        private void Choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choose.Text == "2-Player")
            {
                gameMode = true;
                start.Enabled = true;
            }
            else
            {
                gameMode = false;
                start.Enabled = true;
            }
            Choose.Enabled = true;
        }
    }
}
