/* Drink.cs
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
    /// General Drink Class.
    /// </summary>
    public abstract class Drink : IMenuItem
    {
        /// <summary>
        /// Event for property changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Helper method for derived classes.
        /// </summary>
        /// <param name="propertyName">Name of property being updated.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The Name of the Soda instance.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the Soda instance.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Private backing field for Ice.
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// Whether the Soda instance has ice.
        /// </summary>
        public virtual bool Ice
        {
            get
            {
                return _ice;
            }
            set
            {
                _ice = value;
                OnPropertyChanged(nameof(Ice));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// Private backing field for DrinkSize.
        /// </summary>
        private Size _drinkSize = Size.Medium;

        /// <summary>
        /// The size of the Soda instance.
        /// </summary>
        public virtual Size DrinkSize
        {
            get
            {
                return _drinkSize;
            }
            set
            {
                _drinkSize = value;
                OnPropertyChanged(nameof(DrinkSize));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

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

        /// <summary>
        /// Overrides the ToString() method.
        /// </summary>
        /// <returns>Returns the name of the drink.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
