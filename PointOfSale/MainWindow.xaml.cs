using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }

        /// <summary>
        /// Executes when a MenuItem is clicked. Makes MenuItemSelection hidden and the MenuItem visible.
        /// </summary>
        /// <param name="sender">The MenuItem that was cliced on.</param>
        /// <param name="e">The MenuItem clicked event.</param>
        private void OnMenuItemClicked(object? sender, CustomizationEventArgs e)
        {
            if (sender != null)
            {
                BackToMenu(sender, e);
            }

            MenuItemSelection.Visibility = Visibility.Hidden;

            if (e.MenuItem is Pizza)
            {
                if (e.MenuItem is HawaiianPizza)
                {
                    CustomHawiianPizza.Visibility = Visibility.Visible;
                    CustomHawiianPizza.DataContext = e.MenuItem;
                }
                else if (e.MenuItem is MeatsPizza)
                {
                    CustomMeatsPizza.Visibility = Visibility.Visible;
                    CustomMeatsPizza.DataContext = e.MenuItem;
                }
                else if (e.MenuItem is SupremePizza)
                {
                    CustomSupremePizza.Visibility = Visibility.Visible;
                    CustomSupremePizza.DataContext = e.MenuItem;
                }
                else if (e.MenuItem is VeggiePizza)
                {
                    CustomVeggiePizza.Visibility = Visibility.Visible;
                    CustomVeggiePizza.DataContext = e.MenuItem;
                }
                else
                {
                    CustomPizza.Visibility = Visibility.Visible;
                    CustomPizza.DataContext = e.MenuItem;
                }
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
        public void BackToMenu(object sender, RoutedEventArgs e)
        {
            MenuItemSelection.Visibility = Visibility.Visible;

            CustomBreadsticks.Visibility = Visibility.Hidden;
            CustomCinnamonSticks.Visibility = Visibility.Hidden;
            CustomGarlicKnots.Visibility = Visibility.Hidden;
            CustomHawiianPizza.Visibility = Visibility.Hidden;
            CustomIcedTea.Visibility = Visibility.Hidden;
            CustomMeatsPizza.Visibility = Visibility.Hidden;
            CustomSoda.Visibility = Visibility.Hidden;
            CustomSupremePizza.Visibility = Visibility.Hidden;
            CustomPizza.Visibility = Visibility.Hidden;
            CustomVeggiePizza.Visibility = Visibility.Hidden;
            CustomWings.Visibility = Visibility.Hidden;
        }
    }
}
