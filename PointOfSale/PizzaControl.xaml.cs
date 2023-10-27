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
using PizzaParlor.Data;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for PizzaControl.xaml
    /// </summary>
    public partial class PizzaControl : UserControl
    {
        /// <summary>
        /// Constructor for the PizzaControl.
        /// </summary>
        public PizzaControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the pizza topping choices.
        /// </summary>
        public void LoadChoices()
        {
            checkBoxes.Children.Clear();
            if (DataContext is Pizza p)
            {
                foreach (PizzaTopping topping in p.PossibleToppings)
                {
                    CheckBox box = new CheckBox();
                    box.DataContext = topping;
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath(nameof(topping.OnPizza));
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding);

                    TextBlock block = new TextBlock();
                    block.Text = topping.Name;
                    box.Content = block;

                    checkBoxes.Children.Add(box);
                }
            }
        }
    }
}