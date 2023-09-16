using System.Drawing;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The definition of the SupremePizza class.
    /// </summary>
    public class SupremePizza
    {
        /// <summary>
        /// The size of the SupremePizza instance.
        /// </summary>
        public Size PizzaSize { get; set; } = Size.Medium;

        /// <summary>
        /// The curst of the SupremePizza instance.
        /// </summary>
        public Crust PizzaCrust { get; set; } = Crust.Original;

        /// <summary>
        /// The name of the SupremePizza instance
        /// </summary>
        public string Name { get; } = "Supreme Pizza";

        /// <summary>
        /// The description of the SupremePizza instance
        /// </summary>
        public string Description => "Your standard supreme with meats and veggies";

        /// <summary>
        /// Whether this SupremePizza instance contains sausage
        /// </summary>
        public bool Sausage { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains pepperoni
        /// </summary>
        public bool Pepperoni { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains olives
        /// </summary>
        public bool Olives { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains peppers
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains mushrooms
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// The number of slices in this SupremePizza instance
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The price of this SupremePizza instance
        /// </summary>
        public decimal Price
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
        /// The number of calories in each slice of this SupremePizza instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint crust;

                switch (PizzaCrust)
                {
                    case Crust.Thin:
                        crust = 150;
                        break;
                    case Crust.DeepDish:
                        crust = 300;
                        break;
                    default:
                        crust = 250;
                        break;
                }

                uint cals = crust;

                if (Sausage) cals += 30;
                if (Pepperoni) cals += 20;
                if (Olives) cals += 5;
                if (Peppers) cals += 5;
                if (Onions) cals += 5;
                if (Mushrooms) cals += 5;

                switch (PizzaSize)
                {
                    case Size.Small:
                        cals = (uint)(cals * .75);
                        break;
                    case Size.Large:
                        cals = (uint)(cals * 1.3);
                        break;
                    default:
                        break;
                }

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this SupremePizza instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                //all pizzas have 8 slices

                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this FlyingSaucer
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                switch (PizzaSize)
                {
                    case Size.Small:
                        instructions.Add("Small");
                        break;
                    case Size.Large:
                        instructions.Add("Large");
                        break;
                    default:
                        instructions.Add("Medium");
                        break;
                }
                switch (PizzaCrust)
                {
                    case Crust.Thin:
                        instructions.Add("Thin Crust");
                        break;
                    case Crust.DeepDish:
                        instructions.Add("Deep Dish");
                        break;
                    default:
                        instructions.Add("Original");
                        break;
                }

                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");
                if (!Olives) instructions.Add("Hold Olives");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Onions) instructions.Add("Hold Onions");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");

                return instructions;
            }
        }
    }
}