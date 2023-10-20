/* GarlicKnotsUnitTests.cs
 * Author: Calvin Beechner
 */
using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for GarlicKnots.
    /// </summary>
    public class GarlicKnotsUnitTests
    {
        /// <summary>
        /// Tests that changing the count notifies the effected properties.
        /// </summary>
        /// <param name="count">Count value.</param>
        /// <param name="propertyName">The name of the property effected.</param>
        [Theory]
        [InlineData(5, "Count")]
        [InlineData(6, "Price")]
        [InlineData(7, "SpecialInstructions")]
        [InlineData(8, "CaloriesPerEach")]
        [InlineData(9, "CaloriesTotal")]
        public void ChangingCountShouldNotifyOfPropertyChange(uint count, string propertyName)
        {
            GarlicKnots k = new GarlicKnots();
            Assert.PropertyChanged(k, propertyName, () =>
            {
                k.Count = count;
            });
        }

        /// <summary>
        /// Tests that the MenuItem implements INotifyPropertyChanged.
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            GarlicKnots k = new GarlicKnots();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(k);
        }

        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            GarlicKnots k = new GarlicKnots();
            Assert.Equal(k.Name, k.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            GarlicKnots k = new GarlicKnots();
            Assert.IsAssignableFrom<IMenuItem>(k);
            Assert.IsAssignableFrom<Side>(k);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            GarlicKnots k = new GarlicKnots();
            Assert.True(k.Count == 8);
        }

        /// <summary>
        /// Tests the constrainted values.
        /// </summary>
        /// <param name="count">The attempted number of items.</param>
        /// <param name="expCount">The expected number of items.</param>
        [Theory]
        [InlineData(8, 8)]
        [InlineData(4, 4)]
        [InlineData(12, 12)]
        [InlineData(13, 12)]
        [InlineData(3, 8)]
        public void CountConstraintsTest(uint count, uint expCount)
        {
            GarlicKnots k = new GarlicKnots();
            k.Count = count;
            Assert.Equal(expCount, k.Count);
        }

        /// <summary>
        /// Tests the price.
        /// </summary>
        /// <param name="count">The number of items.</param>
        /// <param name="price">The expected price.</param>
        [Theory]
        [InlineData(8, 8*.75)]
        [InlineData(4, 4*.75)]
        [InlineData(5, 5*.75)]
        [InlineData(10, 10*.75)]
        public void PriceTest(uint count, decimal price)
        {
            GarlicKnots k = new GarlicKnots();
            k.Count = count;
            Assert.Equal(price, k.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="count">The number of items.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(8, 175)]
        [InlineData(3, 175)]
        [InlineData(13, 175)]
        [InlineData(9, 175)]
        public void CaloriesTest(uint count, uint cals)
        {
            GarlicKnots k = new GarlicKnots();

            k.Count = count;

            Assert.Equal(cals, k.CaloriesPerEach);
            Assert.Equal(cals * k.Count, k.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="count">The number of items.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(8, new string[] { "8 Garlic Knots" })]
        [InlineData(3, new string[] { "8 Garlic Knots"})]
        [InlineData(13, new string[] { "12 Garlic Knots" })]
        [InlineData(9, new string[] { "9 Garlic Knots"})]
        public void SpecialInstructionsTest(uint count, string[] instructions)
        {
            GarlicKnots k = new GarlicKnots();
            k.Count = count;

            List<string> l = new List<string>();
            foreach (string item in instructions)
            {
                l.Add(item);
            }

            Assert.Equal(l, k.SpecialInstructions);
        }
    }
}