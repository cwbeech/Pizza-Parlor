/* GarlicKnots.cs
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
    /// GarlicKnots class.
    /// </summary>
    public class GarlicKnots : Side, IMenuItem
    {
        /// <summary>
        /// The name of the GarlicKnots instance.
        /// </summary>
        public override string Name { get; } = "Garlic Knots";

        /// <summary>
        /// The description of the GarlicKnots instance.
        /// </summary>
        public override string Description { get; } = "Twisted rolls with garlic and butter";

        /// <summary>
        /// The price of this GarlicKnots instance.
        /// </summary>
        public override decimal Price
        {
            get
            {
                return Count * 0.75m;
            }
        }

        /// <summary>
        /// The number of calories in each stick of this GarlicKnots instance.
        /// </summary>
        public override uint CaloriesPerEach { get; } = 175;

        /// <summary>
        /// Special instructions for the preparation of this GarlicKnots.
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(Count + " Garlic Knots");
                return instructions;
            }
        }
    }
}

