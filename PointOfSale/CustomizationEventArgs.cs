using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PizzaParlor.Data;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Custom EventArgs for handling a user editing a MenuItem.
    /// </summary>
    public class CustomizationEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// The MenuItem needed for the even.
        /// </summary>
        public IMenuItem MenuItem { get; set; }

        /// <summary>
        /// The Constructor for this CustomizationEventArgs.
        /// </summary>
        /// <param name="m">The MenuItem being initialized.</param>
        public CustomizationEventArgs(IMenuItem m)
        {
            MenuItem = m;
        }
    }
}
