/* IcedTea.cs
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
    /// The definition of the IcedTea instance.
    /// </summary>
    public class IcedTea
    {
        /// <summary>
        /// The Name of the IcedTea instance.
        /// </summary>
        public String Name { get; } = "Iced Tea";

        /// <summary>
        /// The description of the IcedTea instance.
        /// </summary>
        public String Description { get; } = "Freshly brewed sweet tea";

        /// <summary>
        /// Whether the IcedTea instance has ice.
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// The size of the IcedTea instance.
        /// </summary>
        public Size DrinkSize { get; set; } = Size.Medium;

        /// <summary>
        /// The price of the IcedTea instance.
        /// </summary>
        public decimal Price
        {
            get
            {
                switch (DrinkSize)
                {
                    case Size.Small:
                        return 2m;
                    case Size.Large:
                        return 3m;
                    default:
                        return 2.5m;
                }
            }
        }

        /// <summary>
        /// The amount of calories in the IcedTea instance.
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (DrinkSize)
                {
                    case Size.Small:
                        return 175;
                    case Size.Large:
                        return 275;
                    default:
                        return 220;
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this IcedTea instance.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                switch (DrinkSize)
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
                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }
    }
}
