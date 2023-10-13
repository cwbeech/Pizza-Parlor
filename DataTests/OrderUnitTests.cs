/* OrderUnitTests.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Unit Tests for Order.
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// Tests that PlacedAt is properly set.
        /// </summary>
        [Fact]
        public void PlacedAtShouldReflectTimePlaced()
        {
            Order order = new Order();
            DateTime time = DateTime.Now;
            Assert.Equal(order.PlacedAt.Minute, time.Minute);
        }

        /// <summary>
        /// Tests that Number is incremented with each new Order.
        /// </summary>
        [Fact]
        public void ShouldIncrementNumberWithEachOrder()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();

            Assert.Equal(order1.Number + 1m, order2.Number);
            Assert.Equal(order1.Number + 2m, order3.Number);
        }
        /// <summary>
        /// Tests that Order implements INotifyCollectionChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyCollectoinChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }

        /// <summary>
        /// Tests adding a menu item.
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Count", () =>
            {
                order.Add(new Pizza());
            });
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.Add(new Pizza());
            });
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Add(new Pizza());
            });
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Add(new Pizza());
            });
        }

        /// <summary>
        /// Tests removing a menu item.
        /// </summary>
        [Fact]
        public void RemovingItemShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Pizza p = new Pizza();

            order.Add(p);
            Assert.PropertyChanged(order, "Count", () =>
            {
                order.Remove(p);
            });

            order.Add(p);
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.Remove(p);
            });

            order.Add(p);
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Remove(p);
            });

            order.Add(p);
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Remove(p);
            });
        }

        /// <summary>
        /// Tests updating the TaxRate property.
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            //Add
            Assert.PropertyChanged(order, "TaxRate", () =>
            {
                order.TaxRate = .15m;
            });
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.TaxRate = .15m;
            });
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.TaxRate = .15m;
            });
        }

        /// <summary>
        /// Tests that Order implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

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
