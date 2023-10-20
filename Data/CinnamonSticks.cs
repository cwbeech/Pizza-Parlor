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
    public class CinnamonSticks : Side, IMenuItem
    {
        /// <summary>
        /// The name of the CinnamonSticks instance.
        /// </summary>
        public override string Name { get; } = "Cinnamon Sticks";

        /// <summary>
        /// The description of the CinnamonSticks instance.
        /// </summary>
        public override string  Description { get; } = "Like breadsticks but for dessert";

        /// <summary>
        /// Private backing field for Frosting.
        /// </summary>
        private bool _frosting = true;

        /// <summary>
        /// Whether this CinnamonSticks instance contains Frosting.
        /// </summary>
        public bool Frosting
        {
            get
            {
                return _frosting;
            }
            set
            {
                _frosting = value;
                OnPropertyChanged(nameof(Frosting));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of this CinnamonSticks instance.
        /// </summary>
        public override decimal Price
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
        public override uint CaloriesPerEach
        {
            get
            {
                uint cals = 160;

                if (Frosting) cals += 30;

                return cals;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this CinnamonSticks.
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
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

