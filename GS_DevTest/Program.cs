using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace GS_DevTest
{
    class Program
    {
        static void Main(string[] args)
        {
            VillagerModel villagerModel = new VillagerModel();
            do
            {
                Console.Clear();
                Console.Write("Name: ");
                String inputName = Console.ReadLine();
                Console.Write("Enter Age of Death: ");
                String inputAoD = ValidateInput(Console.ReadLine());
                Console.Write("Enter Year of Death: ");
                String inputYoD = ValidateInput(Console.ReadLine());

                Villager villager = new Villager(inputName,int.Parse(inputAoD),int.Parse(inputYoD));
                if (villager.IsValidData())
                {
                    villagerModel.Villagers.Add(villager);
                }
                else
                {
                    Console.WriteLine("Your data not valid,Please input Year of Death must be greater than Age of Death.");
                }
                Console.WriteLine("Press Y to enter another person, other key to generate the data.");

            } while (Console.ReadKey().Key == ConsoleKey.Y);
            GenerateDataAverage(villagerModel);
        }

        private static void GenerateDataAverage(VillagerModel villagers)
        {
            if (villagers.Villagers.Count > 1)
            {
                Console.WriteLine(GenerateAverageString(villagers));
                Console.WriteLine("Press any key to stop");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("lack of data, the data must be more than one");
                Console.WriteLine("Press any key to stop");
                Console.ReadLine();
            }
        }

        private static string ValidateInput(string input)
        {
            while (!int.TryParse(input, out int X))
            {
                Console.WriteLine("Not a valid number, try again.");
                input = Console.ReadLine();
            }
            return input;
        }

        public static String GenerateAverageString(VillagerModel villagers)
        {
            StringBuilder sb = new StringBuilder();
            List<String> sum = new List<string>();
            foreach (var villager in villagers.Villagers)
            {
                sb.AppendLine($"Person {villager.Name} born on Year {villager.YearOfDeath} - {villager.AgeOfDeath} = {villager.BornOnYear()}, number of people killed on year {villager.BornOnYear()} is {villager.TotalVillager} ");
                sum.Add(villager.TotalVillager.ToString());
            }

            sb.AppendLine($"So the average is ( {String.Join(" + ",sum)} )/{sum.Count()} = {villagers.GetAverage()}");
            return sb.ToString();
        }
    }
}
