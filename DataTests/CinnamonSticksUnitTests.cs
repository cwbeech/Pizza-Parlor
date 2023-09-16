﻿/* CinnamonSticksUnitTests.cs
 * Author: Calvin Beechner
 */
namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for CinnamonSticks.
    /// </summary>
    public class CinnamonSticksUnitTests
    {
        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            CinnamonSticks c = new CinnamonSticks();
            Assert.True(c.Frosting);
            Assert.True(c.Count == 8);
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
            CinnamonSticks c = new CinnamonSticks();
            c.Count = count;
            Assert.Equal(expCount, c.Count);
        }

        /// <summary>
        /// Tests the price.
        /// </summary>
        /// <param name="frosting">Whether frosting is included</param>
        /// <param name="count">The number of items.</param>
        /// <param name="price">The expected price.</param>
        [Theory]
        [InlineData(true, 8, 8*.9)]
        [InlineData(false, 4, 4*.75)]
        [InlineData(true, 5, 5*.9)]
        [InlineData(false, 10, 10*.75)]
        public void PriceTest(bool frosting, uint count, decimal price)
        {
            CinnamonSticks c = new CinnamonSticks();
            c.Frosting = frosting;
            c.Count = count;
            Assert.Equal(price, c.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="frosting">Whether frosting is included.</param>
        /// <param name="count">The number of items.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(true, 8, 190)]
        [InlineData(false, 3, 160)]
        [InlineData(true, 13, 190)]
        [InlineData(false, 9, 160)]
        public void CaloriesTest(bool frosting, uint count, uint cals)
        {
            CinnamonSticks c = new CinnamonSticks();

            c.Frosting = frosting;
            c.Count = count;

            Assert.Equal(cals, c.CaloriesPerEach);
            Assert.Equal(cals * c.Count, c.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="frosting">Whether frosting is included.</param>
        /// <param name="count">the number of items.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, 8, new string[] { "8 Cinnamon Sticks" })]
        [InlineData(false, 3, new string[] { "8 Cinnamon Sticks", "Hold Frosting" })]
        [InlineData(true, 13, new string[] { "12 Cinnamon Sticks" })]
        [InlineData(false, 9, new string[] { "9 Cinnamon Sticks", "Hold Frosting" })]
        public void SpecialInstructionsTest(bool frosting, uint count, string[] instructions)
        {
            CinnamonSticks c = new CinnamonSticks();
            c.Frosting = frosting;
            c.Count = count;

            List<string> l = new List<string>();
            foreach (string item in instructions)
            {
                l.Add(item);
            }

            Assert.Equal(l, c.SpecialInstructions);
        }
    }
}