using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PB
{
    internal class Food
    {
        public int x { get; set; }
        public int y { get; set; }
        public float ammount { get; set; }

        public Food(int x, int y, float ammount)
        {
            this.x = x;
            this.y = y;
            this.ammount = ammount;
        }

        public Food(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.ammount = 5;
        }

        public void Decay()
        {
            this.ammount -= (float)0.01;
        }
    }
}
