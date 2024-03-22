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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            const int DELIV_FEE = 25;
            const int WRAP_FEE = 5;
            const decimal GST_RATE = 1.1m;

            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
                string totalprice = Convert.ToString(cProduct.TotalPayment + DELIV_FEE);
                string totalpriceafterwrap = Convert.ToString(cProduct.TotalPayment + DELIV_FEE + WRAP_FEE);
                string totalpriceaftergst = Convert.ToString((cProduct.TotalPayment + DELIV_FEE + WRAP_FEE) * GST_RATE);
                

                chargeAfterDeliveryTextBlock.Text = totalprice;
                chargeAfterWrapTextBlock.Text = totalpriceafterwrap;
                chargeAfterGstTextBlock.Text = totalpriceaftergst;
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }


        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
