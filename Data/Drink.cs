/* Drink.cs
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
    /// General Drink Class.
    /// </summary>
    public abstract class Drink
    {
        /// <summary>
        /// The Name of the Soda instance.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the Soda instance.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Whether the Soda instance has ice.
        /// </summary>
        public virtual bool Ice { get; set; } = true;

        /// <summary>
        /// The size of the Soda instance.
        /// </summary>
        public virtual Size DrinkSize { get; set; } = Size.Medium;

        /// <summary>
        /// The price of the Soda instance.
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The amount of calories in the Soda instance.
        /// </summary>
        public abstract uint CaloriesPerEach { get; }

        /// <summary>
        /// The total number of calories in this Soda instance.
        /// </summary>
        public virtual uint CaloriesTotal { get => CaloriesPerEach; }

        /// <summary>
        /// Special instructions for the preparation of this Soda instance.
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }
    }
}
