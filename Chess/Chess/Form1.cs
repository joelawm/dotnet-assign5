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
        static int BoardSquareLength = 105; //each square on the board is 128x128 pixels
        static HashSet<Point> BOARD_COORDINATE = new HashSet<Point>();  // game board coordinate
        static HashSet<Piece> PIECES_CORRDINATE = new HashSet<Piece>(); // this show where the pieces are
        static List<Point> player1 = new List<Point>(); //2 list for each players pieces left
        static List<Point> player2 = new List<Point>();
        static Point selectPick = new Point(-1, 9999);  // the first mouse click
        static Point selectMove = new Point(-1, 9999);  // the second mouse click
        static Side turn = Side.black;
        static DateTime time;
        static int player1Lost = 0;
        static int player2Lost = 0;
        static int player1step = 0;
        static int player2step = 0;
        int x1 = -1; //this is horrible code, but its late, this is to hold the mouse input on where it clicked
        int y1 = -1;
        int x2 = -1;
        int y2 = -1;


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

        //draw a red highlight in square that is clicked
        private void DrawHighlight(int x, int y, int xlowerbound, int xupperbound, int ylowerbound, int yupperbound, Graphics g)
        {
            if (x1 == -1)
            {
                //Search through x the bounds to make sure its good
                if(x >= xlowerbound && x <= xupperbound)
                {
                    //Search through y the bounds to make sure its good
                    if (y >= ylowerbound && y <= yupperbound)
                    {
                        Pen redPen = new Pen(Color.Red, 1);
                        //draw the rectangle
                        g.DrawRectangle(redPen, xlowerbound, ylowerbound, BoardSquareLength - 1, BoardSquareLength - 1);

                        //save the cordinates to update next postion
                        x1 = x;
                        y1 = y;
                    }
                    else
                    {
                        //if not good, then it will shift one square down
                        DrawHighlight(x, y, 0, BoardSquareLength, ylowerbound + BoardSquareLength, yupperbound + BoardSquareLength, g);
                    }
                }
                else
                {
                    //if not good it will shift one square to the right
                    DrawHighlight(x, y, xlowerbound + BoardSquareLength, xupperbound + BoardSquareLength, ylowerbound, yupperbound, g);
                }
            }
            else
            {
                if (x2 == -1)
                {
                    //Search through x the bounds to make sure its good
                    if (x >= xlowerbound && x <= xupperbound)
                    {
                        //Search through y the bounds to make sure its good
                        if (y >= ylowerbound && y <= yupperbound)
                        {
                            Pen GreenPen = new Pen(Color.Green, 1);
                            //draw the rectangle
                            g.DrawRectangle(GreenPen, xlowerbound, ylowerbound, BoardSquareLength - 1, BoardSquareLength - 1);

                            //save the cordinates to update next postion
                            x2 = x;
                            y2 = y;

                            //call code to update postions
                            UpdatePiecePosition(x1, y1, x2, y2);
                            //reset the original points
                            x1 = -1;
                            y1 = -1;
                            x2 = -1;
                            y2 = -1;
                            //refresh the gameboard
                            GameBoard.Refresh();
                        }
                        else
                        {
                            //if not good, then it will shift one square down
                            DrawHighlight(x, y, 0, BoardSquareLength, ylowerbound + BoardSquareLength, yupperbound + BoardSquareLength, g);
                        }
                    }
                    else
                    {
                        //if not good it will shift one square to the right
                        DrawHighlight(x, y, xlowerbound + BoardSquareLength, xupperbound + BoardSquareLength, ylowerbound, yupperbound, g);
                    }
                }
            }
        }

        private void UpdatePiecePosition(int x1,  int y1, int x2, int y2)
        {

        }


        //Event to paint the board and set up the game
        private void Board_Paint(object sender, PaintEventArgs e)
        {
            if (turn == Side.black)
            {
                PlayerTurnLabel.ForeColor = Color.Red;
                PlayerTurnLabel.Text = "Red player's turn";
            }
            else
            {
                PlayerTurnLabel.ForeColor = Color.Blue;
                PlayerTurnLabel.Text = "Blue player's turn";
            }
            Graphics g = e.Graphics;
            //set the game up
            DrawBoard(g);
            //DrawPieces(g);
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
            Graphics g = GameBoard.CreateGraphics();
            DrawHighlight(e.X, e.Y, 0, BoardSquareLength, 0, BoardSquareLength, g);
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
                if (select.Coordinate.X == selectPick.X && select.Coordinate.Y == selectPick.Y && turn == select.Side)
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
                        if (player1step == 0)
                            time = DateTime.Now;

                        if (turn == Side.black)
                        {
                            turn = Side.White;
                            ++player1step;
                        }
                        else
                        {
                            turn = Side.black;
                            ++player2step;
                        }

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
                                if (remove.Type == Type.King)
                                {
                                    ClaimWinner(remove.Side);
                                    return;
                                }
                                if (remove.Side == Side.black)
                                {
                                    player1.Remove(selectMove);
                                    ++player1Lost;
                                }
                                else
                                {
                                    player2.Remove(selectMove);
                                    ++player2Lost;
                                }
                                remove.Coordinate = new Point(-1, 9999);
                                break;
                            }
                        }
                        selectMove = new Point(-1, 9999);
                        break;
                    }
                }
            }
            GameBoard.Refresh();
        }

        private void ClaimWinner( Side side)
        {
            if (side == Side.black)
                MessageBox.Show("Blue player win");
            else
                MessageBox.Show("Red player win");

            MessageBox.Show("Red player lost " + player1Lost.ToString() + " pieces; Move " + player1step.ToString() + " steps\n" +
                            "Blue player lost " + player2Lost.ToString() + " pieces; Move " + player2step.ToString() + " steps\n" +
                            "Total time spended: " + (DateTime.Now - time).Hours.ToString() + " house, " + (DateTime.Now - time).Minutes.ToString() + " minutes, " +
                            (DateTime.Now - time).Seconds.ToString() + " seconds, " + (DateTime.Now - time).Milliseconds.ToString() + " milliseconds, ");

            player1Lost = 0;
            player2Lost = 0;
            player1step = 0;
            player2step = 0;
            turn = Side.black;
            player1.Clear();
            player2.Clear();
            BOARD_COORDINATE.Clear();
            PIECES_CORRDINATE.Clear();
            BuildBoardCoordinate();
            PiecesCoordinateInit();
            GameBoard.Refresh();
        }

        // refreshing the game board while the use maximized the window
        private void Form1_Resize(object sender, EventArgs e)
        {
            GameBoard.Refresh();
        }
    }
}
