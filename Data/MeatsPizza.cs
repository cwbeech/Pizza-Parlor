/* MeatsPizza.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// MeatsPizza Class.
    /// </summary>
    public class MeatsPizza
    {
        /// <summary>
        /// The name of the MeatsPizza instance.
        /// </summary>
        public string Name { get; } = "Meats Pizza";

        /// <summary>
        /// The description of the MeatsPizza instance.
        /// </summary>
        public string Description { get; } = "All the meats";

        /// <summary>
        /// Whether this MeatsPizza instance contains Sausage.
        /// </summary>
        public bool Sausage { get; set; } = true;

        /// <summary>
        /// Whether this MeatsPizza instance contains Pepperoni.
        /// </summary>
        public bool Pepperoni { get; set; } = true;

        /// <summary>
        /// Whether this MeatsPizza instance contains Ham.
        /// </summary>
        public bool Ham { get; set; } = true;

        /// <summary>
        /// Whether this MeatsPizza instance contains Bacan.
        /// </summary>
        public bool Bacan { get; set; } = true;

        /// <summary>
        /// The number of slices in this MeatsPizza instance.
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The price of this MeatsPizza instance.
        /// </summary>
        public decimal Price { get; } = 15.99m;

        /// <summary>
        /// The number of calories in each slice of this MeatsPizza instance.
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 250;

                if (Sausage) cals += 60;
                if (Pepperoni) cals += 30;
                if (Ham) cals += 30;
                if (Bacan) cals += 30;

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this MeatsPizza instance.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this MeatsPizza.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");
                if (!Ham) instructions.Add("Hold Ham");
                if (!Bacan) instructions.Add("Hold Bacan");
                return instructions;
            }
        }
    }
}