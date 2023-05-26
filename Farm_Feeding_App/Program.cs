using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Dynamic;

namespace Farm_Feeding_App
{
    internal class Program
    {
        static Dictionary<string, string[]> animalsDictionary = new Dictionary<string, string[]>()
        {
            {"Chicken", new string[]{"Brown", "Silkie" } } ,
            {"Duck", new string[]{"Pekin", "Silver Bantam" } } ,
            {"Alpaca", new string[]{"Suri", "Huacaya" } } ,
            {"Goat", new string[]{"Nubian", "Pygmy" } }
        };
        

        public static void Main(string[] args)
        {



            //ask and store animal details
            

            Console.WriteLine(SpeciesMenu());
            string species = FindSpecies(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine(BreedMenu(species));
            string breed = Console.ReadLine();

           
            string name = CapitiliseName("Enter animal name");

            //date of birth breakdown
            Console.WriteLine("Enter animal year of birth");
            int dobYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter animal month of birth");
            int dobMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter animal day of birth");
            int dobDay = Convert.ToInt32(Console.ReadLine());
            DateTime dob = new DateTime(dobYear, dobMonth, dobDay);

            //create a new animal object
            FarmAnimal testAnimal = new FarmAnimal(species, breed, name, dob);


            for (int day = 1; day < 8; day++)
            {
                Console.WriteLine($"Enter animal food consumption day {day}");
                testAnimal.AddDailyConsumption(Convert.ToInt32(Console.ReadLine()));
            }





            //display animal summary


            Console.WriteLine(testAnimal.AnimalSummary());



        }

        private static string SpeciesMenu()
        {

            string menu = "Choose your animal\n";
            int animalCounter = 1;

            foreach  (KeyValuePair<string, string[]> animalType in animalsDictionary)
            {
                menu += $"{animalCounter}. {animalType.Key}\n";
                animalCounter++;
            }
            return menu;
        }

        private static string FindSpecies(int menuChoice)
        {

            int speciesConter = 0;
            string foundSpeices = "";


            foreach (KeyValuePair<string, string[]> animalType in animalsDictionary)
            {
                speciesConter ++;
                if (menuChoice == speciesConter)
                {
                    foundSpeices = animalType.Key;
                    break;
                }
                Console.WriteLine(speciesConter);
            }
            
            return foundSpeices;
        }

        private static string[] GetBreed(string species)
        {
            return animalsDictionary[species];


        }

        private static string BreedMenu(string species)
        {

            string[] breeds = GetBreed(species);
            string menu = "Choose Breed\n";

            for (int breedIndex = 0; breedIndex < breeds.Length; breedIndex++)
            {

                menu += (breedIndex + 1) + ". " + breeds[breedIndex] + "\n";

            }
            return menu;
        }


        private static string CapitiliseName(string question)
        {
            while (true)
            {
                Console.WriteLine(question);

                string name = Console.ReadLine();

                if (name.Length == 0)
                    System.Console.WriteLine("Error: Names cannot be blank");
                else
                {
                    name = char.ToUpper(name[0]) + name.Substring(1);

                    return name;
                }
                    
            }
            
        }
    }
}
