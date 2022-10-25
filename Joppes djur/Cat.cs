using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djur
{
    class Cat : Animal
    {
        private int howHungryIsCat = 1; //ingen property för denna behöver aldrig användas utanför Cat-klassen
        public Cat(string _name, int _age) //KONSTRUKTOR
        {
            name = _name;
            age = _age;
            fav_food = "WHISKAS";
        }

        public override void Hungry_animal() //vad som händer när katten blir lite för hungrig
        {
            if (howHungryIsCat >= 3)
            {
                Console.WriteLine("{0} tröttnade på att vänta och har gett sig iväg för att jaga en mus.", name);
                howHungryIsCat = 1;
                hungry = false;
            }
            else
            {
                if (hungry == true)
                {
                    Console.WriteLine("{0} är hungrig och ger sig snart ut för att jaga en mus!", name);
                    howHungryIsCat++;
                }
                else
                    Console.WriteLine("{0} är mätt.", name);
            }
        }
        public override string ToString()
        {
            return string.Format("Katten {0}, {1} år gammal", name, age);
        }
    }
}


