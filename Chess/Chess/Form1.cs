﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        //board values
        static Point INIT = new Point(0, 0);
        static Point LIMINT = new Point(1024, 1024);
        static int BoardSquareLength = 128; //each square on the board is 128x128 pixels
        private GameBoard gameBoard = new GameBoard();
        static DateTime time;
        Player playerOne = Player.White; //white
        Player playerTwo = Player.Black; //black
        static int player1Lost = 0;
        static int player2Lost = 0;
        static int player1step = 0;
        static int player2step = 0;
        int player1points = 0;
        int player2points = 0;
        int x1 = -1; //this is horrible code, but its late, this is to hold the mouse input on where it clicked
        int y1 = -1;
        int x2 = -1;
        int y2 = -1;

        public Form1()
        {
            InitializeComponent();
            PreparePieces();
        }

        // setting up pieces' coordinate base on the gameboard coordnate
        private void PreparePieces()
        {
            //game board init
            gameBoard.Add(new Rook(playerOne), new Location(Rank.eight, File.a));
            gameBoard.Add(new Knight(playerOne), new Location(Rank.eight, File.b));
            gameBoard.Add(new Bishop(playerOne), new Location(Rank.eight, File.c));
            gameBoard.Add(new Queen(playerOne), new Location(Rank.eight, File.d));
            gameBoard.Add(new King(playerOne), new Location(Rank.eight, File.e));
            gameBoard.Add(new Bishop(playerOne), new Location(Rank.eight, File.f));
            gameBoard.Add(new Knight(playerOne), new Location(Rank.eight, File.g));
            gameBoard.Add(new Rook(playerOne), new Location(Rank.eight, File.h));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.a));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.b));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.c));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.d));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.e));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.f));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.g));
            gameBoard.Add(new Pawn(playerOne), new Location(Rank.seven, File.h));

            //player 2
            gameBoard.Add(new Rook(  playerTwo), new Location(Rank.one, File.a));
            gameBoard.Add(new Knight(playerTwo), new Location(Rank.one, File.b));
            gameBoard.Add(new Bishop(playerTwo), new Location(Rank.one, File.c));
            gameBoard.Add(new Queen( playerTwo), new Location(Rank.one, File.d));
            gameBoard.Add(new King(  playerTwo), new Location(Rank.one, File.e));
            gameBoard.Add(new Bishop(playerTwo), new Location(Rank.one, File.f));
            gameBoard.Add(new Knight(playerTwo), new Location(Rank.one, File.g));
            gameBoard.Add(new Rook(  playerTwo), new Location(Rank.one, File.h));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.a));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.b));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.c));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.d));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.e));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.f));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.g));
            gameBoard.Add(new Pawn(playerTwo), new Location(Rank.two, File.h));
        }

        //draw the board
        private void DrawBoard(Graphics g)
        {
            using (SolidBrush sb = new SolidBrush(Color.White))
            {
                foreach (var coord in gameBoard.GetSquares())
                {
                    int startY = (int)coord.Rank * BoardSquareLength;
                    int startX = (int)coord.File * BoardSquareLength;

                    Rectangle rt = new Rectangle(startX, startY, startX + BoardSquareLength, startY + BoardSquareLength);
                    g.FillRectangle(sb, rt); 
                    
                    if (sb.Color == Color.Black)
                        sb.Color = Color.White;
                    else
                        sb.Color = Color.Black;

                    if((int)coord.File == 7)
                        if (sb.Color == Color.Black)
                            sb.Color = Color.White;
                        else
                            sb.Color = Color.Black;

                    int offsetx = BoardSquareLength / 4;
                    int offsety = BoardSquareLength / 2;

                    if (coord.Piece is Rook)
                    {
                        if(coord.Piece.Player == Player.White)
                            g.DrawString("Rook", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Rook", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Knight)
                    {
                        if (coord.Piece.Player == Player.White)
                            g.DrawString("Knight", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Knight", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Bishop)
                    {
                        if (coord.Piece.Player == Player.White)
                            g.DrawString("Bishop", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Bishop", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is King)
                    {
                        if (coord.Piece.Player == Player.White)
                            g.DrawString("King", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("King", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Queen)
                    {
                        if (coord.Piece.Player == Player.White)
                            g.DrawString("Queen", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Queen", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Pawn)
                    {
                        if (coord.Piece.Player == Player.White)
                            g.DrawString("Pawn", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Pawn", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                    }
                }
            }
        }

        //Event to paint the board and set up the game
        private void Board_Paint(object sender, PaintEventArgs e)
        {
            //if (turn == Side.black)
            //{
            //    PlayerTurnLabel.ForeColor = Color.Red;
            //    PlayerTurnLabel.Text = "Red player's turn";
            //}
            //else
            //{
            //    PlayerTurnLabel.ForeColor = Color.Blue;
            //    PlayerTurnLabel.Text = "Blue player's turn";
            //}
            Graphics g = e.Graphics;
            //draw the game board and pieces
            DrawBoard(g);
        }

        //When you click the board it will be able to move pieces to that location
        private void Board_Click(object sender, MouseEventArgs e)
        {
            Graphics g = GameBoard.CreateGraphics();
            DrawHighlight(e.X, e.Y, g);
        }

        //draw a red highlight in square that is clicked
        private void DrawHighlight(int x, int y, Graphics g)
        {
            foreach (var coord in gameBoard.GetSquares())
            {
                int startX = (int)coord.File * BoardSquareLength;
                int startY = (int)coord.Rank * BoardSquareLength;

                if (x1 == -1)
                {
                    //Search through x the bounds to make sure its good
                    if (x >= startX && x <= startX + BoardSquareLength)
                    {
                        //Search through y the bounds to make sure its good
                        if (y >= startY && y <= startY + BoardSquareLength)
                        {
                            Pen redPen = new Pen(Color.Red, 1);
                            //draw the rectangle
                            g.DrawRectangle(redPen, startX, startY, BoardSquareLength - 1, BoardSquareLength - 1);

                            //save the cordinates to update next postion
                            x1 = (int)coord.File;
                            y1 = (int)coord.Rank;
                        }
                    }
                }
                else
                {
                    if (x2 == -1)
                    {
                        //Search through x the bounds to make sure its good
                        if (x >= startX && x <= startX + BoardSquareLength)
                        {
                            //Search through y the bounds to make sure its good
                            if (y >= startY && y <= startY + BoardSquareLength)
                            {
                                Pen GreenPen = new Pen(Color.Green, 1);
                                //draw the rectangle
                                g.DrawRectangle(GreenPen, startX, startY, BoardSquareLength - 1, BoardSquareLength - 1);

                                //save the cordinates to update next postion
                                x2 = (int)coord.File;
                                y2 = (int)coord.Rank;

                                if(x1 == x2 && y1 == y2)
                                {
                                    ErrorMessageBox.Text = "Please choose a move point that is different from the first.";
                                    x1 = -1;
                                    y1 = -1;
                                    x2 = -1;
                                    y2 = -1;
                                    GameBoard.Refresh();
                                    break;
                                }
                                else
                                {
                                    //call code to update postions
                                    ////////////////////////////////////UpdatePiecePosition(x1, y1, x2, y2);
                                    ///
                                    //also make sure to switch sides in here

                                    //reset the original points
                                    MessageBox.Show(x1 + " " + y1 + " " + x2 + " " + y2);
                                    x1 = -1;
                                    y1 = -1;
                                    x2 = -1;
                                    y2 = -1;
                                    //refresh the gameboard
                                    GameBoard.Refresh();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        // refreshing the game board while the use maximized the window
        private void Form1_Resize(object sender, EventArgs e)
        {
            GameBoard.Refresh();
        }

        private void SurrenderButton_Click(object sender, EventArgs e)
        {
            Winner();
        }

        private void Winner()
        {
            //whoever has the most pieces wins
            if(player1points > player2points)
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "Blue Player Wins!!!";
            }
            else if(player2points > player1points)
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "Red Player Wins!!!";
            }
            else
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "It was a tie!!!";
            }
            ResetButton.Visible = true;

            ErrorMessageBox.Text = "Red player lost " + player1Lost.ToString() + " pieces; Move " + player1step.ToString() + " steps\n" +
                            "Blue player lost " + player2Lost.ToString() + " pieces; Move " + player2step.ToString() + " steps\n" +
                            "Total time spended: " + (DateTime.Now - time).Hours.ToString() + " house, " + (DateTime.Now - time).Minutes.ToString() + " minutes, " +
                           (DateTime.Now - time).Seconds.ToString() + " seconds, " + (DateTime.Now - time).Milliseconds.ToString() + " milliseconds, ";

            player1Lost = 0;
            player2Lost = 0;
            player1step = 0;
            player2step = 0;
            GameBoard.Refresh();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //reset the labels
            WinnerLabel.Visible = false;
            ResetButton.Visible = false;

            //reset the gameboard
            ErrorMessageBox.Clear();
            GameBoard.Refresh();
        }
    }
}
