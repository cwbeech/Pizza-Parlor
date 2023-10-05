/* WingsUnitTests.cs
 * Author: Calvn Beechner
 */
namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Test cases for Wings.
    /// </summary>
    public class WingsUnitTests
    {
        /// <summary>
        /// Tests the ToString() override works.
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            Wings w = new Wings();
            Assert.Equal(w.Name, w.ToString());
        }

        /// <summary>
        /// Tests the casting.
        /// </summary>
        [Fact]
        public void CanBeCasted()
        {
            Wings w = new Wings();
            Assert.IsAssignableFrom<IMenuItem>(w);
            Assert.IsAssignableFrom<Side>(w);
        }

        /// <summary>
        /// Tests the default values.
        /// </summary>
        [Fact]
        public void InitSetTrue()
        {
            Wings w = new Wings();
            Assert.True(w.BoneIn);
            Assert.True(w.Sauce == WingSauce.Medium);
            Assert.True(w.Count == 5);
        }

        /// <summary>
        /// Tests the constrainted values.
        /// </summary>
        /// <param name="count">The attempted number of items.</param>
        /// <param name="expCount">The expected number of items.</param>
        [Theory]
        [InlineData(5, 5)]
        [InlineData(4, 4)]
        [InlineData(12, 12)]
        [InlineData(13, 12)]
        [InlineData(3, 5)]
        public void CountConstraintsTest(uint count, uint expCount)
        {
            Wings w = new Wings();
            w.Count = count;
            Assert.Equal(expCount, w.Count);
        }

        /// <summary>
        /// Tests the price.
        /// </summary>
        /// <param name="boneIn">Whether bones are included.</param>
        /// <param name="count">The number of items.</param>
        /// <param name="price">The expected price.</param>
        [Theory]
        [InlineData(true, 8, 8*1.5)]
        [InlineData(false, 4, 4*1.75)]
        [InlineData(true, 5, 5*1.5)]
        [InlineData(false, 10, 10*1.75)]
        public void PriceTest(bool boneIn, uint count, decimal price)
        {
            Wings w = new Wings();
            w.BoneIn = boneIn;
            w.Count = count;
            Assert.Equal(price, w.Price);
        }

        /// <summary>
        /// Tests the calories properties.
        /// </summary>
        /// <param name="boneIn">Whether bones are included.</param>
        /// <param name="sauce">The sauce of the wings.</param>
        /// <param name="count">The number of items.</param>
        /// <param name="cals">The expected number of calories.</param>
        [Theory]
        [InlineData(true, WingSauce.Mild, 8, 125)]
        [InlineData(true, WingSauce.Medium, 3, 125)]
        [InlineData(true, WingSauce.Hot, 13, 125)]
        [InlineData(true, WingSauce.HoneyBBQ, 9, 125+20)]
        [InlineData(false, WingSauce.Mild, 8, 175)]
        [InlineData(false, WingSauce.Medium, 3, 175)]
        [InlineData(false, WingSauce.Hot, 13, 175)]
        [InlineData(false, WingSauce.HoneyBBQ, 9, 175+20)]
        public void CaloriesTest(bool boneIn, WingSauce sauce, uint count, uint cals)
        {
            Wings w = new Wings();

            w.BoneIn = boneIn;
            w.Sauce = sauce;
            w.Count = count;

            Assert.Equal(cals, w.CaloriesPerEach);
            Assert.Equal(cals * w.Count, w.CaloriesTotal);
        }

        /// <summary>
        /// Tests the special instructions.
        /// </summary>
        /// <param name="boneIn">Whether bones are included.</param>
        /// <param name="sauce">The sauce of the wings.</param>
        /// <param name="count">The number of items.</param>
        /// <param name="instructions">The expected instructions.</param>
        [Theory]
        [InlineData(true, WingSauce.Mild, 8, new string[] { "8 Bone-In Wings", "Mild Sauce" })]
        [InlineData(true, WingSauce.Medium, 3, new string[] { "5 Bone-In Wings", "Medium Sauce" })]
        [InlineData(true, WingSauce.Hot, 13, new string[] { "12 Bone-In Wings", "Hot Sauce" })]
        [InlineData(true, WingSauce.HoneyBBQ, 9, new string[] { "9 Bone-In Wings", "Honey BBQ Sauce" })]
        [InlineData(false, WingSauce.Mild, 8, new string[] { "8 Boneless Wings", "Mild Sauce" })]
        [InlineData(false, WingSauce.Medium, 3, new string[] { "5 Boneless Wings", "Medium Sauce" })]
        [InlineData(false, WingSauce.Hot, 13, new string[] { "12 Boneless Wings", "Hot Sauce" })]
        [InlineData(false, WingSauce.HoneyBBQ, 9, new string[] { "9 Boneless Wings", "Honey BBQ Sauce" })]
        public void SpecialInstructionsTest(bool boneIn, WingSauce sauce, uint count, string[] instructions)
        {
            Wings w = new Wings();

            w.BoneIn = boneIn;
            w.Sauce = sauce;
            w.Count = count;

            List<string> l = new List<string>();
            foreach (string item in instructions)
            {
                l.Add(item);
            }

            Assert.Equal(l, w.SpecialInstructions);
        }
    }
}