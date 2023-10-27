/* PaymentViewModel.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using PizzaParlor.Data;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Serves as the ViewModel for the payment control.
    /// </summary>
    public class PaymentViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for property changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property changed method.
        /// </summary>
        /// <param name="propertyName">The name of the property changed.</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Private order field.
        /// </summary>
        private Order _order;

        /// <summary>
        /// The tax of the bill.
        /// </summary>
        public decimal Tax { get => _order.Tax; }

        /// <summary>
        /// The subtotal of the bill.
        /// </summary>
        public decimal Subtotal { get => _order.Subtotal; }

        /// <summary>
        /// The total of the bill.
        /// </summary>
        public decimal Total { get => _order.Total; }

        /// <summary>
        /// Private backing field for Paid, set during constructor.
        /// </summary>
        private decimal _paid;

        /// <summary>
        /// The amount the user paid for the order.
        /// </summary>
        public decimal Paid
        {
            get
            {
                return _paid;
            }
            set
            {
                if (value >= Total)
                {
                    _paid = value;
                    OnPropertyChanged(nameof(Paid));
                    OnPropertyChanged(nameof(Change));
                    OnPropertyChanged(nameof(Recipt));
                }
            }
        }

        /// <summary>
        /// The user's change after making their payment.
        /// </summary>
        public decimal Change //is this readonly
        {
            get
            {
                return Paid - Total;
            }
        }

        /// <summary>
        /// The reciept for the order.
        /// </summary>
        public string Recipt
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Order Number: " + _order.Number.ToString());
                sb.AppendLine(_order.PlacedAt.ToString() + "\n");

                foreach (IMenuItem m in _order)
                {
                    sb.Append(m.ToString());
                    sb.AppendLine(String.Format(" {0:C2}", m.Price));
                    foreach (string s in m.SpecialInstructions)
                    {
                        sb.AppendLine("  +  " + s);
                    }
                    sb.AppendLine();
                }

                sb.AppendLine(String.Format("Subtotal: {0:C2}", Subtotal)); 
                sb.AppendLine(String.Format("Tax: {0:C2}", Tax));
                sb.AppendLine(String.Format("Total: {0:C2}\n", Total));
                sb.AppendLine(String.Format("Paid: {0:C2}", Paid));
                sb.AppendLine(String.Format("Change: {0:C2}", Change));
                sb.AppendLine("---------------------------");

                return sb.ToString();
            }
        }

        /// <summary>
        /// Constructs a PaymentViewModel.
        /// </summary>
        public PaymentViewModel(Order order)
        {
            _order = order;
            _paid = order.Total;
        }
    }
}
