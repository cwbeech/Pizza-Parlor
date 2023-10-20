/* IcedTea.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The definition of the IcedTea instance.
    /// </summary>
    public class IcedTea : Drink, IMenuItem
    {
        /// <summary>
        /// The Name of the IcedTea instance.
        /// </summary>
        public override string Name { get; } = "Iced Tea";

        /// <summary>
        /// The description of the IcedTea instance.
        /// </summary>
        public override string Description { get; } = "Freshly brewed sweet tea";

        /// <summary>
        /// The price of the IcedTea instance.
        /// </summary>
        public override decimal Price
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
        public override uint CaloriesPerEach
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
        public override IEnumerable<string> SpecialInstructions
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
