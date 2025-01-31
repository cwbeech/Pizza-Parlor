﻿/* PizzaTopping.cs
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
    /// Pizza Topping class.
    /// </summary>
    public class PizzaTopping : INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Private backing field for ToppingType.
        /// </summary>
        private Topping _toppingType;

        /// <summary>
        /// The type of topping.
        /// </summary>
        public Topping ToppingType
        {
            get
            {
                return _toppingType;
            }
            set
            {
                _toppingType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToppingType)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BaseCalories)));
            }
        }

        /// <summary>
        /// Private backing field for OnPizza.
        /// </summary>
        private bool _onPizza;

        /// <summary>
        /// Whether the topping is on pizza.
        /// </summary>
        public bool OnPizza
        {
            get
            {
                return _onPizza;
            }
            set
            {
                _onPizza = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OnPizza)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BaseCalories)));
            }
        }

        /// <summary>
        /// The name of the topping.
        /// </summary>
        public string Name
        {
            get
            {
                switch (ToppingType)
                {
                    case Topping.Sausage:
                        return "Sausage";
                    case Topping.Pepperoni:
                        return "Pepperoni";
                    case Topping.Ham:
                        return "Ham";
                    case Topping.Bacon:
                        return "Bacon";
                    case Topping.Olives:
                        return "Olives";
                    case Topping.Onions:
                        return "Onions";
                    case Topping.Mushrooms:
                        return "Mushrooms";
                    case Topping.Peppers:
                        return "Peppers";
                    case Topping.Pineapple:
                        return "Pineapple";
                }
                return "Topping doesn't exist";
            }
        }

        /// <summary>
        /// The number of calories for the topping.
        /// </summary>
        public uint BaseCalories
        {
            get
            {
                if (ToppingType == Topping.Sausage)
                {
                    return 30;
                }
                else if (ToppingType == Topping.Pepperoni || ToppingType == Topping.Ham || ToppingType == Topping.Bacon)
                {
                    return 20;
                }
                else if (ToppingType == Topping.Pineapple)
                {
                    return 10;
                }
                else
                {
                    return 5;
                }
            }
        }
    }
}
