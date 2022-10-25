using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djur
{
    abstract class Animal
    {
        protected int age;
        protected string name;
        protected string fav_food;
        protected string breed; //breed används aldrig men det var med i original-UMLen ...
        protected bool hungry;

        public int Age
        {
            get { return age; }
            set { Age = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Fav_food
        {
            get { return fav_food; }
            set { fav_food = value; }
        }
        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        public bool Hungry
        {
            get { return hungry; }
            set { hungry = value; }
        }

        public virtual Ball Interact(Ball animal_ball) //används när djuret ska leka, sänker bollens kvalitet
        {
            if (animal_ball.Quality > 0)
            {
                hungry = true;
                Console.WriteLine("{0} leker med bollen!", name);
                Console.ReadKey();
                animal_ball.Lower_quality(1);
            }
            else
                Console.WriteLine("Bollen har tyvärr gått sönder, du borde köpa en ny.");
            return animal_ball;
        }
        public virtual void Eat(string food) //kollar så djuret fått rätt mat, annars fortsätter det vara hungrigt
        {
            if (hungry == true)
            {
                if (food == fav_food)
                {
                    hungry = false;
                    Console.WriteLine("{0} älskar {1} och äter det mycket glatt!", name, food);
                }
                else
                {
                    hungry = true;
                    Console.WriteLine("{0} äter inte {1}.", name, food);
                    Hungry_animal();
                }
            }
            else
                Console.WriteLine("{0} är mätt och undrar varför du försöker ge mat?", name);
        }
        public virtual void Hungry_animal() //kollar om djuret är hungrigt
        {
            if (hungry == true)
            {
                Console.WriteLine("{0} gnyr av hunger ...", name);
            }
            else
                Console.WriteLine("{0} är mätt.", name);
        }
        public override string ToString()
        {
            return string.Format("{0}, {1} år gammal", name, age);
        }

    }
}
