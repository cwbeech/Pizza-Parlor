/* PizzaUnitTests.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Unit Tests for the general Pizza class.
    /// </summary>
    public class PizzaUnitTests
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
            Pizza p = new Pizza();
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
            Pizza p = new Pizza();
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
            Pizza p = new Pizza();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(p);
        }

        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            Pizza p = new Pizza();
            Assert.Equal(p.Name, p.ToString());
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            Pizza p = new Pizza();
            foreach (PizzaTopping pt in p.PossibleToppings)
            {
                Assert.True(pt.OnPizza == false);
            }
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
        [InlineData(Size.Medium, Crust.Original, 9.99)]
        [InlineData(Size.Small, Crust.Thin, (9.99 - 2))]
        [InlineData(Size.Large, Crust.DeepDish, 9.99 + 2 + 1)]
        [InlineData(Size.Medium, Crust.DeepDish, (9.99 + 1))]
        [InlineData(Size.Small, Crust.DeepDish, (9.99 - 2 + 1))]
        public void PriceTest(Size s, Crust c, decimal price)
        {
            Pizza p = new Pizza();

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(price, p.Price);
        }

        /// <summary>
        /// Tests the calories properties. This one's rather rigorous due to the nature of creaing pizzatoppings being rather annoying.
        /// </summary>
        /// <param name="sausage">Whether sausage is present.</param>
        /// <param name="pepperoni">Whether pepperoni is present.</param>
        /// <param name="ham">Whether ham is present.</param>
        /// <param name="bacon">Whether bacon is present.</param>
        /// <param name="olives">Whether olives are present.</param>
        /// <param name="onions">Whether onions are present.</param>
        /// <param name="mushrooms">Whether mushrooms are present.</param>
        /// <param name="peppers">Whether peppers are present.</param>
        /// <param name="pineapple">Whether pineapples are present.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="cals">The expected calories.</param>
        [Theory]
        [InlineData(false, true, false, false, false, false, false, false, false, Size.Medium, Crust.Original, 250 + 20)]
        [InlineData(false, false, true, false, false, false, false, false, false, Size.Small, Crust.Thin, (uint)(.75*(150 + 20)))]
        [InlineData(false, false, false, true, false, false, false, false, false, Size.Large, Crust.DeepDish, (uint)(1.3*(300+20)))]
        [InlineData(false, false, false, false, true, false, false, false, false, Size.Medium, Crust.Original, 250 + 5)]
        [InlineData(false, false, false, false, false, true, false, false, false, Size.Medium, Crust.Original, 250 + 5)]
        [InlineData(false, false, false, false, false, false, true, false, false, Size.Medium, Crust.Original, 250 + 5)]
        [InlineData(false, false, false, false, false, false, false, true, false, Size.Medium, Crust.Original, 250 + 5)]
        [InlineData(false, false, false, false, false, false, false, false, true, Size.Medium, Crust.Original, 250 + 10)]
        public void CaloriesTest(bool sausage, bool pepperoni, bool ham, bool bacon, bool olives, bool onions, bool mushrooms, bool peppers, bool pineapple, Size s, Crust c, uint cals)
        {
            Pizza p = new Pizza();

            p.GetTopping(Topping.Sausage).OnPizza = sausage;
            p.GetTopping(Topping.Pepperoni).OnPizza = pepperoni;
            p.GetTopping(Topping.Ham).OnPizza = ham;
            p.GetTopping(Topping.Bacon).OnPizza = bacon;
            p.GetTopping(Topping.Olives).OnPizza = olives;
            p.GetTopping(Topping.Onions).OnPizza = onions;
            p.GetTopping(Topping.Mushrooms).OnPizza = mushrooms;
            p.GetTopping(Topping.Peppers).OnPizza = peppers;
            p.GetTopping(Topping.Pineapple).OnPizza = pineapple;

            p.PizzaSize = s;
            p.PizzaCrust = c;

            Assert.Equal(cals, p.CaloriesPerEach);
            Assert.Equal(cals * p.Slices, p.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="sausage">Whether sausage is present.</param>
        /// <param name="pepperoni">Whether pepperoni is present.</param>
        /// <param name="ham">Whether ham is present.</param>
        /// <param name="bacon">Whether bacon is present.</param>
        /// <param name="olives">Whether olives are present.</param>
        /// <param name="onions">Whether onions are present.</param>
        /// <param name="mushrooms">Whether mushrooms are present.</param>
        /// <param name="peppers">Whether peppers are present.</param>
        /// <param name="pineapple">Whether pineapples are present.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(false, true, false, false, false, false, false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Pepperoni" })]
        [InlineData(false, false, true, false, false, false, false, false, false, Size.Small, Crust.Thin, new string[] { "Small", "Thin Crust", "Add Ham" })]
        [InlineData(false, false, false, true, false, false, false, false, false, Size.Large, Crust.DeepDish, new string[] { "Large", "Deep Dish", "Add Bacon" })]
        [InlineData(false, false, false, false, true, false, false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Olives" })]
        [InlineData(false, false, false, false, false, true, false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Onions" })]
        [InlineData(false, false, false, false, false, false, true, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Mushrooms" })]
        [InlineData(false, false, false, false, false, false, false, true, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Peppers" })]
        [InlineData(false, false, false, false, false, false, false, false, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Pineapple" })]
        public void SpecialInstructionsTest(bool sausage, bool pepperoni, bool ham, bool bacon, bool olives, bool onions, bool mushrooms, bool peppers, bool pineapple, Size s, Crust c, string[] instructions)
        {
            Pizza p = new Pizza();

            p.GetTopping(Topping.Sausage).OnPizza = sausage;
            p.GetTopping(Topping.Pepperoni).OnPizza = pepperoni;
            p.GetTopping(Topping.Ham).OnPizza = ham;
            p.GetTopping(Topping.Bacon).OnPizza = bacon;
            p.GetTopping(Topping.Olives).OnPizza = olives;
            p.GetTopping(Topping.Onions).OnPizza = onions;
            p.GetTopping(Topping.Mushrooms).OnPizza = mushrooms;
            p.GetTopping(Topping.Peppers).OnPizza = peppers;
            p.GetTopping(Topping.Pineapple).OnPizza = pineapple;

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
