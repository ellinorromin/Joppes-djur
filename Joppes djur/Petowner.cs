using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Joppes_djur
{
    class Petowner
    {
        private int age;
        private Ball joppe_ball = new Ball("grön", 10);
        private List<Animal> pets = new List<Animal> { };

        public List<Animal> Pets
        {
            get { return pets; }
            set { pets = value; }
        }
        public Ball Joppe_Ball
        {
            get { return joppe_ball; }
            set { joppe_ball = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Petowner(int _age) //KONSTRUKTOR
        {
            age = _age;
        }

        public Animal ChooseAnAnimal() //metod som låter användaren välja eller välja om djur
        {
            Animal u_Animal = null;
            bool thisLoop = true;
            while (thisLoop == true)
            {
                Console.WriteLine("Vilket djur vill du leka med? Svara med djurets siffra.");
                int user_answer;
                while (!int.TryParse(Console.ReadLine(), out user_answer))
                {
                    Console.WriteLine("Du verkar ha skrivit i fel format! Försök skriva ett heltal.");
                }
                user_answer--; //så att svaret och indexnumret ska vara detsamma
                for (int i = 0; i < pets.Count; i++)
                {
                    if (i == user_answer)
                    {
                        u_Animal = pets[i];
                        thisLoop = false;
                        Console.WriteLine("Du vill alltså leka med {0}! Tryck för att fortsätta.", pets[i].Name);
                        Console.ReadKey();
                        break;
                    }
                    else if (i != user_answer && user_answer >= pets.Count)
                    {
                        Console.WriteLine("Djuret du söker finns tyvärr inte i listan. Tryck på valfri tangent och försök sedan igen.");
                        Console.ReadKey();
                        break;
                    }
                    else if (i != user_answer && user_answer <= 0)
                    {
                        Console.WriteLine("Djuret du söker finns tyvärr inte i listan. Tryck på valfri tangent och försök sedan igen.");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            return u_Animal;
        }

        public void Fetch(Animal user_Animal) //lek med djuret
        {
            user_Animal.Interact(joppe_ball);
        }
        public void Feed(Animal user_Animal) //mata djuret, åtminstone om det är rätt mat
        {
            Console.WriteLine("Vad vill du ge för mat?");
            Console.WriteLine("Whiskas - för katter [skriv WHISKAS]");
            Console.WriteLine("Pedigree - för hundar [skriv PEDIGREE]");
            Console.WriteLine("Valpmat - för valpar [skriv VALPMAT]");
            var foodAnswer = Console.ReadLine();
            if (foodAnswer == "WHISKAS" || foodAnswer == "PEDIGREE" || foodAnswer == "VALPMAT") 
            {
                user_Animal.Eat(foodAnswer);
            }
            else
                Console.WriteLine("Vi har tyvärr inte det i skafferiet. Skrev du med stora bokstäver?");
        }
        public void List_animals() //skriv ut listan över djuren (pets)
        {
            int i = 1;
            foreach (var pet in pets)
            {
                Console.WriteLine("{0}. {1}", i, pet);
                i++;
            }
        }
        public void Check_ball() //vad är värdet på bollen? fixa en ny boll om det behövs
        {
            Console.WriteLine(joppe_ball);
            if (joppe_ball.Quality > 5)
                Console.WriteLine("Bollen är ok.");
            else if (joppe_ball.Quality >= 3 && joppe_ball.Quality <= 5)
                Console.WriteLine("Bollen börjar se lite sliten ut.");
            else if (joppe_ball.Quality < 3 && joppe_ball.Quality > 1)
                Console.WriteLine("... du kanske behöver en ny boll snart ?");
            else
            {
                Console.WriteLine("Du har ingen boll mer, den har gått sönder.");
                Console.WriteLine("Vill du laga bollen? Y / N");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    joppe_ball.Quality = 10;
                    Console.WriteLine("Bollens kvalitet har nu återställts till 10!");
                }
                else if (answer == "N" || answer == "n")
                    Console.WriteLine("skyll dig själv, då har du ingen boll");
                else
                    Console.WriteLine("{0} var inte ett alternativ. Kom tillbaka när du bestämt dig.", answer);
            }
        }
        public void Menu(Animal user_Animal) //spelmeny
        {
            bool menu = true;
            while (menu == true)
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra med {0}?", user_Animal.Name);
                Console.WriteLine("Leka med {0} [TRYCK 1]", user_Animal.Name);
                Console.WriteLine("Mata {0} [TRYCK 2]", user_Animal.Name);
                Console.WriteLine("Är {0} hungrig? [TRYCK 3]", user_Animal.Name);
                Console.WriteLine("Se listan igen & byt djur [TRYCK 4]");
                Console.WriteLine("Kolla hur bollen mår [TRYCK 5]");
                Console.WriteLine("Spara ner en lista över djuren [TRYCK 6]");
                Console.WriteLine("Avsluta spel [TRYCK 7]");
                int menuAnswer;
                while (!int.TryParse(Console.ReadLine(), out menuAnswer))
                {
                    Console.WriteLine("Försök igen!");
                }
                switch (menuAnswer)
                {
                    case 1: //leka med djuret
                        Fetch(user_Animal);
                        Console.ReadKey();
                        break;
                    case 2: //mata djuret
                        Feed(user_Animal);
                        Console.ReadKey();
                        break;
                    case 3: //se om djuret är hungrigt
                        user_Animal.Hungry_animal();
                        Console.ReadKey();
                        break;
                    case 4: //skriv ut lista över djuren, välj ett nytt
                        List_animals();
                        user_Animal = ChooseAnAnimal();
                        break;
                    case 5: //hur mår bollen?
                        Check_ball();
                        Console.ReadKey();
                        break;
                    case 6: //sparar djur i lista
                        foreach (var animal in pets)
                        {
                            SaveListOfAnimalsInFile("Joppes djur, lista.txt", animal.ToString());
                        }
                        Console.WriteLine("Djuren sparades i textdokumentet 'Joppes djur, lista'");
                        Console.ReadKey();
                        break;
                    case 7: //avslutar metoden och i förlängningen spelet
                        menu = false;
                        break;
                    default: //om användarens siffra inte finns
                        Console.WriteLine("{0} är tyvärr inte ett alternativ.", menuAnswer);
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void SaveListOfAnimalsInFile(string textfilName, string text)
        {
            try
            {
                using (StreamWriter _streamWriter = new StreamWriter(textfilName, true))
                {
                    _streamWriter.WriteLine(text);
                    _streamWriter.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override string ToString()
        {
            try
            {
                return string.Format("Joppe är {0} år och har {1} djur!", age, Pets.Count());

            }
            catch (ArgumentNullException) //fick denna exception i början av kodandet, har behållit den för säkerhets skull
            {
                return string.Format("Joppe är {0} år och har 0 djur!", age);
                throw;
            }
        }
    }
}
