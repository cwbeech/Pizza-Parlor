/* Order.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Representing an order containing multiple menu items.
    /// </summary>
    public class Order : ICollection<IMenuItem>
    {
        /// <summary>
        /// List of the menuItems in the order.
        /// </summary>
        private List<IMenuItem> _menuItems = new List<IMenuItem>();

        /// <summary>
        /// The price of all items in the order.
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal total = 0;
                foreach (IMenuItem item in _menuItems)
                {
                    total += item.Price;
                }
                return total;
            }
        }

        /// <summary>
        /// Sales tax rate.
        /// </summary>
        public decimal TaxRate { get; set; } = .0915m;

        /// <summary>
        /// Calculates the tax for the order.
        /// </summary>
        public decimal Tax { get => Subtotal * TaxRate; }

        /// <summary>
        /// Calculates the total price of the order.
        /// </summary>
        public decimal Total { get => Subtotal + Tax; }

        /// <summary>
        /// Number of items in the order.
        /// </summary>
        public int Count { get => _menuItems.Count; }

        /// <summary>
        /// Determines if the Order is read only.
        /// </summary>
        public bool IsReadOnly { get; set; } = false; //what to set to?

        /// <summary>
        /// Adds new Item to the Order.
        /// </summary>
        /// <param name="item">The item being added.</param>
        public void Add(IMenuItem item)
        {
            _menuItems.Add(item);
        }

        /// <summary>
        /// Clears the order.
        /// </summary>
        public void Clear()
        {
            _menuItems = new List<IMenuItem>();
        }

        /// <summary>
        /// Checks if the order contains a menuItem.
        /// </summary>
        /// <param name="item">The menuItem in question.</param>
        /// <returns>A bool representing whether the order contains the menuItem.</returns>
        public bool Contains(IMenuItem item)
        {
            foreach (IMenuItem i in _menuItems)
            {
                if (i.Name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Copies the menuItems into an array starting at the specified index.
        /// </summary>
        /// <param name="array">The array being copied to.</param>
        /// <param name="arrayIndex">The index in the array the copy is starting at.</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < array.Length && i < _menuItems.Count; i++)
            {
                array[i] = _menuItems[i - arrayIndex];
            }
        }

        /// <summary>
        /// Returns an enumeration of the Order.
        /// </summary>
        /// <returns>The enumeration of the order.</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            foreach (IMenuItem item in _menuItems)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Attempts to remove an item.
        /// </summary>
        /// <param name="item">The item attempting to be removed.</param>
        /// <returns>If item is not in order then returns false.</returns>
        public bool Remove(IMenuItem item)
        {
            if (_menuItems.Remove(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Old enumerator.
        /// </summary>
        /// <returns>Returns GetEnumerator().</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
