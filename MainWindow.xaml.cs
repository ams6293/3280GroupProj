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
            
            bIsDisplayingInvoice = false;
            bIsDisplayingNewInvoice = true;     // the main window is always displaying a new invoice
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
        /// object of the Item class
        /// </summary>
        ///Item cItem;

        /// <summary>
        /// holds if the user has selected an invoice
        /// and it is being displayed
        /// </summary>
        bool bIsDisplayingInvoice;

        /// <summary>
        /// holds if the user has already clicked 
        /// on the new invoice button
        /// </summary>
        bool bIsDisplayingNewInvoice;

        /// <summary>
        /// holds if a new invoice has been saved
        /// edits the invoice instead of adding it
        /// </summary>
        bool bIsNewInvoiceSaved;

        #endregion


        /// <summary>
        /// When the user clicks the "Search for Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            winSearch = new Search();

            // close this window and open the search window
            this.Hide();
            winSearch.ShowDialog();
            this.Show();


            // set is invoice selected to false
            bIsDisplayingInvoice = false;       // DEPENDS ON IF THE USER SELECTS AN INVOICE!!!

            // set is displaying new invoice to false
            bIsDisplayingNewInvoice = false;    // DEPENDS ON IF THE USER SELECTS AN INVOICE!!!

            // clear the main screen of the canvases
            ClearMain();

            // if the user selects an invoice in the search window, 
            //      then I will display that and scrap the ivoice
            //      that the user was previously making

            // but if the user cancels the search window
            //      do I keep the invoice they were working on?
        }

        /// <summary>
        /// When the user clicks the "Update Items" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            winItem = new Book();

            // close this window and open the items window
            this.Hide();
            winItem.ShowDialog();
            this.Show();

            // set is invoice selected to false
            bIsDisplayingInvoice = false;

            // set is displaying new invoice to true -- when we get back, the 
            bIsDisplayingNewInvoice = true;

            // clear the main screen of the canvases
            ClearMain();

            // if the user is in the process of making a new invoice
            //      should that invoice be scrapped when the main window
            //      opens back up, or should it still be there?

        }

        /// <summary>
        /// When the user clicks the "Create New Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvBtn_Click(object sender, RoutedEventArgs e)
        {
            // set is invoice selected to false
            bIsDisplayingInvoice = false;

            // set is displaying new invoice to true
            bIsDisplayingNewInvoice = true;

            // clear the main screen of the canvases
            ClearMain();

            // show the new invoice in a canvas
            // all items will be loaded into a combobox ---- with be current with all items in the table
            // once combobox items are selected, they will show up in the data grid
            // a running total of item prices must be displayed and updated
            //      as items are entered or deleted
            //      -- in a label below the data grid?

            // if a user is already in the process of making an invoice, 
            // I'll scrap the invoice
        }

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
            // the item that was selected on the data grid is removed from the 
            //      invoice and data grid

            // update the running total
        }

        /// <summary>
        /// When the user tries to enter input into the date text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // make sure that it's numbers and slashes only?
            // prevent spaces, letters, special characters?

            // the user MUST enter a date
        }

        /// <summary>
        /// when the user clicks the "Save Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // set the invoice to saved
            // this means that the next time the save button is clicked, 
            //      we update the table instead of add to it
            bIsNewInvoiceSaved = true;

            // the user cannot save the invoice without adding a date

            // all data in the invoice is added to the invoice table:
            // - invoice num (automatically created)
            // - invoice date
            // - total cost

            // update the line items table -- is this automatic with the changes to the invoice table?
            // - the new invoice number
            // - the new line item index
            // - the corresponding book
            // - the corresponding price of the book

            // make the new invoice invisible? -- or keep it?

            try
            {
                
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            

        }





        /////////////////////////////////////////////////////////////////////////////////////////
        /// SELECTED INVOICE BELOW


        /// <summary>
        /// method to show the selected invoice -- CALLED WHEN USER SELECTS AN INVOICE IN THE SEARCH WINDOW
        /// accepts the invoice number -- can then access the other elements
        /// </summary>
        public void ShowSelectedInvoice(int invoiceNum)
        {
            // selected invoice is now shown
            bIsDisplayingInvoice = true;

            // set is displaying new invoice to false
            bIsDisplayingNewInvoice = false;

            // call business logic methods to get information

            // load the search window with information about the invoice

            // set SearchCanvas to visible

            // change invoice number label

            // change running total
        }


        /// <summary>
        /// When the user clicks the "Delete Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelISelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            // set is invoice selected to false
            bIsDisplayingInvoice = false;

            // set is displaying new invoice to false
            bIsDisplayingNewInvoice = false;

            // remove the selected invoice from the database

            // clear the main screen of the canvases
            ClearMain();

        }

        /// <summary>
        /// When the user clicks the "Edit Invoice" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // show the options to edit the invoice
            //      change edit canvas visibility

            // show the new invoice in a canvas
            // all items will be loaded into a combobox ---- with be current with all items in the table
            // once combobox items are selected, they will show up in the data grid
            // a running total of item prices must be displayed and updated
            //      as items are entered or deleted
            //      -- in a label below the data grid?

            // change the "Edit Invoice" button visibility -- make invisible
        }

        /// <summary>
        /// When the user adds an item to the selected invoice -- editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // show item in data grid
            

            // change the running total
        }

        /// <summary>
        /// When the user deletes an item in the selected invoice -- editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelItemBtn2_Click(object sender, RoutedEventArgs e)
        {
            // the item that was selected on the data grid is removed from the 
            //      invoice and data grid

            // set is invoice selected to false
            bIsDisplayingInvoice = false;

            // set is displaying new invoice to false
            bIsDisplayingNewInvoice = false;

            // clear the main screen of the canvases
            ClearMain();

            // update the running total
        }

        /// <summary>
        /// When the user clicks the "Save Button" for a selected invoice -- editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn2_Click(object sender, RoutedEventArgs e)
        {
            // edits the invoice in the table
            // - total cost

            // update the line items table -- is this automatic with the changes to the invoice table?
            // - the new line item indexes
            // - the corresponding books
            // - the corresponding price of the books
        }


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
            // reset the new invoice canvases

            // show the new invoice canvas

            // reset the selected invoice canvas

            // clear all labels and text boxes

            // set bool to false
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
