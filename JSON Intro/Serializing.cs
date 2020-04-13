/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu 
 */
using JSONandAPIs;
using System;


namespace JSON_Intro
{
    class Serializing
    {
        /// <summary>
        /// Demonstrate code that converts an object to as JSON string, saves it to a file, and reads it back into a new object of the same type
        /// </summary>
        public static void Demo()
        {
            String[] quality = { "organic", "free range", "pesticide-free" };
            Fruit fruit = new Fruit("Apple",
                                    10,
                                    Convert.ToDateTime("1/1/2020 4:00:00 PM"),
                                    Fruit.enumCondition.ripe,
                                    quality);
            Console.WriteLine("Serializing fruit object TO JSON file: " + fruit.ToString());
            JSONSerializeTools.Serialize(fruit, "fruit.json");

            Fruit newFruit = (Fruit) JSONSerializeTools.Deserialize<Fruit>("fruit.json");
            Console.WriteLine("Deserializing Fruit object from JSON file: " + newFruit.ToString());

        }
    }
}
