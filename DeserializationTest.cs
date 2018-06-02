using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DeserializationTest
{
    public class Program
    {
        string json = @"
[
    { ""type"":""Car"", ""name"":""Ford"", ""models"":[ ""Fiesta"", ""Focus"", ""Mustang"" ] },
    { ""type"":""Car"", ""name"":""BMW"", ""models"":[ ""320"", ""X3"", ""X5"" ] },
    { ""type"":""Animal"", ""name"":""Cat"", ""legs"":4 },
    { ""type"":""Car"", ""name"":""Fiat"", ""models"":[ ""500"", ""Panda"" ] },
    { ""type"":""Animal"", ""name"":""Bird"", ""legs"":2 }
]";

        public Program()
        { }

        public void Run()
        {
            Console.WriteLine("Json:");
            Console.WriteLine(json);
            Console.WriteLine();
            


            Console.WriteLine("Deserializing...");
            List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(json);
            //List<object> results = JsonConvert.DeserializeObject<List<object>>(json);

            List<Car> cars = new List<Car>();
            List<Animal> animals = new List<Animal>();
            
            foreach (dynamic obj in results)
            {
                if (obj.type == "Car")
                {
                    Car car = new Car()
                    {
                        Name = obj.name,
                        Models = obj.models.ToObject<List<string>>()
                    };

                    cars.Add(car);
                }
                else if (obj.type == "Animal")
                {
                    Animal animal = new Animal()
                    {
                        Name = obj.name,
                        Legs = obj.legs
                    };

                    animals.Add(animal);
                }
                else throw new InvalidOperationException("Found object we didn't have a representation for");
            }
            Console.WriteLine("Done");
            Console.WriteLine();

            Console.WriteLine("Result:");
            foreach (Car car in cars)
                Console.WriteLine(car);

            foreach (Animal animal in animals)
                Console.WriteLine(animal);

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public List<string> Models { get; set; }
    }

    public class Animal
    {
        public string Name { get; set; }
        public int Legs { get; set; }
    }
}