using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{

    public class VillagerModel
    { 
        public List<Villager> Villagers { get; set; }
        public VillagerModel()
        {
            this.Villagers = new List<Villager>();
        }
        public Double GetAverage()
        {
            long total = 0;
            foreach (var villager in Villagers)
            {
                total += villager.TotalVillager;
            }
            return Math.Round((double) total / Villagers.Count(),1);
        }
    }

    public class Villager
    {
        public string Name { get; set; }
        public int AgeOfDeath { get; set; }
        public int YearOfDeath { get; set; }
        public long TotalVillager { get; set; }

        public Villager()
        {
            
        }

        public Villager(String name, int ageOfDeath, int yearOfDeath)
        {
            this.Name = name;
            this.AgeOfDeath = ageOfDeath;
            this.YearOfDeath = yearOfDeath;
            this.TotalVillager = GetTotalVillagers();
        }

        public int BornOnYear()
        {
            return this.YearOfDeath - this.AgeOfDeath;
        }

        public long GetValueYearPosition(int position)
        {
            if (position < 1)
            {
                return 0;
            }

            double pha = Math.Pow(1 + Math.Sqrt(5), position);
            double phb = Math.Pow(1 - Math.Sqrt(5), position);
            double div = Math.Pow(2, position) * Math.Sqrt(5);
            return (long)((pha - phb) / div);
        }

        public long GetTotalVillagers()
        {
            long result = 0;
            if (BornOnYear() > 0)
            {
                for (int i = 1; i <= BornOnYear(); i++)
                {
                    result += GetValueYearPosition(i);
                }
            }
            return result;
        }

        public Boolean IsValidData()
        {
            if (BornOnYear() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
