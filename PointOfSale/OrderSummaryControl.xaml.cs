using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using PizzaParlor.Data;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {

        public event EventHandler<CustomizationEventArgs>? EditClicked;

        /// <summary>
        /// Constructor for the OrderSummaryControl.
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click methode for Edit button click.
        /// </summary>
        /// <param name="sender">The button being clicked.</param>
        /// <param name="e">The information passed.</param>
        public void EditClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b && b.DataContext is IMenuItem m)
            {
                EditClicked?.Invoke(this, new CustomizationEventArgs(m));
            }
            
        }
    }
}
