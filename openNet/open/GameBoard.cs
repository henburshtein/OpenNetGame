using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace open
{
    public partial class GameBoard : Form
    {
        private const int Snake_SPEED=20;
        private snake s;
        private food f;
        private Pen pen;
        private SolidBrush brush;
        private int score, speed;
        private bool right, left, up, down;
        private Form1 gb;

        public GameBoard(Form1 gg)
        {
            InitializeComponent();
            s = new snake();
            f = new food();
            score = 0;
            brush = new SolidBrush(ColorTranslator.FromHtml("#269ad6"));
            pen = new Pen(brush);
            speed = 150;
            right = false;
            left = false;
            up = false;
            down = false;
            gb = gg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label3.Text = score.ToString();
        }

        private void PPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.Black), s.SnakeRec[0]);
            for (int i = 1; i < s.SnakeRec.Length; i++)
            {
                g.FillRectangle(brush, s.SnakeRec[i]);
            }
            g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#e30614")), f.FoodRec);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right && left == false)
            {
                right = true;
                left = false;
                up = false;
                down = false;
            }
            else if (e.KeyCode == Keys.Left && right == false)
            {
                right = false;
                left = true;
                up = false;
                down = false;
            }
            else if(e.KeyCode == Keys.Up && down == false)
            {
                right = false;
                left = false;
                up = true;
                down = false;             
            }
            else if (e.KeyCode == Keys.Down && up == false)
            {
                right = false;
                left = false;
                up = false;
                down = true;
            }
        }

        private void moveS_Tick(object sender, EventArgs e)
        {
            if (right)
            {
                DrawSnake();
                s.SnakeRec[0].X += Snake_SPEED;
                if (s.SnakeRec[0].X > 800)
                {
                    right = false;
                    GameOver();
                }
            }
            else if (left)
            {
                DrawSnake();
                s.SnakeRec[0].X -= Snake_SPEED;
                if (s.SnakeRec[0].X < -4)
                {
                    left = false;
                    GameOver();
                }  
            }
            else if (up)
            {
                DrawSnake();
                s.SnakeRec[0].Y -= Snake_SPEED;
                if (s.SnakeRec[0].Y < 47)
                {
                    up = false;
                    GameOver();
                }  
            }
            else if (down)
            {
                DrawSnake();
                s.SnakeRec[0].Y += Snake_SPEED;
                if (s.SnakeRec[0].Y > 575)
                {
                    down = false;
                    GameOver();
                }
            }

            this.Refresh();

            //eating food
            for (int i = 0; i < s.SnakeRec.Length; i++)
            {
                if (s.SnakeRec[i].IntersectsWith(f.FoodRec))
                {
                    f.ChangeFoodLoc();
                    f.DrawFood();
                    GrowSnake();
                    score += 10;
                    this.label3.Text = score.ToString();
                }
            }
            //eating yourself


            for (int i = 1; i < s.SnakeRec.Length-1; i++)
            {
                if (s.SnakeRec[0].IntersectsWith(s.SnakeRec[i+1]))
                {
                    GameOver();
                }
            }
            

        }

        public void DrawSnake()
        {
            for (int i = s.SnakeRec.Length - 1; i > 0; i--)
                s.SnakeRec[i] = s.SnakeRec[i - 1];   
        }

        public void GrowSnake()
        {
            List<Rectangle> rec = s.SnakeRec.ToList();
            rec.Add(new Rectangle(new Point(s.SnakeRec[s.SnakeRec.Length - 1].X, s.SnakeRec[s.SnakeRec.Length - 1].Y), new Size(20, 20)));
            s.SetSnakeRec(rec.ToArray());
        }

        public void GameOver()
        {
            moveS.Enabled = false;
            MessageBox.Show("נפסלת!");
            MessageBox.Show("התוצאה שלך היא: " + score);
            score = 0;
            this.label3.Text = score.ToString();
            if (MessageBox.Show("?האם אתה רוצה לשחק משחק נוסף", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                s = new snake();
                f.ChangeFoodLoc();
                f.DrawFood();
                moveS.Enabled = true;
                moveS.Interval = 100;
            }
            else { Close(); }
        }

        public void UpdateLevel()
        {
            if (speed > 10)
            {
                speed -= 20;
                moveS.Interval = speed;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            moveS.Enabled = false;
            if (MessageBox.Show("האם אתה בטוח שאתה רוצה לחזור למסך הראשי?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                gb.Show();
            }
            else {
                moveS.Enabled = true;
            }

        }
    }
}
