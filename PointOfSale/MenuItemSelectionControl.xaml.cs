using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Event Handler for when a MenuItem is clicked.
        /// </summary>
        public event EventHandler<CustomizationEventArgs>? MenuItemClicked;


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
            Pizza p = new Pizza();
            if (DataContext is Order o) o.Add(p);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(p));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void SupremeClick(object sender, RoutedEventArgs e)
        {
            SupremePizza p = new SupremePizza();
            if (DataContext is Order o) o.Add(p);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(p));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void MeatsClick(object sender, RoutedEventArgs e)
        {
            MeatsPizza p = new MeatsPizza();
            if (DataContext is Order o) o.Add(p);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(p));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void VeggieClick(object sender, RoutedEventArgs e)
        {
            VeggiePizza p = new VeggiePizza();
            if (DataContext is Order o) o.Add(p);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(p));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void HawaiianClick(object sender, RoutedEventArgs e)
        {
            HawaiianPizza p = new HawaiianPizza();
            if (DataContext is Order o) o.Add(p);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(p));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void BreadsticksClick(object sender, RoutedEventArgs e)
        {
            Breadsticks b = new Breadsticks();
            if (DataContext is Order o) o.Add(b);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(b));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void GarlicKnotsClick(object sender, RoutedEventArgs e)
        {
            GarlicKnots k = new GarlicKnots();
            if (DataContext is Order o) o.Add(k);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(k));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void CinnamonSticksClick(object sender, RoutedEventArgs e)
        {
            CinnamonSticks c = new CinnamonSticks();
            if (DataContext is Order o) o.Add(c);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(c));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void WingsClick(object sender, RoutedEventArgs e)
        {
            Wings w = new Wings();
            if (DataContext is Order o) o.Add(w);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(w));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void SodaClick(object sender, RoutedEventArgs e)
        {
            Soda s = new Soda();
            if (DataContext is Order o) o.Add(s);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(s));
        }

        /// <summary>
        /// Event for when the user clicks on 'Build-Your-Own' button.
        /// </summary>
        /// <param name="sender">Contains a reference to the button.</param>
        /// <param name="e">Contains the event data.</param>
        public void IcedTeaClick(object sender, RoutedEventArgs e)
        {
            IcedTea i = new IcedTea();
            if (DataContext is Order o) o.Add(i);
            MenuItemClicked?.Invoke(this, new CustomizationEventArgs(i));
        }
    }
}
