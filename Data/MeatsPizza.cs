/* MeatsPizza.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// MeatsPizza Class.
    /// </summary>
    public class MeatsPizza : Pizza, IMenuItem
    {
        /// <summary>
        /// The name of the MeatsPizza instance.
        /// </summary>
        public override string Name { get; } = "Meats Pizza";

        /// <summary>
        /// The description of the MeatsPizza instance.
        /// </summary>
        public override string Description { get; } = "All the meats";

        /// <summary>
        /// Constructs a MeatsPizza.
        /// </summary>
        public MeatsPizza()
        {
            PossibleToppings.Clear();
            PizzaTopping sausage = new PizzaTopping();
            sausage.ToppingType = Topping.Sausage;
            sausage.OnPizza = true;
            PizzaTopping pepperoni = new PizzaTopping();
            pepperoni.ToppingType = Topping.Pepperoni;
            pepperoni.OnPizza = true;
            PizzaTopping ham = new PizzaTopping();
            ham.ToppingType = Topping.Ham;
            ham.OnPizza = true;
            PizzaTopping bacon = new PizzaTopping();
            bacon.ToppingType = Topping.Bacon;
            bacon.OnPizza = true;
            PossibleToppings.Add(sausage);
            PossibleToppings.Add(pepperoni);
            PossibleToppings.Add(ham);
            PossibleToppings.Add(bacon);
            foreach (PizzaTopping topping in PossibleToppings)
            {
                topping.PropertyChanged += OnToppingChosen;
            }
        }

        /// <summary>
        /// The price of this MeatsPizza instance.
        /// </summary>
        public override decimal Price 
        {
            get
            {
                decimal price = 15.99m;

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