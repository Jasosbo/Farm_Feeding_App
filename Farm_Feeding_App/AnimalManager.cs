using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm_Feeding_App
{
    internal class AnimalManager
    {

        List<FarmAnimal> animals;


        //dictionary of the species and breeds.
        Dictionary<string, string[]> animalsDictionary = new Dictionary<string, string[]>()
        {
            {"Chicken", new string[]{"Brown", "Silkie" } } ,
            {"Duck", new string[]{"Pekin", "Silver Bantam" } } ,
            {"Alpaca", new string[]{"Suri", "Huacaya" } } ,
            {"Goat", new string[]{"Nubian", "Pygmy" } }
        };

        //parallel list for animals food weight and cost
        List<int> foodWeight = new List<int>()
        {
            20, 1, 25, 20
        };
        List<float> foodPrice = new List<float>()
        {
            33.05f, 8.49f, 50f, 37.70f
        };


        
        
        public AnimalManager()
        {
            this.animals= new List<FarmAnimal>();

        }
        public Dictionary <string, string[]> GetSpecies()
        { 
            return animalsDictionary;
        }

        // adding farm animals to a list
        public void AddAnimal(FarmAnimal newAnimal)
        {

            animals.Add(newAnimal);

        }

        public void AddConsumption(int consumption)
        {
            animals[animals.Count -1].AddDailyConsumption(consumption);
        
        }


        //calculates the food consumed be each species type
        public List<float> CalculateSpeciesFoodConsumption()
        {
            List<float> speciesConsumption = new List<float>() {0, 0, 0 ,0 };
            
            foreach (FarmAnimal farmAnimal in animals)
            {

         
                    speciesConsumption[FindSpeciesIndex(farmAnimal.GetSpecies()) ] += farmAnimal.WeeklyFoodConsumption();
           
            }
           
            return speciesConsumption;
        }

        //finds the index value of a species
        public int FindSpeciesIndex(string species)
        {
            int speciesConter = 0;


            foreach (KeyValuePair<string, string[]> animalType in animalsDictionary)
            {
                
                if (species == animalType.Key)
                {
                    
                    break;
                }
                speciesConter++;
            }

            return speciesConter;
        }




        //return a list of total cost for each species consumption

        public List<float> CalculateSpeciesConsumptionCost()
        {

            List<float> speciesConsumptionCost = new List<float>() { 0, 0, 0, 0 };

            int index = 0;

            foreach (float consumption in CalculateSpeciesFoodConsumption())
            {

                speciesConsumptionCost[index] += CalculateSpeciesFoodConsumption()[index] * foodPrice[index]/foodWeight[index];

                index++;
            }


            return speciesConsumptionCost;
            
        }

        //adds up all of the animals food consumption 
        public float totalFoodConsumed()
        {

            float totalFoodConsumed = CalculateSpeciesFoodConsumption().Sum();
            return totalFoodConsumed;

        }

        //adds up the total cost of the food consumed of all animals
        public float totalFoodCost()
        {

            float totalFoodCost = CalculateSpeciesConsumptionCost().Sum();
            return totalFoodCost;

        }


        public string AnimalsSummary()
        {
            string summary = "--- Animals Summary ---\n";

            foreach (var animal in animals)
            {
                summary+= animal.AnimalSummary() + "\n";

            }
            summary += "Species consumption\n";
            int animalIndex = 0;
            foreach(KeyValuePair<string, string[]> animal in animalsDictionary)
            {
                summary += $"{animal.Key}: {CalculateSpeciesFoodConsumption()[animalIndex]}\t${CalculateSpeciesConsumptionCost()[animalIndex]}\n";
                animalIndex++;

            }
            return summary;

        }


    }
}
