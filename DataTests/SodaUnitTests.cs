/* SodaUnitTests.cs
 * Author: Calvin Beechner
 */
namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for SodaUnitTests.
    /// </summary>
    public class SodaUnitTests
    {
        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            IcedTea p = new IcedTea();
            Assert.IsAssignableFrom<IMenuItem>(p);
            Assert.IsAssignableFrom<Drink>(p);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            Soda s = new Soda();
            Assert.True(s.Ice);
            Assert.True(s.DrinkSize == Size.Medium);
            Assert.True(s.DrinkType == SodaFlavor.Coke);
        }

        /// <summary>
        /// Tests the price
        /// </summary>
        /// <param name="size">The size of the drink.</param>
        /// <param name="price">The expected price.</param>
        [Theory]
        [InlineData(Size.Medium, 2)]
        [InlineData(Size.Large, 2.5)]
        [InlineData(Size.Small, 1.5)]
        public void PriceTest(Size size, decimal price)
        {
            Soda s = new Soda();
            s.DrinkSize = size;
            Assert.Equal(price, s.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="size">The size of the drink.</param>
        /// <param name="flavor">The flavor of the soda.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(Size.Medium, SodaFlavor.Coke, 200)]
        [InlineData(Size.Small, SodaFlavor.Coke, 150)]
        [InlineData(Size.Large, SodaFlavor.Coke, 250)]
        [InlineData(Size.Medium, SodaFlavor.DietCoke, 0)]
        [InlineData(Size.Large, SodaFlavor.DietCoke, 0)]
        [InlineData(Size.Medium, SodaFlavor.Sprite, 200)]
        [InlineData(Size.Medium, SodaFlavor.DrPepper, 200)]
        [InlineData(Size.Medium, SodaFlavor.RootBeer, 200)]
        public void CaloriesTest(Size size, SodaFlavor flavor, uint cals)
        {
            Soda s = new Soda();

            s.DrinkSize = size;
            s.DrinkType = flavor;

            Assert.Equal(cals, s.CaloriesPerEach);
            Assert.Equal(cals, s.CaloriesTotal);

        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="ice">Whether ice is included.</param>
        /// <param name="size">The size of the drink.</param>
        /// <param name="flavor">The flavor of the drink.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, Size.Medium, SodaFlavor.Coke, new string[] { "Medium", "Coke" })]
        [InlineData(true, Size.Small, SodaFlavor.Coke, new string[] { "Small", "Coke" })]
        [InlineData(true, Size.Large, SodaFlavor.Coke, new string[] { "Large", "Coke" })]
        [InlineData(true, Size.Medium, SodaFlavor.DietCoke, new string[] { "Medium", "Diet Coke" })]
        [InlineData(false, Size.Large, SodaFlavor.DietCoke, new string[] { "Large", "Diet Coke", "Hold Ice" })]
        [InlineData(false, Size.Medium, SodaFlavor.Sprite, new string[] { "Medium", "Sprite", "Hold Ice" })]
        [InlineData(false, Size.Medium, SodaFlavor.DrPepper, new string[] { "Medium", "Dr. Pepper", "Hold Ice" })]
        [InlineData(false, Size.Medium, SodaFlavor.RootBeer, new string[] { "Medium", "Root Beer", "Hold Ice" })]
        public void SpecialInstructionsTest(bool ice, Size size, SodaFlavor flavor, string[] instructions)
        {
            Soda s = new Soda();

            s.DrinkSize = size;
            s.DrinkType = flavor;
            s.Ice = ice;

            List<string> l = new List<string>();
            foreach (string item in instructions)
            {
                l.Add(item);
            }

            Assert.Equal(l, s.SpecialInstructions);
        }
    }
}