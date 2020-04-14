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
        static HashSet<Point> BOARD_COORDINATE = new HashSet<Point>();
        static HashSet<Piece> PIECES_CORRDINATE = new HashSet<Piece>();
        List<Piece> player1 = new List<Piece>(); //2 list for each players pieces left
        List<Piece> player2 = new List<Piece>();
        static Point selectPick = new Point(-1, 9999);
        static Point selectMove = new Point(-1, 9999);
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

        private void PiecesCoordinateInit()
        {
            foreach (var coord in BOARD_COORDINATE)
            {
                switch (coord.Y) 
                {
                    case 105: PIECES_CORRDINATE.Add(new Pawn(Side.black, coord)); break;
                    case 630: PIECES_CORRDINATE.Add(new Pawn(Side.White, coord)); break;
                    case 0: 
                        {
                            switch (coord.X)
                            {
                                case 0: PIECES_CORRDINATE.Add(new Rook(Side.black, coord)); break;
                                case 105: PIECES_CORRDINATE.Add(new Knight(Side.black, coord)); break;
                                case 210: PIECES_CORRDINATE.Add(new Bishop(Side.black, coord)); break;
                                case 315: PIECES_CORRDINATE.Add(new King(Side.black, coord)); break;
                                case 420: PIECES_CORRDINATE.Add(new Queen(Side.black, coord)); break;
                                case 525: PIECES_CORRDINATE.Add(new Bishop(Side.black, coord)); break;
                                case 630: PIECES_CORRDINATE.Add(new Knight(Side.black, coord)); break;
                                case 735: PIECES_CORRDINATE.Add(new Rook(Side.black, coord)); break;
                                default:
                                    break;
                            }
                        } break;
                    case 735:
                        {
                            switch (coord.X)
                            {
                                case 0: PIECES_CORRDINATE.Add(new Rook(Side.White, coord)); break;
                                case 105: PIECES_CORRDINATE.Add(new Knight(Side.White, coord)); break;
                                case 210: PIECES_CORRDINATE.Add(new Bishop(Side.White, coord)); break;
                                case 315: PIECES_CORRDINATE.Add(new King(Side.White, coord)); break;
                                case 420: PIECES_CORRDINATE.Add(new Queen(Side.White, coord)); break;
                                case 525: PIECES_CORRDINATE.Add(new Bishop(Side.White, coord)); break;
                                case 630: PIECES_CORRDINATE.Add(new Knight(Side.White, coord)); break;
                                case 735: PIECES_CORRDINATE.Add(new Rook(Side.White, coord)); break;
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

        private void BuildBoardCoordinate()
        {
            BOARD_COORDINATE.Add(INIT);
            for(; INIT.X < LIMINT.X; INIT.X += BoardSquareLength)
            {
                INIT.Y = 0;
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
            Graphics g = e.Graphics;
            //set the game up
            DrawBoard(g);
            //DrawPieces(g);
            DrawPieces(g);
        }

        private void DrawPieces(Graphics g)
        {
            foreach(var piece in PIECES_CORRDINATE)
            { 
                switch (piece.Type)
                {
                    case Type.Bishop:
                        {
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
            //MessageBox.Show(selectPick.X.ToString() + ", " + selectPick.Y.ToString() + " : " +
            //                        selectMove.X.ToString() + ", " + selectMove.Y.ToString());
            PieceMove();
            //Graphics g = GameBoard.CreateGraphics();
            //DrawHighlight(e.X, e.Y, 0, BoardSquareLength, 0, BoardSquareLength, g);
        }

        private void PieceMove()
        {
            
            foreach (var select in PIECES_CORRDINATE)
            {
                if (select.Coordinate.X == selectPick.X && select.Coordinate.Y == selectPick.Y)
                {
                    if (select.move(selectMove))
                    {
                        foreach (var remove in PIECES_CORRDINATE)
                        {
                            if (remove.Coordinate.X == selectMove.X && remove.Coordinate.Y == selectMove.Y && remove.Side != select.Side)
                            {
                                remove.Coordinate = new Point(-1, 9999);
                                break;
                            }
                        }
                    }
                }
            }
            GameBoard.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            GameBoard.Refresh();
        }
    }
}
