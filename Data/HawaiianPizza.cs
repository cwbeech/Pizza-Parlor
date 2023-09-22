/* HawaiianPizza.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.InteropServices;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The definition of the HawaiianPizza class.
    /// </summary>
    public class HawaiianPizza : Pizza, IMenuItem
    {
        /// <summary>
        /// The name of the HawaiianPizza instance.
        /// </summary>
        public override string Name { get; } = "Hawaiian Pizza";

        /// <summary>
        /// The description of the HawaiianPizza instance.
        /// </summary>
        public override string Description { get; } = "The pizza with pineapple";

        /// <summary>
        /// Constructs a Hawaiian Pizza.
        /// </summary>
        public HawaiianPizza()
        {
            PossibleToppings.Clear();
            PizzaTopping ham = new PizzaTopping();
            ham.ToppingType = Topping.Ham;
            ham.OnPizza = true;
            PizzaTopping pineapple = new PizzaTopping();
            pineapple.ToppingType = Topping.Pineapple;
            pineapple.OnPizza = true;
            PizzaTopping onion = new PizzaTopping();
            onion.ToppingType = Topping.Onions;
            onion.OnPizza = true;
            PossibleToppings.Add(ham);
            PossibleToppings.Add(pineapple);
            PossibleToppings.Add(onion);
        }

        /// <summary>
        /// The price of this HawaiianPizza instance.
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 13.99m;

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