using PizzaParlor.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public PaymentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button click event for PaidBoxInput
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">The arguements passed.</param>
        public void PaidBoxInput(object sender, RoutedEventArgs e)
        {
            if (DataContext is PaymentViewModel p)
            {
                try //can i do this without trycatch?
                {
                    p.Paid = Convert.ToDecimal(PaidBox.Text);
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// Button click event for Finalize
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">The arguements passed.</param>
        public void Finalize(object sender, RoutedEventArgs e)
        {
            if (DataContext is PaymentViewModel p)
            {
                File.AppendAllText("recipt.txt", p.Recipt);
            }
            if (this.Parent is Grid g && g.Parent is MainWindow mw)
            {
                mw.DataContext = new Order();
                mw.Payment.Visibility = Visibility.Hidden;
                mw.MenuItemSelection.Visibility = Visibility.Visible;
            }
        }
    }
}
