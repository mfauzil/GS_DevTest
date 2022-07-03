using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GS_DevTest.Testing
{
    public class Core
    {
        [Fact]
        public void VillagerIsValidDataTrue_PassingTest()
        {
            //Arange
            
            //Act
            Villager villager = new Villager("A", 12, 15);
            //Assert
            Assert.True(villager.IsValidData());
        }

        [Fact]
        public void VillagerIsValidDataFalse_PassingTest()
        {
            //Arange
            Boolean expected = false;
            //Act
            Villager villager = new Villager("A", 15, 12);
            //Assert
            Assert.Equal(expected,villager.IsValidData());
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(11, 89)]
        public void GetValueYearPositionLogic_PassingTest(int position, long expected)
        {
            //Arange
            
            //Act
            Villager villager = new Villager();
            long actual = villager.GetValueYearPosition(position);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(-11, 0)]
        public void GetValueYearPositionZeroExpected_PassingTest(int position, long expected)
        {
            //Arange

            //Act
            Villager villager = new Villager();
            long actual = villager.GetValueYearPosition(position);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(1, 3, 2)]
        [InlineData(1, 4, 4)]
        [InlineData(1, 5, 7)]
        [InlineData(1, 6, 12)]
        [InlineData(1, 7, 20)]
        [InlineData(1, 12, 232)]
        public void GetTotalVillagers_PassingTest(int AgeOfDeath, int YearOfDeath, long expected)
        {
            //Arange

            //Act
            Villager villager = new Villager("A", AgeOfDeath,YearOfDeath);
            long actual = villager.GetTotalVillagers();
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(1, 3, 2)]
        [InlineData(1, 4, 3)]
        [InlineData(1, 5, 4)]
        [InlineData(1, 6, 5)]
        [InlineData(1, -7, -8)]
        [InlineData(1, -12, -13)]
        public void BornOnYearNoCrash_PassingTest(int AgeOfDeath, int YearOfDeath, long expected)
        {
            //Arange

            //Act
            Villager villager = new Villager("A", AgeOfDeath, YearOfDeath);
            long actual = villager.BornOnYear();
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAverageWith2Person_PassingTest()
        {
            //Arange
            VillagerModel villagerModel = new VillagerModel();
            Villager villager = new Villager("A", 10, 12);
            villagerModel.Villagers.Add(villager);
            villager = new Villager("B", 13, 17);
            villagerModel.Villagers.Add(villager);
            double expected = 4.5;
            //Act
            double actual = villagerModel.GetAverage();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAverageWith3Person_PassingTest()
        {
            //Arange
            VillagerModel villagerModel = new VillagerModel();
            Villager villager = new Villager("A", 10, 12);
            villagerModel.Villagers.Add(villager);
            villager = new Villager("B", 13, 17);
            villagerModel.Villagers.Add(villager);
            villager = new Villager("B", 15, 19);
            villagerModel.Villagers.Add(villager);
            double expected = 5.3;
            //Act
            double actual = villagerModel.GetAverage();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
