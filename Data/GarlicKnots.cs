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
    public class GarlicKnots
    {
        /// <summary>
        /// The name of the GarlicKnots instance.
        /// </summary>
        public string Name { get; } = "Garlic Knots";

        /// <summary>
        /// The description of the GarlicKnots instance.
        /// </summary>
        public string Description { get; } = "Twisted rolls with garlic and butter";

        /// <summary>
        /// The number of knots in this GarlicKnots instance. Private field used to hold the property's value.
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// The number of knots in this GarlicKnots instance.
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value < 4)
                {
                    _count = 8;
                }
                else if (value > 12)
                {
                    _count = 12;
                }
                else
                {
                    _count = value;
                }
            }
        }

        /// <summary>
        /// The price of this GarlicKnots instance.
        /// </summary>
        public decimal Price
        {
            get
            {
                return Count * 0.75m;
            }
        }

        /// <summary>
        /// The number of calories in each stick of this GarlicKnots instance.
        /// </summary>
        public uint CaloriesPerEach { get; } = 175;

        /// <summary>
        /// The total number of calories in this GarlicKnots instance.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Count;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this GarlicKnots.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
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

