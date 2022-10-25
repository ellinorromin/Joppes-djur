using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djur
{
    class Dog : Animal
    {
        public Dog(string _name, int _age) //KONSTRUKTOR
        {
            name = _name;
            age = _age;
            fav_food = "PEDIGREE";
        }
        public override Ball Interact(Ball dog_ball) //sänker bollens värde med 2 istället för 1
        {
            if (dog_ball.Quality > 0)
            {
                hungry = true;
                Console.WriteLine("{0} leker med bollen!", name);
                dog_ball.Lower_quality(2);
            }
            else
                Console.WriteLine("Bollen har tyvärr gått sönder, du borde köpa en ny.");
            return dog_ball;
        }
        public override string ToString()
        {
            return string.Format("Hunden {0}, {1} år gammal", name, age);
        }
    }
}
