/* IMenuItem.cs
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
    /// MenuItem Interface.
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Name of the item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of the item.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Price of the item.
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Calories per each item.
        /// </summary>
        uint CaloriesPerEach { get; }

        /// <summary>
        /// Total calories for item.
        /// </summary>
        uint CaloriesTotal { get; }

        /// <summary>
        /// Special instructions for the item.
        /// </summary>
        IEnumerable<string> SpecialInstructions { get; }
    }
}
