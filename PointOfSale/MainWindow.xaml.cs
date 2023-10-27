using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor for the MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Order();
            MenuItemSelection.MenuItemClicked += OnMenuItemClicked;
            OrderSummary.EditClicked += OnMenuItemClicked;
            OrderSummary.RemoveClicked += OnRemoveClicked;
            File.Create("recipt.txt");
        }

        /// <summary>
        /// Executes when a MenuItem is clicked. Makes MenuItemSelection hidden and the MenuItem visible.
        /// </summary>
        /// <param name="sender">The MenuItem that was cliced on.</param>
        /// <param name="e">The MenuItem clicked event.</param>
        private void OnMenuItemClicked(object? sender, CustomizationEventArgs e)
        {
            Payment.Visibility = Visibility.Hidden;
            if (sender != null)
            {
                BackToMenu(sender, e);
            }

            MenuItemSelection.Visibility = Visibility.Hidden;

            if (e.MenuItem is Pizza)
            {
                CustomPizza.Visibility = Visibility.Visible;
                CustomPizza.DataContext = e.MenuItem;
                CustomPizza.LoadChoices();
            }
            else if (e.MenuItem is Side)
            {
                if (e.MenuItem is Breadsticks)
                {
                    CustomBreadsticks.Visibility = Visibility.Visible;
                    CustomBreadsticks.DataContext = e.MenuItem;
                }
                else if (e.MenuItem is CinnamonSticks)
                {
                    CustomCinnamonSticks.Visibility = Visibility.Visible;
                    CustomCinnamonSticks.DataContext = e.MenuItem;
                }
                else if (e.MenuItem is GarlicKnots)
                {
                    CustomGarlicKnots.Visibility = Visibility.Visible;
                    CustomGarlicKnots.DataContext = e.MenuItem;
                }
                else if (e.MenuItem is Wings)
                {
                    CustomWings.Visibility = Visibility.Visible;
                    CustomWings.DataContext = e.MenuItem;
                }
            }
            else if (e.MenuItem is Drink)
            {
                if (e.MenuItem is IcedTea)
                {
                    CustomIcedTea.Visibility = Visibility.Visible;
                    CustomIcedTea.DataContext = e.MenuItem;
                }
                else if (e.MenuItem is Soda)
                {
                    CustomSoda.Visibility = Visibility.Visible;
                    CustomSoda.DataContext = e.MenuItem;
                }
            }
        }

        /// <summary>
        /// Button event for Back To Menu.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">The information passed.</param>
        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            MenuItemSelection.Visibility = Visibility.Visible;

            CustomBreadsticks.Visibility = Visibility.Hidden;
            CustomCinnamonSticks.Visibility = Visibility.Hidden;
            CustomGarlicKnots.Visibility = Visibility.Hidden;
            CustomIcedTea.Visibility = Visibility.Hidden;
            CustomSoda.Visibility = Visibility.Hidden;
            CustomPizza.Visibility = Visibility.Hidden;
            CustomWings.Visibility = Visibility.Hidden;

            Payment.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Executes when the Remove button is clicked in a OrderSummary
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">The menuitem clicked event.</param>
        private void OnRemoveClicked(object? sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                BackToMenu(sender, e);
            }
            Payment.Visibility = Visibility.Hidden;
            MenuItemSelection.Visibility = Visibility.Visible;

            if (e is CustomizationEventArgs E)
            {
                if (DataContext is Order o)
                {
                    o.Remove(E.MenuItem);
                }
            }
        }

        /// <summary>
        /// Button press event for "Cancel order".
        /// </summary>
        /// <param name="sender">The button pressed.</param>
        /// <param name="e">The arguments passed.</param>
        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            BackToMenu(sender, e);
            DataContext = new Order();
        }

        /// <summary>
        /// Button press event for "Cancel order".
        /// </summary>
        /// <param name="sender">The button pressed.</param>
        /// <param name="e">The arguments passed.</param>
        private void CompleteOrder(object sender, RoutedEventArgs e)
        {
            BackToMenu(sender, e);
            if (DataContext is Order o)
            {
                Payment.DataContext = new PaymentViewModel(o);
            }
            MenuItemSelection.Visibility = Visibility.Hidden;
            Payment.Visibility = Visibility.Visible;
        }
    }
}
