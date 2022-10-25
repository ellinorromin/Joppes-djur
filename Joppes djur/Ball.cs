using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djur
{
    class Ball
    {
        private string colour;
        private int quality;
        public int Quality
        {
            get { return quality; }
            set { quality = value; }
        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public Ball(string _colour, int _quality) //KONSTRUKTOR
        {
            colour = _colour;
            quality = _quality;
        }

        public int Lower_quality(int lower_with_how_much) //sänk värdet av bollen
        {
            quality = quality - lower_with_how_much;
            Console.WriteLine("Bollen har nu {0} i kvalitet", quality);
            return quality;

        }
        public override string ToString()
        {
            return string.Format("Bollen är {0} och har kvalitet {1}/10", colour, quality);
        }
    }
}
