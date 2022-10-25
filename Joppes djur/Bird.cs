using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djur
{
    class Bird : Animal
    {
        private int life;
        public int Life { get; set; }
        public Bird(string _name, int _age, int _life) //KONSTRUKTOR
        {
            name = _name;
            age = _age;
            life = _life;
            fav_food = "frön";
        }

        public int Play_with_cat()
        {
            life = life - 1;
            return life;
        }

        public override Ball Interact(Ball bird_ball) //nu skapar jag en ny boll igen >:(
        {
            return bird_ball;
        }
        public override void Eat(string food)
        {
        }
        public override string ToString()
        {
            return string.Format("Fågeln {0}, {1} år gammal. {0} har {2} i liv!", name, age, life);
        }
    }
}
