using System.Collections.Generic;
using System.Linq;
using Catagorization.Controllers;
using NUnit.Framework;
using PeopleService.Domain.Models;

namespace Catagorization.Tests
{
    [TestFixture]
    internal class PetSorterTests
    {
        [TestCase("Fluffy")]
        [TestCase("Tom")]
        [TestCase("Will")]
        [TestCase("Macy")]
        [TestCase("Babios")]
        public void Does_Sorter_Include_Cats(string name)
        {
            //arrange
            var owners = SetupData();
            var sorter = new PetSorter();

            //act
            var actual = sorter.SortByGender(owners, PetType.Cat).SelectMany(c=>c.Names).ToList();

            //assert
            Assert.Contains(name, actual);
        }

        [TestCase("Fiddo")]
        [TestCase("Flipper")]
        [TestCase("Goldy")]
        public void Does_Sorter_Include_Only_Cats(string name)
        {
            //arrange
            var owners = SetupData();
            var sorter = new PetSorter();

            //act
            var actual = sorter.SortByGender(owners, PetType.Cat).SelectMany(c => c.Names).ToList();

            //assert
            Assert.IsFalse(actual.Contains(name));
        }

        [TestCase(Gender.Male, 1)]
        [TestCase(Gender.Female, 4)]
        public void Does_Sorter_Return_Correct_Count(Gender gender, int expected)
        {
            //arrange
            var owners = SetupData();
            var sorter = new PetSorter();

            //act
            var all = sorter.SortByGender(owners, PetType.Cat);
            var count = all.First(p => p.Gender == gender).Names.Count();

            //assert
            Assert.AreEqual(expected, count);
        }
        
        [TestCase("Tom",2)]
        [TestCase("Will",3)]
        [TestCase("Macy",1)]
        [TestCase("Babios",0)]
        public void Does_Sorter_Return_Correct_Order(string name, int index)
        {
            //arrange
            var owners = SetupData();
            var sorter = new PetSorter();

            //act
            var all = sorter.SortByGender(owners, PetType.Cat);
            var names = all.First(p => p.Gender == Gender.Female).Names.ToArray();

            //assert
            Assert.AreEqual(name, names[index]);
        }

        private ICollection<Owner> SetupData()
        {
            return new List<Owner>
            {
                new Owner
                {
                    Name = "John",
                    Age = 20,
                    Gender = Gender.Male,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Fluffy",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Fiddo",
                            Type = PetType.Dog
                        }
                    }
                },
                new Owner
                {
                    Name = "Sara",
                    Age = 30,
                    Gender = Gender.Female,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Tom",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Will",
                            Type = PetType.Cat
                        }
                    }
                },
                new Owner
                {
                    Name = "Bill",
                    Age = 21,
                    Gender = Gender.Male,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Flipper",
                            Type = PetType.Fish
                        }
                    }
                },
                new Owner
                {
                    Name = "Paula",
                    Age = 10,
                    Gender = Gender.Female,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Macy",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Babios",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Goldy",
                            Type = PetType.Fish
                        }
                    },

                },
                new Owner
                {
                    Name = "Mitch",
                    Age = 78,
                    Pets = null
                }
            };
        }
    }
}