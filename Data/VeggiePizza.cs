/* VeggiePizza
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// VeggiePizza class.
    /// </summary>
    public class VeggiePizza
    {
        /// <summary>
        /// The name of the VeggiePizza instance.
        /// </summary>
        public string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// The description of the VeggiePizza instance.
        /// </summary>
        public string Description { get; } = "All the veggies";

        /// <summary>
        /// Whether this VeggiePizza instance contains Olives.
        /// </summary>
        public bool Olives { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Peppers.
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Onions.
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Mushrooms.
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// The number of slices in this VeggiePizza instance.
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The price of this VeggiePizza instance.
        /// </summary>
        public decimal Price { get; } = 12.99m;

        /// <summary>
        /// The number of calories in each slice of this VeggiePizza instance.
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 250;

                if (Olives) cals += 5;
                if (Peppers) cals += 5;
                if (Onions) cals += 5;
                if (Mushrooms) cals += 5;

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this VeggiePizza instance.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this VeggiePizza.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (!Olives) instructions.Add("Hold Olives");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Onions) instructions.Add("Hold Onions");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                return instructions;
            }
        }
    }
}
