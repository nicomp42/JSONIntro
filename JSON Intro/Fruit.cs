/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu 
 */
using System;
using System.Linq;

namespace JSONandAPIs
{
    class Fruit
    {
        /// <summary>
        /// Name of the fruit
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// Weight of fruit in ounces
        /// </summary>
        public int weightOunces { get; set; }
        /// <summary>
        /// Date/Time the Fruit was picked/harvested
        /// </summary>
        public DateTime datePicked { get; set; }
        /// <summary>
        /// Enumerated data type for the condition of the fruit
        /// </summary>
        public enum enumCondition { unripe, ripe, overripe, rotted };
        public enumCondition condition { get; set; }

        public String[] quality { get; set; }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weightOunces"></param>
        /// <param name="datePicked"></param>
        public Fruit(String name, int weightOunces, DateTime datePicked, enumCondition conditionm, String[] quality)
        {
            this.name = name;
            this.weightOunces = weightOunces;
            this.datePicked = datePicked;
            this.condition = condition;
            this.quality = quality.ToArray();
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Fruit() { }
        /// <summary>
        /// Standard ToString
        /// </summary>
        /// <returns>String representation of the object</returns>
        override public String ToString()
        {
            return this.name + ", " + this.weightOunces + " ounces, " + this.datePicked.ToString() +
                   ", condition = " + condition + " quality = " + "[" + string.Join(", ", quality) + "]";
        }
    }
}
