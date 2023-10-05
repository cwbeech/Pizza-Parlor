/* IcedTeaUnitTests.cs
 * Author: Calvin Beechner
 */
namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Tests cases for IcedTeaUnitTests.
    /// </summary>
    public class IcedTeaUnitTests

    {
        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            IcedTea i = new IcedTea();
            Assert.Equal(i.Name, i.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            IcedTea i = new IcedTea();
            Assert.IsAssignableFrom<IMenuItem>(i);
            Assert.IsAssignableFrom<Drink>(i);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            IcedTea i = new IcedTea();
            Assert.True(i.Ice);
            Assert.True(i.DrinkSize == Size.Medium);
        }

        /// <summary>
        /// Tests the price.
        /// </summary>
        /// <param name="size">The size of the drink.</param>
        /// <param name="price">The expected price.</param>
        [Theory]
        [InlineData(Size.Medium, 2.5)]
        [InlineData(Size.Large, 3)]
        [InlineData(Size.Small, 2)]
        public void PriceTest(Size size, decimal price)
        {
            IcedTea i = new IcedTea();
            i.DrinkSize = size;
            Assert.Equal(price, i.Price);
        }

        /// <summary>
        /// Tests the calories property.
        /// </summary>
        /// <param name="size">The size of the drink.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(Size.Medium, 220)]
        [InlineData(Size.Small, 175)]
        [InlineData(Size.Large, 275)]
        public void CaloriesTest(Size size, uint cals)
        {
            IcedTea i = new IcedTea();

            i.DrinkSize = size;

            Assert.Equal(cals, i.CaloriesPerEach);
            Assert.Equal(cals, i.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="ice">Whether ice is included.</param>
        /// <param name="size">The size of the drink.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, Size.Medium, new string[] { "Medium" })]
        [InlineData(true, Size.Small,  new string[] { "Small" })]
        [InlineData(true, Size.Large,  new string[] { "Large" })]
        [InlineData(false, Size.Medium, new string[] { "Medium", "Hold Ice" })]
        [InlineData(false, Size.Large, new string[] { "Large", "Hold Ice" })]
        [InlineData(false, Size.Small, new string[] { "Small", "Hold Ice" })]
        public void SpecialInstructionsTest(bool ice, Size size, string[] instructions)
        {
            IcedTea i = new IcedTea();

            i.DrinkSize = size;
            i.Ice = ice;

            List<string> l = new List<string>();
            foreach (string item in instructions)
            {
                l.Add(item);
            }

            Assert.Equal(l, i.SpecialInstructions);
        }
    }
}