/* MeatsPizzaUnitTests.cs
 * Author: Calvin Beechner
 */
using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for MeatsPizza.
    /// </summary>
    public class MeatsPizzaUnitTests
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
            MeatsPizza p = new MeatsPizza();
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
            MeatsPizza p = new MeatsPizza();
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
            MeatsPizza p = new MeatsPizza();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(p);
        }

        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            MeatsPizza p = new MeatsPizza();
            Assert.Equal(p.Name, p.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            MeatsPizza p = new MeatsPizza();
            Assert.IsAssignableFrom<IMenuItem>(p);
            Assert.IsAssignableFrom<Pizza>(p);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void SausageInitSetTrue()
        {
            MeatsPizza p = new MeatsPizza();

            Assert.True(p.GetTopping(Topping.Sausage).OnPizza);
            Assert.True(p.GetTopping(Topping.Pepperoni).OnPizza);
            Assert.True(p.GetTopping(Topping.Ham).OnPizza);
            Assert.True(p.GetTopping(Topping.Bacon).OnPizza);
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
        [InlineData(Size.Medium, Crust.Original, 15.99)]
        [InlineData(Size.Small, Crust.Thin, (15.99-2))]
        [InlineData(Size.Large, Crust.DeepDish, 15.99+2+1)]
        [InlineData(Size.Medium, Crust.DeepDish, (15.99+1))]
        [InlineData(Size.Small, Crust.DeepDish, (15.99-2+1))]
        public void PriceTest(Size s, Crust c, decimal price)
        {
            MeatsPizza p = new MeatsPizza();

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(price, p.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="sausage">Whether sausage is included.</param>
        /// <param name="pepperoni">Whether pepperoni is included.</param>
        /// <param name="ham">Whether ham is included.</param>
        /// <param name="bacon">Whether bacan is included.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(true, true, true, true, Size.Medium, Crust.Original, (250 + 30 + 20 + 20 + 20))]
        [InlineData(true, true, true, true, Size.Small, Crust.Thin, (uint)(0.75*(150 + 30 + 20 + 20 + 20)))]
        [InlineData(true, true, true, true, Size.Large, Crust.DeepDish, (uint)(1.3*(300 + 30 + 20 + 20 + 20)))]
        [InlineData(false, true, true, true, Size.Medium, Crust.Original, (250 + 20 + 20 + 20))]
        [InlineData(true, false, true, true, Size.Medium, Crust.Original, (250 + 30 + 20 + 20))]
        [InlineData(true, true, false, true, Size.Medium, Crust.Original, (250 + 30 + 20 + 20))]
        [InlineData(true, true, true, false, Size.Medium, Crust.Original, (250 + 30 + 20 + 20))]
        [InlineData(false, false, false, false, Size.Medium, Crust.Original, (250))]
        public void CaloriesTest(bool sausage, bool pepperoni, bool ham, bool bacon, Size s, Crust c, uint cals)
        {
            MeatsPizza p = new MeatsPizza();

            p.GetTopping(Topping.Sausage).OnPizza = sausage;
            p.GetTopping(Topping.Pepperoni).OnPizza = pepperoni;
            p.GetTopping(Topping.Ham).OnPizza = ham;
            p.GetTopping(Topping.Bacon).OnPizza = bacon;

            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(cals, p.CaloriesPerEach);
            Assert.Equal(cals * 8, p.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="sausage">Whether sausage is included.</param>
        /// <param name="pepperoni">Whether pepperoni is included.</param>
        /// <param name="ham">Whether ham is included.</param>
        /// <param name="bacon">Whether bacan is included.</param>
        /// <param name="s">The size of the pizza.</param>
        /// <param name="c">The crust of the pizza.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original" })]
        [InlineData(true, true, true, true, Size.Small, Crust.Thin, new string[] { "Small", "Thin Crust" })]
        [InlineData(true, true, true, true, Size.Large, Crust.DeepDish, new string[] { "Large", "Deep Dish" })]
        [InlineData(false, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Sausage" })]
        [InlineData(true, false, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Pepperoni" })]
        [InlineData(true, true, false, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Ham" })]
        [InlineData(true, true, true, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Bacon" })]
        [InlineData(false, false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Sausage", "Hold Pepperoni", "Hold Ham", "Hold Bacon" })]
        public void SpecialInstructionsTest(bool sausage, bool pepperoni, bool ham, bool bacon, Size s, Crust c, string[] instructions)
        {
            MeatsPizza p = new MeatsPizza();

            p.GetTopping(Topping.Sausage).OnPizza = sausage;
            p.GetTopping(Topping.Pepperoni).OnPizza = pepperoni;
            p.GetTopping(Topping.Ham).OnPizza = ham;
            p.GetTopping(Topping.Bacon).OnPizza = bacon;

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