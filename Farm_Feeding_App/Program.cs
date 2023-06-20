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


       static AnimalManager animalManager = new AnimalManager();

        public static void Main(string[] args)
        {

           

            //ask and store animal details
            

            Console.WriteLine(SpeciesMenu());
            string species = FindSpecies(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine(BreedMenu(species));
            string breed = Console.ReadLine();

           
            string name = CapitiliseName("Enter animal name");

            //date of birth breakdown
            
            int dobYear = CheckInt("Enter animal year of birth", 2000, DateTime.Now.Year);

            
            int dobMonth = CheckInt("Enter animal month of birth", 1, 12);

            
            int dobDay = CheckInt("Enter animal day of birth", 1, 31);

            DateTime dob = new DateTime(dobYear, dobMonth, dobDay);

            //create a new animal object
            FarmAnimal testAnimal = new FarmAnimal(species, breed, name, dob);

            animalManager.AddAnimal(testAnimal);


            for (int day = 1; day < 8; day++)
            {
                Console.WriteLine($"Enter animal food consumption day {day}");
                animalManager.AddConsumption(Convert.ToInt32(Console.ReadLine()));
            }


            animalManager.AddAnimal(new FarmAnimal("Duck", "Pekin", "Fred", new DateTime(2021,4,25)));


            //display animal summary


            Console.WriteLine(animalManager.AnimalsSummary());



        }
        //ask user to pick a species from a menu
        private static string SpeciesMenu()
        {

            string menu = "Choose your animal\n";
            int animalCounter = 1;

            foreach  (KeyValuePair<string, string[]> animalType in animalManager.GetSpecies())
            {
                menu += $"{animalCounter}. {animalType.Key}\n";
                animalCounter++;
            }
            return menu;
        }
        //convert users int choice to a string of the speices choice (1. chicken= user input = 1 now stored as "chicken" not 1)
        private static string FindSpecies(int menuChoice)
        {

            int speciesConter = 0;
            string foundSpeices = "";


            foreach (KeyValuePair<string, string[]> animalType in animalManager.GetSpecies())
            {
                speciesConter++;
                if (menuChoice == speciesConter)
                {
                    foundSpeices = animalType.Key;
                    break;
                }

            }

            return foundSpeices;
        }

        //get the breeds according to the species choice
        private static string[] GetBreed(string species)
        {
            return animalManager.GetSpecies()[species];


        }

        //ask user to pick the speices breed from a menu
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

        //capitilsie the name of the animal and error if blank is entered
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

        private static int CheckInt(string question, int min, int max)
        { 
            
            while(true)
            {
                try
                {
                    Console.WriteLine(question);
                    int userint = int.Parse(Console.ReadLine());

                    if (userint>= min && userint <= max)
                    {
                       return userint;
                    }
                    Console.WriteLine($"ERROR: Enter a number between {min} & {max} ");

                }
                catch (Exception)
                {

                    Console.WriteLine($"ERROR: Enter a number between {min} & {max} ");

                }
            }

        }
    }
}
