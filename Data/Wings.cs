/* Wings.cs
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
    /// The definition of the Wings class.
    /// </summary>
    public class Wings
    {
        /// <summary>
        /// The name of the Wings instance
        /// </summary>
        public string Name { get; } = "Wings";

        /// <summary>
        /// The description of the Wings instance.
        /// </summary>
        public string Description { get; } = "Chicken wings tossed in sauce";

        /// <summary>
        /// Whether this Wings instance contains bone.
        /// </summary>
        public bool BoneIn { get; set; } = true;

        /// <summary>
        /// The sauce type of the Wings instance.
        /// </summary>
        public WingSauce Sauce { get; set; } = WingSauce.Medium;

        /// <summary>
        /// Private uint field for storing the Count property.
        /// </summary>
        private uint _count = 5;

        /// <summary>
        /// The number of Chicken Wings in this Wings instance.
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
                    _count = 5;
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
        /// The price of this Wings instance.
        /// </summary>
        public decimal Price
        {
            get
            {
                if (BoneIn)
                {
                    return 1.5m * Count;
                }
                else
                {
                    return 1.75m * Count;
                }
            }
        }

        /// <summary>
        /// The number of calories in each Wing.
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 125;

                if (!BoneIn) cals += 50;
                if (Sauce == WingSauce.HoneyBBQ) cals += 20;

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this Wings instance.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Count;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Wings instance.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (BoneIn)
                {
                    instructions.Add(Count + " Bone-In Wings");
                }
                else
                {
                    instructions.Add(Count + " Boneless Wings");
                }
                switch (Sauce)
                {
                    case WingSauce.Mild:
                        instructions.Add("Mild Sauce");
                        break;
                    case WingSauce.Hot:
                        instructions.Add("Hot Sauce");
                        break;
                    case WingSauce.HoneyBBQ:
                        instructions.Add("Honey BBQ Sauce");
                        break;
                    default:
                        instructions.Add("Medium Sauce");
                        break;
                }

                return instructions;
            }
        }
    }
}