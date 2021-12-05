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
using System.Windows.Shapes;

namespace _3280groupProj
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        /// <summary>
        /// this is a link to the business logic
        /// </summary>
        clsSearchLogic searchLogic = new clsSearchLogic();
        public Search()
        {
            InitializeComponent();
            try
            {
                dgInvoices.ItemsSource = searchLogic.getInvoices();
            }
            catch (Exception e)
            {

                MessageBox.Show($"There was a problem getting Invoice information: {e.Message}");
            }
            try
            {
                invoiceNumberDropDown.ItemsSource = searchLogic.getInvoiceNums();
            }
            catch (Exception a)
            {

                MessageBox.Show($"There was a problem getting Invoice Number information: {a.Message}");
            }
            try
            {
                invoiceDateDropDown.ItemsSource = searchLogic.getInvoiceDates();
            }
            catch (Exception b)
            {

                MessageBox.Show($"There was a problem getting Invoice Date information: {b.Message}");
            }
            try
            {
                totalChargeDropDown.ItemsSource = searchLogic.getInvoiceTotalCosts();
            }
            catch (Exception c)
            {

                MessageBox.Show($"There was a problem getting Invoice Date information: {c.Message}");
            }
            
        }

        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            //This needs to take the users selected invoice based on the InvoiceID back to the main form
            this.Close();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //This will reset the form for now it closes the window
            this.Close();

        }
    }
}
