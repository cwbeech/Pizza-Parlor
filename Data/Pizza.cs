﻿/* Pizza.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// General Pizza Class.
    /// </summary>
    public class Pizza : IMenuItem
    {
        /// <summary>
        /// Name of the pizza.
        /// </summary>
        public virtual string Name { get; } = "Build-Your-Own Pizza";

        /// <summary>
        /// Description of the pizza.
        /// </summary>
        public virtual string Description { get; } = "A pizza you get to build";

        /// <summary>
        /// The number of slices in the pie.
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The size of the pizza.
        /// </summary>
        public Size PizzaSize { get; set; } = Size.Medium;

        /// <summary>
        /// The crust type of the pizza.
        /// </summary>
        public Crust PizzaCrust { get; set; } = Crust.Original;

        /// <summary>
        /// List of the possible toppings.
        /// </summary>
        public virtual List<PizzaTopping> PossibleToppings { get; } = new List<PizzaTopping>();

        public Pizza()
        {
            PizzaTopping sausage = new PizzaTopping();
            sausage.ToppingType = Topping.Sausage;
            sausage.OnPizza = false;
            PizzaTopping pepperoni = new PizzaTopping();
            pepperoni.ToppingType = Topping.Pepperoni;
            pepperoni.OnPizza = false;
            PizzaTopping ham = new PizzaTopping();
            ham.ToppingType = Topping.Ham;
            ham.OnPizza = false;
            PizzaTopping bacon = new PizzaTopping();
            bacon.ToppingType = Topping.Bacon;
            bacon.OnPizza = false;
            PizzaTopping olives = new PizzaTopping();
            olives.ToppingType = Topping.Olives;
            olives.OnPizza = false;
            PizzaTopping peppers = new PizzaTopping();
            peppers.ToppingType = Topping.Peppers;
            peppers.OnPizza = false;
            PizzaTopping onions = new PizzaTopping();
            onions.ToppingType = Topping.Onions;
            onions.OnPizza = false;
            PizzaTopping mushrooms = new PizzaTopping();
            mushrooms.ToppingType = Topping.Mushrooms;
            mushrooms.OnPizza = false;
            PizzaTopping pineapple = new PizzaTopping();
            pineapple.ToppingType = Topping.Pineapple;
            pineapple.OnPizza = false;
            PossibleToppings.Add(sausage);
            PossibleToppings.Add(pepperoni);
            PossibleToppings.Add(ham);
            PossibleToppings.Add(bacon);
            PossibleToppings.Add(olives);
            PossibleToppings.Add(onions);
            PossibleToppings.Add(mushrooms);
            PossibleToppings.Add(peppers);
            PossibleToppings.Add(pineapple);
        }

        /// <summary>
        /// Price of the pizza.
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                decimal price = 0;

                switch (PizzaSize)
                {
                    case Size.Small:
                        price += 7.99m;
                        break;
                    case Size.Medium:
                        price += 9.99m;
                        break;
                    case Size.Large:
                        price += 11.99m;
                        break;
                }

                if (PizzaCrust == Crust.DeepDish) { price += 1; }

                foreach (PizzaTopping t in PossibleToppings)
                {
                    if (t.OnPizza)
                    {
                        price += 1m;
                    }
                }

                return price;
            }
        }

        /// <summary>
        /// Calories per slice of the pizza.
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 0;

                switch (PizzaCrust)
                {
                    case Crust.Thin:
                        cals += 150;
                        break;
                    case Crust.Original:
                        cals += 250;
                        break;
                    case Crust.DeepDish:
                        cals += 300;
                        break;
                }

                foreach (PizzaTopping t in PossibleToppings)
                {
                    if (t.OnPizza)
                    {
                        cals += t.BaseCalories;
                    }
                }

                switch (PizzaSize)
                {
                    case Size.Small:
                        cals = (uint)(cals * .75);
                        break;
                    case Size.Large:
                        cals = (uint)(cals * 1.3);
                        break;
                }

                return cals;
            }
        }

        /// <summary>
        /// Total calories of the pie.
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the pizza.
        /// </summary>
        public virtual IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                
                switch (PizzaSize)
                {
                    case Size.Small:
                        instructions.Add("Small");
                        break;
                    case Size.Medium:
                        instructions.Add("Medium");
                        break;
                    case Size.Large:
                        instructions.Add("Large");
                        break;
                }
                
                switch (PizzaCrust)
                {
                    case Crust.Thin:
                        instructions.Add("Thin Crust");
                        break;
                    case Crust.Original:
                        instructions.Add("Original");
                        break;
                    case Crust.DeepDish:
                        instructions.Add("Deep Dish");
                        break;
                }
                
                foreach (PizzaTopping t in PossibleToppings)
                {
                    if (t.OnPizza)
                    {
                        instructions.Add("Add " + t.Name);
                    }
                }

                return instructions;
            }
        }

        /// <summary>
        /// Returns the topping from the pizza.
        /// </summary>
        /// <param name="topping">The topping being searched for.</param>
        /// <returns>The PizzaTopping found.</returns>
        /// <exception cref="ArgumentException">If topping cannot be found.</exception>
        public PizzaTopping GetTopping(Topping topping)
        {
            foreach (PizzaTopping t in PossibleToppings)
            {
                if (t.ToppingType == topping)
                {
                    return t;
                }
            }
            throw new ArgumentException("Missing Topping");
        }
    }
}