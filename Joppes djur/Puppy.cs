using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djur
{
    class Puppy : Dog 
    {
        private int ageInMonths;
        public int AgeInMonths
        {
            get { return ageInMonths; }
            set { ageInMonths = value; }
        }

        public Puppy(string _name, int _age) : base(_name, 0) //KONSTRUKTOR
        {
            name = _name;
            ageInMonths = _age;
            fav_food = "VALPMAT";
        }
        public override Ball Interact(Ball puppy_ball) //overridar hundens overridande av animal
        {
            if (puppy_ball.Quality > 0)
            {
                hungry = true;
                puppy_ball.Lower_quality(1);
            }
            else
                Console.WriteLine("Bollen har tyvärr gått sönder, du borde köpa en ny.");
            return puppy_ball;
        }
        public override string ToString()
        {
            return string.Format("Valpen {0}, {1} månader gammal.", name, ageInMonths);
        }
    }
}
