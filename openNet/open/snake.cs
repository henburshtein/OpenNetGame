using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace open
{
    class snake
    {

        private Rectangle[] snakeRec;
        private int x, y;
        public snake()
        {
            snakeRec = new Rectangle[1];

            x = 200;
            y = 200;

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(new Point(x ,y), new Size(20, 20));
                x -= 20;
            }
        }
        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }
        }
        public void SetSnakeRec(Rectangle[] r)
        { 
            snakeRec = r;
        }
    }
}
