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
        int x_init = 0;
        int y_init = 0;
        int x_Limit = 1024; //limit it for the picture box: you could also just look at the max height or width
        int y_limit = 1024;
        int BoardSquareWidth = 128; //each square on the board is 128x128 pixels
        int BoardSquareHeight = 128;
        System.Drawing.SolidBrush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        System.Drawing.SolidBrush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        int offset = 0;
        List<Piece> player1 = new List<Piece>(); //2 list for each players pieces left
        List<Piece> player2 = new List<Piece>();
        int x1 = -1; //this is horrible code, but its late, this is to hold the mouse input on where it clicked
        int y1 = -1;
        int x2 = -1;
        int y2 = -1;


        public Form1()
        {
            InitializeComponent();
        }

        //draw the board
        private void DrawBoard(Graphics g, int x, int y)
        {
            //make sure the x doesnt reach the limit
            if (x_init < x_Limit)
            {
                //draw each square in black and white:: the area of the game is 1024 X 1024
                if (offset % 2 == 0)
                {
                    g.FillRectangle(BlackBrush, x_init, y_init, BoardSquareWidth, BoardSquareHeight);
                    offset += 1;
                }
                else
                {
                    g.FillRectangle(WhiteBrush, x_init, y_init, BoardSquareWidth, BoardSquareHeight);
                    offset += 1;
                }
                x_init += BoardSquareWidth;
                DrawBoard(g, x_init, y_init);
            }
            else
            {
                //reset the point and offset the graph
                x_init = 0;
                offset += 1;

                //make sure the y doesnt reach the limit
                if (y_init < y_limit)
                {
                    y_init += BoardSquareHeight;
                    if (offset <= 64) //ammount of total square that should be drawn
                    {
                        DrawBoard(g, x_init, y_init);
                    }
                }
                else
                {
                    //y and offset reset incase we need to redraw it again, also x should reset each time if not just add it
                    y_init = 0;
                    offset = 0;
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
                        g.DrawRectangle(redPen, xlowerbound, ylowerbound, BoardSquareWidth - 1, BoardSquareHeight - 1);

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
                            g.DrawRectangle(GreenPen, xlowerbound, ylowerbound, BoardSquareWidth - 1, BoardSquareHeight - 1);

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
            DrawBoard(g, x_init, y_init);
            DrawPieces(g);
        }

        //When you click the board it will be able to move pieces to that location
        private void Board_Click(object sender, MouseEventArgs e)
        {
            Graphics g = GameBoard.CreateGraphics();
            DrawHighlight(e.X, e.Y, 0, 128, 0, 128, g);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            GameBoard.Refresh();
        }
    }
}
