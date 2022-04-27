using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace open
{
    class food
    {
        private Rectangle foodRec;
        private int x, y;
        private Random rnd;
        public food()
        {
    
            rnd = new Random();

            x = rnd.Next(0,40) * 20;
            y = rnd.Next(3, 29) * 20;

           foodRec = new Rectangle(new Point(x ,y), new Size(20, 20));
            
        }
        public Rectangle FoodRec
        {
            get { return foodRec; }
        }
        public void ChangeFoodLoc()
        {
            this.x = rnd.Next(0, 40) * 20;
            this.y = rnd.Next(3, 29) * 20;
        }
        public void DrawFood()
        {
            foodRec.X = x;
            foodRec.Y = y;
        }
    
    }
}
