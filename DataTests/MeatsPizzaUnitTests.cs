/* MeatsPizzaUnitTests.cs
 * Author: Calvin Beechner
 */
namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for MeatsPizza.
    /// </summary>
    public class MeatsPizzaUnitTests
    {
        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void SausageInitSetTrue()
        {
            MeatsPizza p = new MeatsPizza();
            Assert.True(p.Sausage);
            Assert.True(p.Pepperoni);
            Assert.True(p.Ham);
            Assert.True(p.Bacan);
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
        /// <param name="bacan">Whether bacan is included.</param>
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
        public void CaloriesTest(bool sausage, bool pepperoni, bool ham, bool bacan, Size s, Crust c, uint cals)
        {
            MeatsPizza p = new MeatsPizza();

            p.Sausage = sausage;
            p.Pepperoni = pepperoni;
            p.Ham = ham;
            p.Bacan = bacan;

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
        /// <param name="bacan">Whether bacan is included.</param>
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
        [InlineData(true, true, true, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Bacan" })]
        [InlineData(false, false, false, false, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Hold Sausage", "Hold Pepperoni", "Hold Ham", "Hold Bacan" })]
        public void SpecialInstructionsTest(bool sausage, bool pepperoni, bool ham, bool bacan, Size s, Crust c, string[] instructions)
        {
            MeatsPizza p = new MeatsPizza();

            p.Sausage = sausage;
            p.Pepperoni = pepperoni;
            p.Ham = ham;
            p.Bacan = bacan;

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