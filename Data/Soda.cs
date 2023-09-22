/* Soda.cs
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
    /// The definition of the Soda instance
    /// </summary>
    public class Soda : Drink, IMenuItem
    {
        /// <summary>
        /// The Name of the Soda instance.
        /// </summary>
        public override string Name { get; } = "Soda";

        /// <summary>
        /// The description of the Soda instance.
        /// </summary>
        public override string Description { get; } = "Standard fountain drink";

        /// <summary>
        /// The flavor of the Soda instance
        /// </summary>
        public SodaFlavor DrinkType { get; set; } = SodaFlavor.Coke;

        /// <summary>
        /// The price of the Soda instance.
        /// </summary>
        public override decimal Price
        {
            get
            {
                switch (DrinkSize)
                {
                    case Size.Small:
                        return 1.5m;
                    case Size.Large:
                        return 2.5m;
                    default:
                        return 2m;
                }
            }
        }

        /// <summary>
        /// The amount of calories in the Soda instance.
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                if (DrinkType == SodaFlavor.DietCoke)
                {
                    return 0;
                }
                else
                {
                    switch (DrinkSize)
                    {
                        case Size.Small:
                            return 150;
                        case Size.Large:
                            return 250;
                        default:
                            return 200;
                    }
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Soda instance.
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
                switch (DrinkType)
                {
                    case SodaFlavor.DietCoke:
                        instructions.Add("Diet Coke");
                        break;
                    case SodaFlavor.DrPepper:
                        instructions.Add("Dr. Pepper");
                        break;
                    case SodaFlavor.Sprite:
                        instructions.Add("Sprite");
                        break;
                    case SodaFlavor.RootBeer:
                        instructions.Add("Root Beer");
                        break;
                    default:
                        instructions.Add("Coke");
                        break;
                }
                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }
    }
}
