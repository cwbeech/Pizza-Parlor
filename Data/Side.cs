/* Side.cs
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
    /// Abstract side class.
    /// </summary>
    public abstract class Side : IMenuItem
    {
        /// <summary>
        /// Name of the side.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Description of the side.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The number of sticks in this Side instance. Private field used to hold the property's value.
        /// </summary>
        protected uint _count = 8;

        /// <summary>
        /// The number of sticks in this Side instance.
        /// </summary>
        public virtual uint Count
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
        /// Price of the side.
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Calories per side item.
        /// </summary>
        public abstract uint CaloriesPerEach { get; }

        /// <summary>
        /// Calories per side.
        /// </summary>
        public virtual uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Count;
            }
        }

        /// <summary>
        /// Special Instructions for the side.
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }
    }
}
