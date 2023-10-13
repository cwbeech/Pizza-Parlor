/* Breadsticks.cs
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
    /// Breadsticks class.
    /// </summary>
    public class Breadsticks : Side, IMenuItem
    {
        /// <summary>
        /// The name of the Breadsticks instance.
        /// </summary>
        public override string Name { get; } = "Breadsticks";

        /// <summary>
        /// The description of the Breadsticks instance.
        /// </summary>
        public override string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// Whether this Breadsticks instance contains Cheese.
        /// </summary>
        public bool Cheese { get; set; } = false;

        /// <summary>
        /// The price of this Breadsticks instance.
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (!Cheese)
                {
                    return Count * 0.75m;
                }
                else
                {
                    return Count;
                }
            }
        }

        /// <summary>
        /// The number of calories in each stick of this Breadsticks instance.
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                uint cals = 150;

                if (Cheese) cals += 50;

                return cals;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Breadsticks.
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (Cheese)
                {
                    instructions.Add(Count + " Cheesesticks");
                }
                else
                {
                    instructions.Add(Count + " Breadsticks");
                }
                return instructions;
            }
        }
    }
}
