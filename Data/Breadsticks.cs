/* Breadsticks.cs
 * AUthor: Calvin Beechner
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
    public class Breadsticks
    {
        /// <summary>
        /// The name of the Breadsticks instance.
        /// </summary>
        public string Name { get; } = "Breadsticks";

        /// <summary>
        /// The description of the Breadsticks instance.
        /// </summary>
        public string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// Whether this Breadsticks instance contains Cheese.
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// The number of sticks in this BreadSticks instance. Private field used to hold the property's value.
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// The number of sticks in this BreadSticks instance.
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
        /// The price of this Breadsticks instance.
        /// </summary>
        public decimal Price
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
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 150;

                if (Cheese) cals += 50;

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this Breadsticks instance.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Count;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Breadsticks.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
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
