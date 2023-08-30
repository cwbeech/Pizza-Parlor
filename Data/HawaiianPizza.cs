/* HawaiianPizza.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The definition of the HawaiianPizza class.
    /// </summary>
    public class HawaiianPizza
    {
        /// <summary>
        /// The name of the HawaiianPizza instance.
        /// </summary>
        public string Name { get; } = "Hawaiian Pizza";

        /// <summary>
        /// The description of the HawaiianPizza instance.
        /// </summary>
        public string Description { get; } = "The pizza with pineapple";

        /// <summary>
        /// Whether this HawaiianPizza instance contains Ham.
        /// </summary>
        public bool Ham { get; set; } = true;

        /// <summary>
        /// Whether this HawaiianPizza instance contains Pineapple.
        /// </summary>
        public bool Pineapple { get; set; } = true;

        /// <summary>
        /// Whether this HawaiianPizza instance contains Onions.
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// The number of slices in this HawaiianPizza instance.
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The price of this HawaiianPizza instance.
        /// </summary>
        public decimal Price { get; } = 13.99m;

        /// <summary>
        /// The number of calories in each slice of this HawaiianPizza instance.
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 250;

                if (Ham) cals += 30;
                if (Pineapple) cals += 15;
                if (Onions) cals += 5;

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this HawaiianPizza instance.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this HawaiianPizza.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (!Ham) instructions.Add("Hold Ham");
                if (!Pineapple) instructions.Add("Hold Pineapple");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            }
        }
    }
}