/* CinnamonSticks.cs
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
    /// CinnamonSticks class.
    /// </summary>
    public class CinnamonSticks
    {
        /// <summary>
        /// The name of the CinnamonSticks instance.
        /// </summary>
        public string Name { get; } = "Cinnamon Sticks";

        /// <summary>
        /// The description of the CinnamonSticks instance.
        /// </summary>
        public string Description { get; } = "Like breadsticks but for dessert";

        /// <summary>
        /// Whether this CinnamonSticks instance contains Frosting.
        /// </summary>
        public bool Frosting { get; set; } = true;

        /// <summary>
        /// The number of sticks in this CinnamonSticks instance. Private field used to hold the property's value.
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// The number of sticks in this CinnamonSticks instance.
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
        /// The price of this CinnamonSticks instance.
        /// </summary>
        public decimal Price
        {
            get
            {
                if (!Frosting)
                {
                    return Count * 0.75m;
                }
                else
                {
                    return Count * 0.90m;
                }
            }
        }

        /// <summary>
        /// The number of calories in each stick of this CinnamonSticks instance.
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 160;

                if (Frosting) cals += 30;

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this CinnamonSticks instance.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Count;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this CinnamonSticks.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(Count + " Cinnamon Sticks");
                if (!Frosting) instructions.Add("Hold Frosting");
                return instructions;
            }
        }
    }
}

