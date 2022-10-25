using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djur
{
    class Program
    {
        static void Main(string[] args)
        {
            Petowner joppe = new Petowner(30);

            Cat lisa = new Cat("Lisa", 5); //skapar och lägger till 5 djur i listan Pets
            joppe.Pets.Add(lisa);
            Cat misselinus = new Cat("Misselinus", 9);
            joppe.Pets.Add(misselinus);
            Dog vovvesson = new Dog("Vovvesson", 7);
            joppe.Pets.Add(vovvesson);
            Dog fido = new Dog("Fido", 3);
            joppe.Pets.Add(fido);
            Puppy valpsson = new Puppy("Valpsson", 5);
            joppe.Pets.Add(valpsson);

            Console.WriteLine("Välkommen till programmet Joppes Djur! Här är en lista över djuren:");

            joppe.List_animals(); //skriv ut lista över djuren
            Animal u_animal = joppe.ChooseAnAnimal(); //användarens val av djur sparas som u_animal
            
            joppe.Menu(u_animal); //meny skrivs ut över vad användaren kan göra
            Console.WriteLine("Hoppas du hade roligt med Joppes Djur!");
        }
    }
}
