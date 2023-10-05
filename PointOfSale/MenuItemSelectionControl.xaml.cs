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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Initializes the MenuItemSelectionControl.
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void BuildYourOwnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new Pizza());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void SupremeClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new SupremePizza());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void MeatsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new MeatsPizza());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void VeggieClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new VeggiePizza());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void HawaiianClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new HawaiianPizza());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void BreadsticksClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new Breadsticks());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void GarlicKnotsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new GarlicKnots());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void CinnamonSticksClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new CinnamonSticks());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void WingsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new Wings());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void SodaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new Soda());
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void IcedTeaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> o) o.Add(new IcedTea());
        }
    }
}
