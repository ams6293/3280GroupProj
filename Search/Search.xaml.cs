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
using System.Reflection;

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
        int invoiceID;
        bool hasSelectedInvoiceID = false;
        public Search()
        {
            InitializeComponent();
            try
            {
                dgInvoices.ItemsSource = searchLogic.getInvoices();
                invoiceNumberDropDown.ItemsSource = searchLogic.getInvoiceNums();
                invoiceDateDropDown.ItemsSource = searchLogic.getInvoiceDates();
                totalChargeDropDown.ItemsSource = searchLogic.getInvoiceTotalCosts();
                hasSelectedInvoiceID = false;
            }
            catch (Exception ex)
            {

                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
           
            
        }

        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            //This needs to take the users selected invoice based on the InvoiceID back to the main form
            Invoice invoice = (Invoice)dgInvoices.SelectedItem;
            invoiceID = invoice.InvoiceNum;
            
            hasSelectedInvoiceID = true;
            
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            totalChargeDropDown.SelectedIndex = -1;
            invoiceDateDropDown.SelectedIndex = -1;
            invoiceNumberDropDown.SelectedItem = -1;
            dgInvoices.ItemsSource = searchLogic.getInvoices();
           
            


        }

        private void invoiceNumberDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                setFilter();
            }
            catch (Exception ex)
            {

                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        private void invoiceDateDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                setFilter();
            }
            catch (Exception ex)
            {

                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void totalChargeDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                setFilter();
            }
            catch (Exception ex)
            {

                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        private void setFilter()
        {
            var invoiceDate = "";
            var invoiceCost = "";
            var invoiceID = "";
            if(invoiceDateDropDown.SelectedItem == null)
            {
                invoiceDate = "";
            }
            else
            {
                invoiceDate = invoiceDateDropDown.SelectedItem.ToString();
            }

            if(totalChargeDropDown.SelectedItem == null)
            {
                invoiceCost = "";
            }
            else
            {
                invoiceCost = totalChargeDropDown.SelectedItem.ToString();
            }
            if(invoiceNumberDropDown.SelectedItem == null)
            {
                invoiceID = "";
            }
            else
            {
                invoiceID = invoiceNumberDropDown.SelectedItem.ToString();
            }
            dgInvoices.ItemsSource = searchLogic.getFilterResults(invoiceID, invoiceDate, invoiceCost);
        }
        /// <summary>
        /// Handle the error -- for top-level methods
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }

}
