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
        /// The size of the MeatsPizza instance.
        /// </summary>
        public Size PizzaSize { get; set; } = Size.Medium;

        /// <summary>
        /// The curst of the MeatsPizza instance.
        /// </summary>
        public Crust PizzaCrust { get; set; } = Crust.Original;

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
        public decimal Price 
        {
            get
            {
                decimal price = 15.99m;

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
        /// The number of calories in each slice of this MeatsPizza instance.
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

                if (Sausage) cals += 30;
                if (Pepperoni) cals += 20;
                if (Ham) cals += 20;
                if (Bacan) cals += 20;

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

                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");
                if (!Ham) instructions.Add("Hold Ham");
                if (!Bacan) instructions.Add("Hold Bacan");

                return instructions;
            }
        }
    }
}