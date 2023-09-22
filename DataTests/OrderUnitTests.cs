/* OrderUnitTests.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Unit Tests for Order.
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// Tests the Subtotal.
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        /// <summary>
        /// Tests the Tax Rate.
        /// </summary>
        [Fact]
        public void TaxRateShouldBeIni()
        {
            Order order = new Order();
            Assert.Equal(.0915m, order.TaxRate);
        }

        /// <summary>
        /// Tests the Tax.
        /// </summary>
        [Fact]
        public void TaxShouldReflectTaxRate()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(.0915m * order.Subtotal, order.Tax);
        }

        /// <summary>
        /// Tests the Total.
        /// </summary>
        [Fact]
        public void TotalShouldReflectTotalPrice()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(order.Subtotal + order.Tax, order.Total);
        }
    }

    /// <summary>
    /// A mock menu item for testing
    /// </summary>
    internal class MockMenuItem : IMenuItem
    {
        /// <summary>
        /// Name for mock item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description for mock item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Prie for mock item.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Calories per each mock item.
        /// </summary>
        public uint CaloriesPerEach { get; set; }

        /// <summary>
        /// Total calories for whole mock item.
        /// </summary>
        public uint CaloriesTotal { get; set; }

        /// <summary>
        /// Enumerator for mock item.
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; set; }
    }
}
