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
        static Point LIMINT = new Point(840, 840);
        static int BoardSquareLength = 105; //each square on the board is 105x105 pixels
        static HashSet<Point> BOARD_COORDINATE = new HashSet<Point>();  // game board coordinate
        static HashSet<Piece> PIECES_CORRDINATE = new HashSet<Piece>(); // this show where the pieces are
        static List<Point> player1 = new List<Point>(); //2 list for each players pieces left
        static List<Point> player2 = new List<Point>();
        static Point selectPick = new Point(-1, 9999);  // the first mouse click
        static Point selectMove = new Point(-1, 9999);  // the second mouse click
        int player1points = 0;
        int player2points = 0;

        public Form1()
        {
            InitializeComponent();
            BuildBoardCoordinate();
            PiecesCoordinateInit();
        }

        // setting up pieces' coordinate base on the gameboard coordnate
        private void PiecesCoordinateInit()
        {
            // loop through the game boerd coordinate
            foreach (var coord in BOARD_COORDINATE)
            {
                switch (coord.Y) 
                {
                    case 105: PIECES_CORRDINATE.Add(new Pawn(Side.black, coord)); player1.Add(coord); break;
                    case 630: PIECES_CORRDINATE.Add(new Pawn(Side.White, coord)); player2.Add(coord); break;
                    case 0: 
                        {
                            switch (coord.X)
                            {
                                case 0: PIECES_CORRDINATE.Add(new Rook(Side.black, coord)); player1.Add(coord); break;
                                case 105: PIECES_CORRDINATE.Add(new Knight(Side.black, coord)); player1.Add(coord); break;
                                case 210: PIECES_CORRDINATE.Add(new Bishop(Side.black, coord)); player1.Add(coord); break;
                                case 315: PIECES_CORRDINATE.Add(new King(Side.black, coord)); player1.Add(coord); break;
                                case 420: PIECES_CORRDINATE.Add(new Queen(Side.black, coord)); player1.Add(coord); break;
                                case 525: PIECES_CORRDINATE.Add(new Bishop(Side.black, coord)); player1.Add(coord); break;
                                case 630: PIECES_CORRDINATE.Add(new Knight(Side.black, coord)); player1.Add(coord); break;
                                case 735: PIECES_CORRDINATE.Add(new Rook(Side.black, coord)); player1.Add(coord); break;
                                default:
                                    break;
                            }
                        } break;
                    case 735:
                        {
                            switch (coord.X)
                            {
                                case 0: PIECES_CORRDINATE.Add(new Rook(Side.White, coord)); player2.Add(coord); break;
                                case 105: PIECES_CORRDINATE.Add(new Knight(Side.White, coord)); player2.Add(coord); break;
                                case 210: PIECES_CORRDINATE.Add(new Bishop(Side.White, coord)); player2.Add(coord); break;
                                case 315: PIECES_CORRDINATE.Add(new King(Side.White, coord)); player2.Add(coord); break;
                                case 420: PIECES_CORRDINATE.Add(new Queen(Side.White, coord)); player2.Add(coord); break;
                                case 525: PIECES_CORRDINATE.Add(new Bishop(Side.White, coord)); player2.Add(coord); break;
                                case 630: PIECES_CORRDINATE.Add(new Knight(Side.White, coord)); player2.Add(coord); break;
                                case 735: PIECES_CORRDINATE.Add(new Rook(Side.White, coord)); player2.Add(coord); break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // This sets up the game board coordinate
        private void BuildBoardCoordinate()
        {
            // game board start with (0, 0)
            BOARD_COORDINATE.Add(INIT);
            // loop through the coordinate of x
            for(; INIT.X < LIMINT.X; INIT.X += BoardSquareLength)
            {
                INIT.Y = 0;
                // loop through the coordinate of Y
                for (; INIT.Y < LIMINT.Y; INIT.Y += BoardSquareLength)
                {
                    BOARD_COORDINATE.Add(INIT);
                }
            }
            INIT = new Point(0, 0);
        }

        //draw the board
        private void DrawBoard(Graphics g)
        {
            using (SolidBrush sb = new SolidBrush(Color.White))
            {
                foreach (var coord in BOARD_COORDINATE)
                {
                    Rectangle rt = new Rectangle(coord.X, coord.Y, coord.X + BoardSquareLength, coord.Y + BoardSquareLength);
                    //MessageBox.Show(coord.X.ToString() + ", " + coord.Y.ToString());
                    g.FillRectangle(sb, rt); 
                    
                    if (sb.Color == Color.Black)
                        sb.Color = Color.White;
                    else
                        sb.Color = Color.Black;

                    if(coord.Y == LIMINT.Y - BoardSquareLength)
                        if (sb.Color == Color.Black)
                            sb.Color = Color.White;
                        else
                            sb.Color = Color.Black;
                }
            }
        }

        //Event to paint the board and set up the game
        private void Board_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //set the game up
            DrawBoard(g);
            DrawPieces(g);
        }

        // this method draw the pieces into the picture box
        private void DrawPieces(Graphics g)
        {
            // loop through the pieces coordinate
            foreach(var piece in PIECES_CORRDINATE)
            { 
                // switch depend on pieces' type
                switch (piece.Type)
                {
                    // if pieces's type is Bishop, then.... and so on
                    case Type.Bishop:
                        {
                            // checking for the pieces' side (black/white)
                            // next couple if statements are doing the same job but with different pieces' type
                            if (piece.Side == Side.black)
                                g.DrawString("Bishop", this.Font, Brushes.Red, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                            else
                                g.DrawString("Bishop", this.Font, Brushes.Blue, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                        } 
                        break;
                    case Type.King:
                        {
                            if (piece.Side == Side.black)
                                g.DrawString("King", this.Font, Brushes.Red, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                            else
                                g.DrawString("King", this.Font, Brushes.Blue, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                        }
                        break;
                    case Type.Knight:
                        {
                            if (piece.Side == Side.black)
                                g.DrawString("Knight", this.Font, Brushes.Red, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                            else
                                g.DrawString("Knight", this.Font, Brushes.Blue, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                        }
                        break;
                    case Type.Pawn:
                        {
                            if (piece.Side == Side.black)
                                g.DrawString("Pawn", this.Font, Brushes.Red, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                            else
                                g.DrawString("Pawn", this.Font, Brushes.Blue, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                        }
                        break;
                    case Type.Queen:
                        {
                            if (piece.Side == Side.black)
                                g.DrawString("Queen", this.Font, Brushes.Red, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                            else
                                g.DrawString("Queen", this.Font, Brushes.Blue, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                        }
                        break;
                    case Type.Rook:
                        {
                            if (piece.Side == Side.black)
                                g.DrawString("Rook", this.Font, Brushes.Red, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                            else
                                g.DrawString("Rook", this.Font, Brushes.Blue, new Point(piece.Coordinate.X + 20, piece.Coordinate.Y + 50));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        //When you click the board it will be able to move pieces to that location
        private void Board_Click(object sender, MouseEventArgs e)
        {
            selectPick = selectMove;
            selectMove = new Point(e.X / 105 * 105, e.Y / 105 * 105);
            PieceMove();
        }

        // method that control when the piece should move
        private void PieceMove()
        {
            bool sameside = false;
            // first mouse click is the selectPick and the second mouse click is the selectMove
            // in the meanwhile first click will be the second click
            
            // loop through the possible pieces' coordinate
            foreach (var select in PIECES_CORRDINATE)
            {
                // while the selected grid has piece match with
                if (select.Coordinate.X == selectPick.X && select.Coordinate.Y == selectPick.Y)
                {
                    if (select.Side == Side.black)
                    {
                        foreach(var s in player1)
                        {
                            if (s.X == selectMove.X && s.Y == selectMove.Y)
                            {
                                sameside = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var s in player2)
                        {
                            if (s.X == selectMove.X && s.Y == selectMove.Y)
                            {
                                sameside = true;
                                break;
                            }
                        }
                    }

                    // selected piece move
                    if (!sameside && select.move(selectMove))
                    {
                        if (select.Side == Side.black)
                        {
                            player1.Remove(selectPick);
                            player1.Add(selectMove);
                        }
                        else
                        {
                            player2.Remove(selectPick);
                            player2.Add(selectMove);
                        }

                        // check if the destination of the selected piece is occupy or not
                        foreach (var remove in PIECES_CORRDINATE)
                        {
                            // if place is occupy
                            if (remove.Coordinate.X == selectMove.X && remove.Coordinate.Y == selectMove.Y && remove.Side != select.Side)
                            {
                                if (remove.Side == Side.black)
                                    player1.Remove(selectMove);
                                else
                                    player2.Remove(selectMove);
                                remove.Coordinate = new Point(-1, 9999);
                                break;
                            }
                        }
                        selectMove = new Point(-1, 9999);
                    }
                }
            }
            GameBoard.Refresh();
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
                WinnerLabel.Text = "Player 1 Wins!!!";
            }
            else if(player2points > player1points)
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "Player 2 Wins!!!";
            }
            else
            {
                WinnerLabel.Visible = true;
                WinnerLabel.Text = "It was a tie!!!";
            }
            ResetButton.Visible = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //reset the labels
            WinnerLabel.Visible = false;
            ResetButton.Visible = false;

            //reset the gameboard
            PiecesCoordinateInit();
            GameBoard.Refresh();
        }
    }
}
