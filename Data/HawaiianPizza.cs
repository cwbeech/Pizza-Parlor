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
        /// The size of the HawaiianPizza instance.
        /// </summary>
        public Size PizzaSize { get; set; } = Size.Medium;

        /// <summary>
        /// The curst of the HawaiianPizza instance.
        /// </summary>
        public Crust PizzaCrust { get; set; } = Crust.Original;

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
        public decimal Price
        {
            get
            {
                decimal price = 13.99m;

                switch (PizzaSize)
                {
                    case Size.Small:
                        price -= 2;
                        break;
                    case Size.Large:
                        price += 2;
                        break;
                    default:
                        break;
                }
                if (PizzaCrust == Crust.DeepDish)
                {
                    price += 1;
                }

                return price;
            }
        }

        /// <summary>
        /// The number of calories in each slice of this HawaiianPizza instance.
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint crust;

                switch (PizzaCrust)
                {
                    case Crust.Thin:
                        crust = 150;
                        break;
                    case Crust.DeepDish:
                        crust = 300;
                        break;
                    default:
                        crust = 250;
                        break;
                }

                uint cals = crust;

                if (Ham) cals += 20;
                if (Pineapple) cals += 10;
                if (Onions) cals += 5;

                switch (PizzaSize)
                {
                    case Size.Small:
                        cals = (uint)(cals * .75);
                        break;
                    case Size.Large:
                        cals = (uint)(cals * 1.3);
                        break;
                    default:
                        break;
                }

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

                switch (PizzaSize)
                {
                    case Size.Small:
                        instructions.Add("Small");
                        break;
                    case Size.Large:
                        instructions.Add("Large");
                        break;
                    default:
                        instructions.Add("Medium");
                        break;
                }
                switch (PizzaCrust)
                {
                    case Crust.Thin:
                        instructions.Add("Thin Crust");
                        break;
                    case Crust.DeepDish:
                        instructions.Add("Deep Dish");
                        break;
                    default:
                        instructions.Add("Original");
                        break;
                }

                if (!Ham) instructions.Add("Hold Ham");
                if (!Pineapple) instructions.Add("Hold Pineapple");
                if (!Onions) instructions.Add("Hold Onions");

                return instructions;
            }
        }
    }
}