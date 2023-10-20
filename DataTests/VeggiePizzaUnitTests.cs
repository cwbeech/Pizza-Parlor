/* VeggiePizzaUnitTests.cs
 * Author: Calvin Beechner
 */
using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for VeggiePizza.
    /// </summary>
    public class VeggiePizzaUnitTests
    {
        /// <summary>
        /// Tests that changing the crust notifies the effected properties.
        /// </summary>
        /// <param name="crust">Crust value.</param>
        /// <param name="propertyName">The name of the property effected.</param>
        [Theory]
        [InlineData(Crust.Original, "PizzaCrust")]
        [InlineData(Crust.Thin, "Price")]
        [InlineData(Crust.DeepDish, "SpecialInstructions")]
        [InlineData(Crust.Thin, "CaloriesPerEach")]
        [InlineData(Crust.Original, "CaloriesTotal")]
        public void ChangingPizzaCrustShouldNotifyOfPropertyChange(Crust crust, string propertyName)
        {
            VeggiePizza p = new VeggiePizza();
            Assert.PropertyChanged(p, propertyName, () =>
            {
                p.PizzaCrust = crust;
            });
        }

        /// <summary>
        /// Tests that changing the size notifies the effected properties.
        /// </summary>
        /// <param name="size">Size value.</param>
        /// <param name="propertyName">The name of the property effected.</param>
        [Theory]
        [InlineData(Size.Medium, "PizzaSize")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Small, "SpecialInstructions")]
        [InlineData(Size.Large, "CaloriesPerEach")]
        [InlineData(Size.Medium, "CaloriesTotal")]
        public void ChangingPizzaSizeShouldNotifyOfPropertyChange(Size size, string propertyName)
        {
            VeggiePizza p = new VeggiePizza();
            Assert.PropertyChanged(p, propertyName, () =>
            {
                p.PizzaSize = size;
            });
        }

        /// <summary>
        /// Tests that the MenuItem implements INotifyPropertyChanged.
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            VeggiePizza p = new VeggiePizza();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(p);
        }

        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            VeggiePizza p = new VeggiePizza();
            Assert.Equal(p.Name, p.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            VeggiePizza p = new VeggiePizza();
            Assert.IsAssignableFrom<IMenuItem>(p);
            Assert.IsAssignableFrom<Pizza>(p);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>

        [Fact]
        public void InitSetTrue()
        {
            VeggiePizza p = new VeggiePizza();
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
        [InlineData(Size.Medium, Crust.Original, 12.99)]
        [InlineData(Size.Small, Crust.Thin, (12.99 - 2))]
        [InlineData(Size.Large, Crust.DeepDish, 12.99 + 2 + 1)]
        [InlineData(Size.Medium, Crust.DeepDish, (12.99 + 1))]
        [InlineData(Size.Small, Crust.DeepDish, (12.99 - 2 + 1))]
        public void PriceTest(Size s, Crust c, decimal price)
        {
            VeggiePizza p = new VeggiePizza();

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(price, p.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="olives">Whether olives are included.</param>
        /// <param name="peppers">Whether peppers are included.</param>
        /// <param name="onions">Whether onions are included.</param>
        /// <param name="mushrooms">Whether mushrooms are included.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(true, true, true, true, Size.Medium, Crust.Original, (250 + (5 * 4)))]
        [InlineData(true, true, true, true, Size.Small, Crust.Thin, (uint)(.75*(150 + (5 * 4))))]
        [InlineData(true, true, true, true, Size.Large, Crust.DeepDish, (uint)(1.3*(300 + (5 * 4))))]
        [InlineData(false, true, true, true, Size.Medium, Crust.Original, (250 + (5 * 3)))]
        [InlineData(true, false, true, true, Size.Medium, Crust.Original, (250 + (5 * 3)))]
        [InlineData(true, true, false, true, Size.Medium, Crust.Original, (250 + (5 * 3)))]
        [InlineData(true, true, true, false, Size.Medium, Crust.Original, (250 + (5 * 3)))]
        [InlineData(false, false, false, false, Size.Medium, Crust.Original, (250 + (5 * 0)))]
        public void CaloriesTest(bool olives, bool peppers, bool onions, bool mushrooms, Size s, Crust c, uint cals)
        {
            VeggiePizza p = new VeggiePizza();

            p.GetTopping(Topping.Olives).OnPizza = olives;
            p.GetTopping(Topping.Peppers).OnPizza = peppers;
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
        /// <param name="olives">Whether olives are included.</param>
        /// <param name="peppers">Whether peppers are included.</param>
        /// <param name="onions">Whether onions are included.</param>
        /// <param name="mushrooms">Whether mushrooms are included.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original" })]
        [InlineData(true, true, true, true, Size.Small, Crust.Thin, new string[] { "Small", "Thin Crust" })]
        [InlineData(true, true, true, true, Size.Large, Crust.DeepDish, new string[] { "Large", "Deep Dish" })]
        [InlineData(false, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Olives" })]
        [InlineData(true, false, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Peppers" })]
        [InlineData(true, true, false, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Onions" })]
        [InlineData(true, true, true, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Mushrooms" })]
        [InlineData(false, false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Olives", "Hold Peppers", "Hold Onions", "Hold Mushrooms" })]
        public void SpecialInstructionsTest(bool olives, bool peppers, bool onions, bool mushrooms, Size s, Crust c, string[] instructions)
        {
            VeggiePizza p = new VeggiePizza();

            p.GetTopping(Topping.Olives).OnPizza = olives;
            p.GetTopping(Topping.Peppers).OnPizza = peppers;
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