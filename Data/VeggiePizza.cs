/* VeggiePizza
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
    /// VeggiePizza class.
    /// </summary>
    public class VeggiePizza : Pizza, IMenuItem
    {
        /// <summary>
        /// The name of the VeggiePizza instance.
        /// </summary>
        public override string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// The description of the VeggiePizza instance.
        /// </summary>
        public override string Description { get; } = "All the veggies";

        /// <summary>
        /// Constructs a MeatsPizza.
        /// </summary>
        public VeggiePizza()
        {
            PossibleToppings.Clear();
            PizzaTopping olives = new PizzaTopping();
            olives.ToppingType = Topping.Olives;
            olives.OnPizza = true;
            PizzaTopping peppers = new PizzaTopping();
            peppers.ToppingType = Topping.Peppers;
            peppers.OnPizza = true;
            PizzaTopping onions = new PizzaTopping();
            onions.ToppingType = Topping.Onions;
            onions.OnPizza = true;
            PizzaTopping mushrooms = new PizzaTopping();
            mushrooms.ToppingType = Topping.Mushrooms;
            mushrooms.OnPizza = true;
            PossibleToppings.Add(olives);
            PossibleToppings.Add(peppers);
            PossibleToppings.Add(onions);
            PossibleToppings.Add(mushrooms);
            foreach (PizzaTopping topping in PossibleToppings)
            {
                topping.PropertyChanged += OnToppingChosen;
            }
        }

        /// <summary>
        /// The price of this VeggiePizza instance.
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 12.99m;

                switch (PizzaSize)
                {
                    case Size.Small:
                        price -= 2;
                        break;
                    case Size.Large:
                        price += 2;
                        break;
                    default:
                        break;
                }
                if (PizzaCrust == Crust.DeepDish)
                {
                    price += 1;
                }

                return price;
            }
        }

        /// <summary>
        /// Special instructions for the pizza.
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
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
                    if (!t.OnPizza)
                    {
                        instructions.Add("Hold " + t.Name);
                    }
                }

                return instructions;
            }
        }
    }
}
