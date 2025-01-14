/* HawaiianPizzaUnitTests.cs
 * Author: Calvin Beechner
 */
using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for HawaiianPizza.
    /// </summary>
    public class HawaiianPizzaUnitTests
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
            HawaiianPizza p = new HawaiianPizza();
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
            HawaiianPizza p = new HawaiianPizza();
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
            HawaiianPizza p = new HawaiianPizza();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(p);
        }

        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            HawaiianPizza p = new HawaiianPizza();
            Assert.Equal(p.Name, p.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            HawaiianPizza p = new HawaiianPizza();
            Assert.IsAssignableFrom<IMenuItem>(p);
            Assert.IsAssignableFrom<Pizza>(p);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            HawaiianPizza p = new HawaiianPizza();
            
            Assert.True(p.GetTopping(Topping.Ham).OnPizza);
            Assert.True(p.GetTopping(Topping.Onions).OnPizza);
            Assert.True(p.GetTopping(Topping.Pineapple).OnPizza);
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
            HawaiianPizza p = new HawaiianPizza();

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(price, p.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="ham">Whether ham is inluded.</param>
        /// <param name="pineapple">Whether pineapple is included.</param>
        /// <param name="onions">Whether onions are included.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(true, true, true, Size.Medium, Crust.Original, (250 + 20 + 10 + 5 ))]
        [InlineData(true, true, false, Size.Small, Crust.Thin, (uint)(0.75*(150 + 20 + 10)))]
        [InlineData(true, false, true, Size.Large, Crust.DeepDish, (uint)(1.3*(300 + 20 + 5)))]
        [InlineData(true, false, false, Size.Medium, Crust.Original, (250 + 20))]
        [InlineData(false, true, true, Size.Medium, Crust.Original, (250 + 10 + 5))]
        [InlineData(false, true, false, Size.Medium, Crust.Original, (250 + 10))]
        [InlineData(false, false, true, Size.Medium, Crust.Original, (250 + 5))]
        [InlineData(false, false, false, Size.Medium, Crust.Original, (250))]
        public void CaloriesTest(bool ham, bool pineapple, bool onions, Size s, Crust c, uint cals)
        {
            HawaiianPizza p = new HawaiianPizza();

            p.GetTopping(Topping.Ham).OnPizza = ham;
            p.GetTopping(Topping.Onions).OnPizza = onions;
            p.GetTopping(Topping.Pineapple).OnPizza = pineapple;

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(cals, p.CaloriesPerEach);
            Assert.Equal(cals * 8, p.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="ham">Whether ham is included.</param>
        /// <param name="pineapple">Whether pineapples are included.</param>
        /// <param name="onions">Whether onions are included.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original" })]
        [InlineData(true, true, true, Size.Small, Crust.Thin, new string[] { "Small", "Thin Crust" })]
        [InlineData(true, true, true, Size.Large, Crust.DeepDish, new string[] { "Large", "Deep Dish" })]
        [InlineData(false, true, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Ham", "Hold Onions" })]
        [InlineData(false, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Ham" })]
        [InlineData(true, false, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Pineapple" })]
        [InlineData(true, true, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Onions" })]
        [InlineData(false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Ham", "Hold Pineapple", "Hold Onions" })]
        public void SpecialInstructionsTest(bool ham, bool pineapple, bool onions, Size s, Crust c, string[] instructions)
        {
            HawaiianPizza p = new HawaiianPizza();

            p.GetTopping(Topping.Ham).OnPizza = ham;
            p.GetTopping(Topping.Onions).OnPizza = onions;
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