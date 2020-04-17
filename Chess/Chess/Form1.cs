/*
 * Name: Joseph Meyer; zid: z1788150
 * Partner: Huajian Huang; zid: z1869893
 * 
 * CSCI 473 - Assignment 5
 * Function: This program is to emulate the 3D Chess board game in 2D! Sure we loose a dimesnion, but you can play it anywhere!
 * 
 */
using System;
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
        Player playerOne = new Player(PlayerColor.White); //white or blue
        Player playerTwo = new Player(PlayerColor.Black); //black or red
        Player Turn = null;
        int player1step = 0;
        int player2step = 0;
        int x1 = -1; //mouse movment globals
        int y1 = -1;
        int x2 = -1;
        int y2 = -1;

        public Form1()
        {
            InitializeComponent();
            Turn = playerOne; //first turn goes to white player or blue
            PreparePieces();
            playerOne.Start();
        }

        // setting up pieces' coordinate base on the gameboard coordnate
        private void PreparePieces()
        {
            //game board init
            gameBoard.Add(new Rook  (playerTwo), new Location  (File.a, Rank.eight));
            gameBoard.Add(new Knight(playerTwo), new Location(File.b, Rank.eight));
            gameBoard.Add(new Bishop(playerTwo), new Location(File.c, Rank.eight));
            gameBoard.Add(new King  (playerTwo), new Location  (File.d, Rank.eight));
            gameBoard.Add(new Queen (playerTwo), new Location(File.e, Rank.eight));
            gameBoard.Add(new Bishop(playerTwo), new Location(File.f, Rank.eight));
            gameBoard.Add(new Knight(playerTwo), new Location(File.g, Rank.eight));
            gameBoard.Add(new Rook(playerTwo), new Location  (File.h, Rank.eight));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.a, Rank.seven));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.b, Rank.seven));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.c, Rank.seven));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.d, Rank.seven));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.e, Rank.seven));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.f, Rank.seven));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.g, Rank.seven));
            gameBoard.Add(new Pawn(playerTwo), new Location  (File.h, Rank.seven));

            //player 2
            gameBoard.Add(new Rook(  playerOne), new Location(File.a, Rank.one));
            gameBoard.Add(new Knight(playerOne), new Location(File.b, Rank.one));
            gameBoard.Add(new Bishop(playerOne), new Location(File.c, Rank.one));
            gameBoard.Add(new Queen( playerOne), new Location(File.d, Rank.one));
            gameBoard.Add(new King(  playerOne), new Location(File.e, Rank.one));
            gameBoard.Add(new Bishop(playerOne), new Location(File.f, Rank.one));
            gameBoard.Add(new Knight(playerOne), new Location(File.g, Rank.one));
            gameBoard.Add(new Rook(  playerOne), new Location(File.h, Rank.one));
            gameBoard.Add(new Pawn(playerOne), new Location(File.a, Rank.two));
            gameBoard.Add(new Pawn(playerOne), new Location(File.b, Rank.two));
            gameBoard.Add(new Pawn(playerOne), new Location(File.c, Rank.two));
            gameBoard.Add(new Pawn(playerOne), new Location(File.d, Rank.two));
            gameBoard.Add(new Pawn(playerOne), new Location(File.e, Rank.two));
            gameBoard.Add(new Pawn(playerOne), new Location(File.f, Rank.two));
            gameBoard.Add(new Pawn(playerOne), new Location(File.g, Rank.two));
            gameBoard.Add(new Pawn(playerOne), new Location(File.h, Rank.two));
        }

        //draw the board
        private void DrawBoard(Graphics g)
        {
            using (SolidBrush sb = new SolidBrush(Color.White))
            {
                foreach (var coord in gameBoard.GetSquares())
                {
                    int startX = (int)coord.File * BoardSquareLength;
                    int startY = (int)coord.Rank * BoardSquareLength;

                    Rectangle rt = new Rectangle(startX, startY, startX + BoardSquareLength, startY + BoardSquareLength);
                    g.FillRectangle(sb, rt); 
                    
                    if (sb.Color == Color.Black)
                        sb.Color = Color.White;
                    else
                        sb.Color = Color.Black;

                    if((int)coord.Rank == 7)
                        if (sb.Color == Color.Black)
                            sb.Color = Color.White;
                        else
                            sb.Color = Color.Black;

                    int offsetx = BoardSquareLength / 4;
                    int offsety = BoardSquareLength / 2;

                    if (coord.Piece is Rook)
                    {
                        if(coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawString("Rook", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Rook", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Knight)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawString("Knight", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Knight", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Bishop)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawString("Bishop", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Bishop", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is King)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawString("King", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("King", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Queen)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawString("Queen", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Queen", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                    }
                    else if (coord.Piece is Pawn)
                    {
                        if (coord.Piece.Player.Color == PlayerColor.White)
                            g.DrawString("Pawn", this.Font, Brushes.Blue, new Point(startX + offsetx, startY + offsety));
                        else
                            g.DrawString("Pawn", this.Font, Brushes.Red, new Point(startX + offsetx, startY + offsety));
                    }
                }
            }
        }

        //Event to paint the board and set up the game
        private void Board_Paint(object sender, PaintEventArgs e)
        {
            //change the player who is going
            if (Turn == playerOne)
            {
                PlayerTurnLabel.Text = "Blue Players turn.";
                PlayerTurnLabel.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                PlayerTurnLabel.Text = "Red Players Turn";
                PlayerTurnLabel.ForeColor = System.Drawing.Color.Red;
            }

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
                                Location from = new Location((File)x1, (Rank)y1);

                                if(x1 == x2 && y1 == y2)
                                {
                                    ErrorMessageBox.Text = "Please choose a move point that is different from the first.";
                                    x1 = y1 = x2 = y2 = -1;
                                    GameBoard.Refresh();
                                    break;
                                }
                                else
                                {
                                    int[,] table = gameBoard.Occupation();
                                    //Get Piece off of game board.
                                    Piece selected = gameBoard.GetPiece(x1,y1); //select the piece to move
                                    //Make sure piece is your piece.
                                    if(selected == null)
                                    {
                                        ErrorMessageBox.Text = "Did not select a piece.";
                                    } else if(selected.Player == Turn) { 
                                        Location to = new Location((File)x2, (Rank)y2);

                                        if(!gameBoard.Move(selected, from, to))
                                        {
                                            ErrorMessageBox.Text = "Piece move isn't valid.";
                                        }
                                        else
                                        {
                                            Player one;
                                            Player two;

                                            if (Turn==playerOne)
                                            {
                                                double xPoints = Math.Pow((x2 - x1), 2.0);
                                                double yPoints = Math.Pow((y2 - y1), 2.0);

                                                player1step += Convert.ToInt32(Math.Sqrt(xPoints + yPoints));
                                                one = playerOne;
                                                two = playerTwo;
                                            } else
                                            {
                                                two = playerOne;
                                                one = playerTwo;

                                                double xPoints = Math.Pow((x2 - x1), 2.0);
                                                double yPoints = Math.Pow((y2 - y1), 2.0);

                                                player2step += Convert.ToInt32(Math.Sqrt(xPoints + yPoints));
                                            }

                                            //check for check
                                            if (IsOpponentInCheck(one, two))
                                            {
                                                ErrorMessageBox.Text = "You're in Check!";
                                            }

                                            if (IsOpponentInCheck(two,one))
                                            {
                                                ErrorMessageBox.Text = "You would be in Check, not a valid move.";
                                            }

                                            //Change player
                                            if (Turn == playerOne)
                                            {
                                                Turn = playerTwo;
                                                playerTwo.Start();
                                                playerOne.Stop();
                                            }
                                            else
                                            {
                                                Turn = playerOne;
                                                playerOne.Start();
                                                playerTwo.Stop();
                                            }


                                        }
                                    }
                                    else
                                    {
                                        ErrorMessageBox.Text = "The selected piece is not yours.";
                                    }


                                    //reset the original points
                                    x1 = y1 = x2 = y2 = -1;

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

        private bool IsOpponentInCheck(Player one, Player two)
        {
            Piece opponentsking = null;

            //check for check
            foreach (Piece piece in two.Pieces)
            {
                if (piece is King)
                {
                    opponentsking = piece;
                    break;
                }
            }
            if (opponentsking == null)
            {
                Winner(Turn);
            }

            int[,] occupation = gameBoard.Occupation();
            foreach (Piece piece in one.Pieces)
            {
                if (piece.IsCheck(occupation, piece.CurrentLocation, opponentsking.CurrentLocation))
                {
                    return true;
                }
            }

            return false;

        }
        // refreshing the game board while the use maximized the window
        private void Form1_Resize(object sender, EventArgs e)
        {
            GameBoard.Refresh();
        }

        private void SurrenderButton_Click(object sender, EventArgs e)
        {
            if (Turn==playerOne)
                Winner(playerTwo);
            else
                Winner(playerOne);
        }

        private void Winner(Player player)
        {
            //whoever has the most pieces wins
            if(playerOne.PiecesLost.Count < playerTwo.PiecesLost.Count)
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "Blue Player Wins!!!";
            }
            else if(playerTwo.PiecesLost.Count < playerOne.PiecesLost.Count)
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "Red Player Wins!!!";
            }
            else
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "It was a tie!!!";
            }

            //end message
            ErrorMessageBox.Text = "Red player lost " + playerTwo.PiecesLost.Count.ToString() + " pieces; Move " + player2step.ToString() + " steps\n" +
                            "Blue player lost " + playerOne.PiecesLost.Count.ToString() + " pieces; Move " + player1step.ToString() + " steps\n" +
                            "Total time spent: " + playerOne.Totaltime().Add(playerTwo.Totaltime());

            GameBoard.Refresh();
        }
    }
}
