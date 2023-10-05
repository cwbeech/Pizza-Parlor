/* SupremePizzaUnitTests.cs
 * Author: Calvin Beechner
 */
namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for SupremePizza.
    /// </summary>
    public class SupremePizzaUnitTests
    {
        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            SupremePizza p = new SupremePizza();
            Assert.Equal(p.Name, p.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            SupremePizza p = new SupremePizza();
            Assert.IsAssignableFrom<IMenuItem>(p);
            Assert.IsAssignableFrom<Pizza>(p);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            SupremePizza p = new SupremePizza();
            Assert.True(p.GetTopping(Topping.Sausage).OnPizza);
            Assert.True(p.GetTopping(Topping.Pepperoni).OnPizza);
            Assert.True(p.GetTopping(Topping.Olives).OnPizza);
            Assert.True(p.GetTopping(Topping.Peppers).OnPizza);
            Assert.True(p.GetTopping(Topping.Onions).OnPizza);
            Assert.True(p.GetTopping(Topping.Mushrooms).OnPizza);
            Assert.Equal(Size.Medium, p.PizzaSize);
            Assert.Equal(Crust.Original, p.PizzaCrust);
        }

        /// <summary>
        /// Tests the price.
        /// </summary>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="price">The expected price.</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, 13.99)]
        [InlineData(Size.Small, Crust.Thin, (13.99 - 2))]
        [InlineData(Size.Large, Crust.DeepDish, 13.99 + 2 + 1)]
        [InlineData(Size.Medium, Crust.DeepDish, (13.99 + 1))]
        [InlineData(Size.Small, Crust.DeepDish, (13.99 - 2 + 1))]
        public void PriceTest(Size s, Crust c, decimal price)
        {
            SupremePizza p = new SupremePizza();

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(price, p.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="sausage">Whether sausage is included.</param>
        /// <param name="pepperoni">Whether pepperoni is included.</param>
        /// <param name="olives">Whether olives are included.</param>
        /// <param name="peppers">Whether peppers are included.</param>
        /// <param name="onions">Whether onions are included.</param>
        /// <param name="mushrooms">Whether mushrooms are included.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(true, true, true, true, true, true, Size.Medium, Crust.Original, 250 + 30 + 20 + 5 + 5 + 5 + 5)]
        [InlineData(false, true, true, true, true, true, Size.Small, Crust.Thin, (uint)(0.75 * (150 + 20 + 5 + 5 + 5 + 5)))]
        [InlineData(true, false, true, true, true, true, Size.Large, Crust.DeepDish, (uint)(1.3 * (300 + 30 + 5 + 5 + 5 + 5)))]
        [InlineData(true, true, false, true, true, true, Size.Medium, Crust.Original, 250 + 30 + 20 + 5 + 5 + 5)]
        [InlineData(true, true, true, false, true, true, Size.Medium, Crust.Original, 250 + 30 + 20 + 5 + 5 + 5)]
        [InlineData(true, true, true, true, false, true, Size.Medium, Crust.Original, 250 + 30 + 20 + 5 + 5 + 5)]
        [InlineData(true, true, true, true, true, false, Size.Medium, Crust.Original, 250 + 30 + 20 + 5 + 5 + 5)]
        [InlineData(false, false, false, false, false, false, Size.Medium, Crust.Original, 250)]
        public void CaloriesTest(bool sausage, bool pepperoni, bool olives, bool peppers, bool onions, bool mushrooms, Size s, Crust c, uint cals)
        {
            SupremePizza p = new SupremePizza();

            p.GetTopping(Topping.Sausage).OnPizza = sausage;
            p.GetTopping(Topping.Pepperoni).OnPizza = pepperoni;
            p.GetTopping(Topping.Peppers).OnPizza = peppers;
            p.GetTopping(Topping.Olives).OnPizza = olives;
            p.GetTopping(Topping.Onions).OnPizza = onions;
            p.GetTopping(Topping.Mushrooms).OnPizza = mushrooms;

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(cals, p.CaloriesPerEach);
            Assert.Equal(cals * 8, p.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="sausage">Whether sausage is inluded.</param>
        /// <param name="pepperoni">Whether pepperoni is included.</param>
        /// <param name="olives">Whether olives are included.</param>
        /// <param name="peppers">Whether pepperoni is included.</param>
        /// <param name="onions">Whether onions are included.</param>
        /// <param name="mushrooms">Whether mushrooms are included.</param>
        /// <param name="s">The size fo the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, true, true, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original" })]
        [InlineData(false, true, true, true, true, true, Size.Small, Crust.Thin, new string[] { "Small", "Thin Crust", "Hold Sausage" })]
        [InlineData(true, false, true, true, true, true, Size.Large, Crust.DeepDish, new string[] { "Large", "Deep Dish", "Hold Pepperoni" })]
        [InlineData(true, true, false, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Olives" })]
        [InlineData(true, true, true, false, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Peppers" })]
        [InlineData(true, true, true, true, false, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Onions" })]
        [InlineData(true, true, true, true, true, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Mushrooms" })]
        [InlineData(false, false, false, false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Sausage", "Hold Pepperoni", "Hold Olives", "Hold Peppers", "Hold Onions" , "Hold Mushrooms" })]
        public void SpecialInstructionsTest(bool sausage, bool pepperoni, bool olives, bool peppers, bool onions, bool mushrooms, Size s, Crust c, string[] instructions)
        {
            SupremePizza p = new SupremePizza();

            p.GetTopping(Topping.Sausage).OnPizza = sausage;
            p.GetTopping(Topping.Pepperoni).OnPizza = pepperoni;
            p.GetTopping(Topping.Peppers).OnPizza = peppers;
            p.GetTopping(Topping.Olives).OnPizza = olives;
            p.GetTopping(Topping.Onions).OnPizza = onions;
            p.GetTopping(Topping.Mushrooms).OnPizza = mushrooms;

            p.PizzaSize = s;
            p.PizzaCrust = c;

            List<string> l = new List<string>();
            foreach (string item in instructions)
            {
                l.Add(item);
            }

            Assert.Equal(l, p.SpecialInstructions);
        }
    }
}