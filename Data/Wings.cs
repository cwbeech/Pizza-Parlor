/* Wings.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The definition of the Wings class.
    /// </summary>
    public class Wings : Side, IMenuItem
    {
        /// <summary>
        /// The name of the Wings instance
        /// </summary>
        public override string Name { get; } = "Wings";

        /// <summary>
        /// The description of the Wings instance.
        /// </summary>
        public override string Description { get; } = "Chicken wings tossed in sauce";

        /// <summary>
        /// Private backing field for BoneIn property.
        /// </summary>
        private bool _boneIn = true;

        /// <summary>
        /// Whether this Wings instance contains bone.
        /// </summary>
        public bool BoneIn
        {
            get
            {
                return _boneIn;
            }
            set
            {
                _boneIn = value;
                OnPropertyChanged(nameof(BoneIn));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// Private Backing field for Sauce.
        /// </summary>
        private WingSauce _sauce = WingSauce.Medium;

        /// <summary>
        /// The sauce type of the Wings instance.
        /// </summary>
        public WingSauce Sauce
        {
            get => _sauce;
            set
            {
                _sauce = value;
                OnPropertyChanged(nameof(Sauce));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// Constructs a new Wings.
        /// </summary>
        public Wings()
        {
            _count = 5;
        }

        /// <summary>
        /// The number of Chicken Wings in this Wings instance.
        /// </summary>
        public override uint Count
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
                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// The price of this Wings instance.
        /// </summary>
        public override decimal Price
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
        public override uint CaloriesPerEach
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
        /// Special instructions for the preparation of this Wings instance.
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
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