using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        /// <summary>
        /// Count property to be displayed.
        /// </summary>
        public uint Count
        {
            get => (uint)GetValue(CountProperty);
            set
            {
                SetValue(CountProperty, value);
            }
        }

        /// <summary>
        /// Creates a new DependencyProperty for CountProperty.
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(uint), typeof(CountBox), new PropertyMetadata(1u));

        /// <summary>
        /// Constructor for CountBox.
        /// </summary>
        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles an increment button press.
        /// </summary>
        /// <param name="sender">The button being pressed.</param>
        /// <param name="e">Contains the event data.</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count < uint.MaxValue) Count++;
        }

        /// <summary>
        /// Handles a decrement button press.
        /// </summary>
        /// <param name="sender">The button being pressed.</param>
        /// <param name="e">Contains the event data.</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count > 0) Count--;
        }
    }
}
