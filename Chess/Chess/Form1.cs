using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        List<Piece> player1 = new List<Piece>(); //2 list for each players pieces left
        List<Piece> player2 = new List<Piece>();
        int x1 = -1; //this is horrible code, but its late, this is to hold the mouse input on where it clicked
        int y1 = -1;
        int x2 = -1;
        int y2 = -1;


        public Form1()
        {
            InitializeComponent();
            BuildBoardCoordinate();
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

        //draw the pieces on the board
        private void DrawPieces(Graphics g)
        {
            using (Pen myPen = new Pen(Color.Gray))
            {
                //draw each chest piece in grey
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
                        DrawHighlight(x, y, 0, 128, ylowerbound + 128, yupperbound + 128, g);
                    }
                }
                else
                {
                    //if not good it will shift one square to the right
                    DrawHighlight(x, y, xlowerbound + 128, xupperbound + 128, ylowerbound, yupperbound, g);
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
                            //GameBoard.Invalidate();
                            //GameBoard.Update();
                        }
                        else
                        {
                            //if not good, then it will shift one square down
                            DrawHighlight(x, y, 0, 128, ylowerbound + 128, yupperbound + 128, g);
                        }
                    }
                    else
                    {
                        //if not good it will shift one square to the right
                        DrawHighlight(x, y, xlowerbound + 128, xupperbound + 128, ylowerbound, yupperbound, g);
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
        }

        //When you click the board it will be able to move pieces to that location
        private void Board_Click(object sender, MouseEventArgs e)
        {
            Graphics g = GameBoard.CreateGraphics();
            DrawHighlight(e.X, e.Y, 0, 105, 0, 105, g);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            GameBoard.Refresh();
        }
    }
}
