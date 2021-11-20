using System;
using System.Collections.Generic;
using System.Reflection;
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
using _3280groupProj.Items; /// to access clsMainLogic.cs

namespace _3280groupProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // initialize attributes
            winItem = new Book();
            mainLogic = new clsMainLogic();

            // the invoice number is 0 until it is passed in and changed
            invoiceID = 0;

            bIsNewInvoiceSaved = false;

            // load the combo boxes
            LoadComboBox();

            // so I don't get an error
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }


        #region Attributes

        /// <summary>
        /// object of the Search Window
        /// </summary>
        Search winSearch;

        /// <summary>
        /// object of the Item Window -- the class name is Book
        /// </summary>
        Book winItem;

        /// <summary>
        /// object of the Business Logic class for the Main Window
        /// </summary>
        clsMainLogic mainLogic;

        /// <summary>
        /// used to hold the InvoiceNum of the invoice passed from main
        /// If the there isn't a selected invoice, it's zero
        /// </summary>
        public static int invoiceID;    /// should it be static??

        /// <summary>
        /// holds if a new invoice has been saved
        /// edits the invoice tables instead of adding it
        /// </summary>
        bool bIsNewInvoiceSaved;

        #endregion


        #region Menu


        /// <summary>
        /// When the user clicks the "Search for Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // must instantiate the search window here instead of the constructor
                // won't work otherwise
                winSearch = new Search();

                // close this window and open the search window
                this.Hide();

                // clear the main screen of the canvases
                ClearMain();    // if the user cancels a selection, it will show the refreshed main window

                winSearch.ShowDialog();
                this.Show();    // this window shows again after the search window is closed


                // if the user selects an invoice in the search window, 
                //  the search window will call my ShowSelectedInvoice(int invoiceNum) method     
                //  **** will talk to Amber about this ****
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the user clicks the "Update Items" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // must instantiate the item window here instead of the constructor
                // won't work otherwise
                winItem = new Book();

                // close this window and open the items window
                this.Hide();

                

                winItem.ShowDialog();
                this.Show();

                // clear the main screen of the canvases
                ClearMain();

                // load the combo boxes again -- the user may have changed the items
                LoadComboBox();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion


        #region NewInvoice

        /// <summary>
        /// when a user selects an item from the new invoice items combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // display item and details from combo box in the data grid
                itemDescDataGrid.Items.Add(ItemsCBox.SelectedItem);

                // update the running total

                
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When a user clicks the "Delete Item" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // make sure an item is currently selected in the data grid
                // the item that was selected on the data grid is removed

                // update the running total
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the user tries to enter input into the date text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // make sure that it's numbers and slashes only?
                // prevent spaces, letters, special characters?
                // how do I check if it's a read date?

                // the user MUST enter a date -- show error message
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// when the user clicks the "Save Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // check if the invoice is saved, if not:
                // set the invoice to saved
                // this means that the next time the save button is clicked, 
                //      we update the table instead of add to it
                bIsNewInvoiceSaved = true;

                // if the invoice has already been saved, update the invoice instead of adding it

                // the user cannot save the invoice without adding a date
                // can the user save an invoice without adding items?

                // all data in the invoice is added to the invoice table:
                // - invoice num (automatically created)
                // - invoice date
                // - total cost

                // update the line items table
                // - the new invoice number
                // - the new line item index
                // - the corresponding book
                // - the corresponding price of the book
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion


        #region SelectedInvoice


        /// <summary>
        /// method to show the selected invoice -- CALLED WHEN USER SELECTS AN INVOICE IN THE SEARCH WINDOW
        /// accepts the invoice number -- can then access the other elements
        /// </summary>
        public void ShowSelectedInvoice(int invoiceNum)
        {
            try
            {
                // set the passed int number as the InvoiceId
                invoiceNum = invoiceID;

                // Display the selected invoice canvas
                SelectedInvoiceCanvas.Visibility = Visibility.Visible;
                EditBtn.Visibility = Visibility.Visible;

                // load the selected data grid with the invoice details
                //  - items
                //  - cost
                //  - line item number?
                //  - date?

                // change invoice number label

                // change running total label
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// When the user clicks the "Delete Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelISelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // remove the selected invoice from the Invoice table
                // remove the selected invoice from the LineItems table

                // clear the main screen of the selected invoice
                ClearMain();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// When the user clicks the "Edit Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // make the edit button invisible
                EditBtn.Visibility = Visibility.Hidden;

                // display the editing canvas
                EditInvoiceCanvas.Visibility = Visibility.Visible;

                // show the new invoice in a canvas
                //  - all the items belonging to that invoice 
                //  - should we include invoice date?
                //  - should we include line item number?

                // all items are already loaded to the combobox, no need to load them again

                // once combobox items are selected, they will show up in the data grid
                // a running total of item prices must be displayed
                //  - updated as items are entered or deleted
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the user adds an item to the selected invoice -- editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // display item and details from combo box in the data grid
                itemDescDataGrid1.Items.Add(ItemsCBox2.SelectedItem);

                // update the running total

                
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the user deletes an item in the selected invoice -- editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelItemBtn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // make sure an item is selected in the data grid
                // remove that item from the data grid
                // update the total cost
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the user clicks the "Save Button" for a selected invoice -- editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // save edits to this invoice in the database

                // update the line items table
                // - the new line item indexes
                // - the corresponding books
                // - the corresponding price of the books
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion



        /// <summary>
        /// method to load the items to the combo boxes
        /// </summary>
        private void LoadComboBox()
        {
            try
            {
                // displays list of items in the New Invoice combo box
                ItemsCBox.ItemsSource = mainLogic.GetItems();

                // displays list of items in the New Invoice combo box
                ItemsCBox2.ItemsSource = mainLogic.GetItems();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }



        /// <summary>
        /// method to clear the main window
        /// </summary>
        private void ClearMain()
        {
            try
            {
                // clear the selected invoice canvases *****
                // hide the selected invoice canvases
                SelectedInvoiceCanvas.Visibility = Visibility.Hidden;
                EditInvoiceCanvas.Visibility = Visibility.Hidden;

                // clear the new invoice canvas -- no items in DataGrid ******
                // show the new invoice canvas
                NewInvoiceCanvas.Visibility = Visibility.Visible;

                // clear the date textbox
                DateBox.Text = "";

                // show the total cost as $0.00
                totalLbl.Content = "$0.00";

                // set invoiceID to zero -- we aren't displaying an invoice anymore
                invoiceID = 0;

                // set bool to false -- this is a new invoice
                bIsNewInvoiceSaved = false;
            }
            catch (Exception ex)
            {
                //Just throw the exception -- low level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _3280groupProj.InvoicesDataSet invoicesDataSet = ((_3280groupProj.InvoicesDataSet)(this.FindResource("invoicesDataSet")));
            // Load data into the table ItemDesc. You can modify this code as needed.
            _3280groupProj.InvoicesDataSetTableAdapters.ItemDescTableAdapter invoicesDataSetItemDescTableAdapter = new _3280groupProj.InvoicesDataSetTableAdapters.ItemDescTableAdapter();
            invoicesDataSetItemDescTableAdapter.Fill(invoicesDataSet.ItemDesc);
            System.Windows.Data.CollectionViewSource itemDescViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("itemDescViewSource")));
            itemDescViewSource.View.MoveCurrentToFirst();
            // Load data into the table LineItems. You can modify this code as needed.
            _3280groupProj.InvoicesDataSetTableAdapters.LineItemsTableAdapter invoicesDataSetLineItemsTableAdapter = new _3280groupProj.InvoicesDataSetTableAdapters.LineItemsTableAdapter();
            invoicesDataSetLineItemsTableAdapter.Fill(invoicesDataSet.LineItems);
            System.Windows.Data.CollectionViewSource lineItemsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineItemsViewSource")));
            lineItemsViewSource.View.MoveCurrentToFirst();
        }
    }
}
