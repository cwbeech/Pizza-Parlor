using System.Drawing;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The definition of the SupremePizza class.
    /// </summary>
    public class SupremePizza : Pizza, IMenuItem
    {
        /// <summary>
        /// The name of the SupremePizza instance
        /// </summary>
        public override string Name { get; } = "Supreme Pizza";

        /// <summary>
        /// The description of the SupremePizza instance
        /// </summary>
        public override string Description => "Your standard supreme with meats and veggies";

        /// <summary>
        /// Constructs a MeatsPizza.
        /// </summary>
        public SupremePizza()
        {
            PossibleToppings.Clear();
            PizzaTopping sausage = new PizzaTopping();
            sausage.ToppingType = Topping.Sausage;
            sausage.OnPizza = true;
            PizzaTopping pepperoni = new PizzaTopping();
            pepperoni.ToppingType = Topping.Pepperoni;
            pepperoni.OnPizza = true;
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
            PossibleToppings.Add(sausage);
            PossibleToppings.Add(pepperoni);
            PossibleToppings.Add(olives);
            PossibleToppings.Add(peppers);
            PossibleToppings.Add(onions);
            PossibleToppings.Add(mushrooms);
        }

        /// <summary>
        /// The price of this SupremePizza instance
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