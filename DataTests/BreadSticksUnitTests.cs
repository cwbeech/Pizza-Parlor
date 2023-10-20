/* BreadStickUnitTests.cs
 * Author: Calvin Beechner
 */
using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Tests cases for BreadSticks.
    /// </summary>
    public class BreadSticksUnitTests
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
            Breadsticks b = new Breadsticks();
            Assert.PropertyChanged(b, propertyName, () =>
            {
                b.Count = count;
            });
        }

        /// <summary>
        /// Tests that changing the Cheese notifies the effected properties.
        /// </summary>
        /// <param name="cheese">Frosting Value.</param>
        /// <param name="propertyName">The name of the property effected.</param>
        [Theory]
        [InlineData(false, "Cheese")]
        [InlineData(true, "Price")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(true, "CaloriesPerEach")]
        [InlineData(false, "CaloriesTotal")]
        public void ChangingCheeseShouldNotifyOfPropertyChange(bool cheese, string propertyName)
        {
            Breadsticks b = new Breadsticks();
            Assert.PropertyChanged(b, propertyName, () =>
            {
                b.Cheese = cheese;
            });
        }

        /// <summary>
        /// Tests that the MenuItem implements INotifyPropertyChanged.
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Breadsticks b = new Breadsticks();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(b);
        }

        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            Breadsticks b = new Breadsticks();
            Assert.Equal(b.Name, b.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            Breadsticks b = new Breadsticks();
            Assert.IsAssignableFrom<IMenuItem>(b);
            Assert.IsAssignableFrom<Side>(b);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            Breadsticks b = new Breadsticks();
            Assert.True(!b.Cheese);
            Assert.True(b.Count == 8);
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
            Breadsticks b = new Breadsticks();
            b.Count = count;
            Assert.Equal(expCount, b.Count);
        }

        /// <summary>
        /// Tests the price.
        /// </summary>
        /// <param name="cheese">Whether cheese is included.</param>
        /// <param name="count">The number of items.</param>
        /// <param name="price">The expected price.</param>
        [Theory]
        [InlineData(true, 8, 8)]
        [InlineData(false, 4, (4*.75))]
        [InlineData(true, 5, 5)]
        [InlineData(false, 10, (10*.75))]
        public void PriceTest(bool cheese, uint count, decimal price)
        {
            Breadsticks b = new Breadsticks();
            b.Cheese = cheese;
            b.Count = count;
            Assert.Equal(price, b.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="cheese">Whether cheese is included.</param>
        /// <param name="count">The number of items.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(true, 8, 200)]
        [InlineData(false, 3, 150)]
        [InlineData(true, 13, 200)]
        [InlineData(false, 9, 150)]
        public void CaloriesTest(bool cheese, uint count, uint cals)
        {
            Breadsticks b = new Breadsticks();

            b.Cheese = cheese;
            b.Count = count;

            Assert.Equal(cals, b.CaloriesPerEach);
            Assert.Equal(cals * b.Count, b.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="cheese">Whether cheese is included.</param>
        /// <param name="count">The number of items.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, 8, new string[] { "8 Cheesesticks" })]
        [InlineData(false, 3, new string[] { "8 Breadsticks" })]
        [InlineData(true, 13, new string[] { "12 Cheesesticks" })]
        [InlineData(false, 9, new string[] { "9 Breadsticks" })]
        public void SpecialInstructionsTest(bool cheese, uint count, string[] instructions)
        {
            Breadsticks b = new Breadsticks();
            b.Cheese = cheese;
            b.Count = count;

            List<string> l = new List<string>();
            foreach (string item in instructions)
            {
                l.Add(item);
            }

            Assert.Equal(l, b.SpecialInstructions);
        }
    }
}