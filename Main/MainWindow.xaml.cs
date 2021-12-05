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
        /// a property that get the InvoiceNum of the invoice passed
        /// from the search window
        /// </summary>
        int invoiceID { get; set; }

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
                // clear the main screen of the canvases
                ClearMain();    // if the user cancels a selection, it will show the refreshed main window

                // must instantiate the search window here instead of the constructor
                // won't work otherwise
                winSearch = new Search();

                // close this window and open the search window
                this.Hide();

                winSearch.ShowDialog();
                this.Show();    // this window shows again after the search window is closed

                // check if an invoice is selected -- should there be a bool for this in the Search window?     ////////////////////// TALK TO AMBER
                // like this...
                // if (winSearch.bIsInvoiceSelected != false) { do stuff }
                // if so, set my invoiceID variable to the invoiceID variable in the Search window
                // like this...
                // InvoiceID = winSearch.invoiceNum;
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
                //LoadComboBox(); -- is causing an error
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

                ////////////////////////////////////////////////////////////////////////////////////// Doesn't work!!! -- starts an index behind
               int sum = 0;
               for (int i = 0; i < itemDescDataGrid.Items.Count - 1; i++)
                {

                    sum += (Int32.Parse((itemDescDataGrid.Columns[2].GetCellContent(itemDescDataGrid.Items[i]) as TextBlock).Text)); 
                }

                totalLbl.Content = "$ " + sum + ".00";


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
                if (itemDescDataGrid.SelectedIndex >= 0)
                {
                    // make sure the row isn't empty
                    if (itemDescDataGrid.SelectedItem != null)
                    {
                        // the item that was selected on the data grid is removed
                        itemDescDataGrid.Items.Remove(itemDescDataGrid.SelectedItem);
                    }
                    // update the running total         ///////////////////////////////////////////////////////// TODO
                }

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
                // check if there's a date selected
                if (datePicker.SelectedDate != null)
                {
                    // can the user save an invoice without adding items?

                    // all data in the invoice is added to the invoice table: -- how?       //////////////////////////////  TODO
                    // - invoice num (automatically created)
                    // - invoice date
                    // - total cost

                    // update the line items table
                    // - the new invoice number
                    // - the new line item index
                    // - the corresponding book
                    // - the corresponding price of the book
                }
                else
                {
                    // an error message is shown
                    MessageBox.Show("You must select a date", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }

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
        /// method to show the selected invoice
        /// </summary>
        public void ShowSelectedInvoice()
        {
            try
            {
                // bind the selected invoice to the datagrid
                itemDescDataGrid1.ItemsSource = mainLogic.GetSelectedInvoice(invoiceID);

                // Display the selected invoice canvas
                SelectedInvoiceCanvas.Visibility = Visibility.Visible;
                EditBtn.Visibility = Visibility.Visible;

                // load the selected data grid with the invoice details
                // change the item source
                //  - items
                //  - cost
                //  - line item number?
                //  - date?

                // change invoice number label
                invoiceNumLbl.Content = invoiceID.ToString();

                // change running total label
                totalLbl2.Content = 0; /////////////////////////////////////////////////////////////////// TODO
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
                // remove the selected invoice from the database
                mainLogic.DeleteInvoice(invoiceID);

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

                // all items are already loaded to the combobox, no need to load them again
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

                // update the running total                         //////////////////////////////////////////////// TODO

                
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
                // make sure an item is currently selected in the data grid
                if (itemDescDataGrid1.SelectedIndex >= 0)
                {
                    // make sure the row isn't empty
                    if (itemDescDataGrid1.SelectedItem != null)
                    {
                        // the item that was selected on the data grid is removed
                        itemDescDataGrid1.Items.Remove(itemDescDataGrid1.SelectedItem);
                    }
                    // update the running total         ///////////////////////////////////////////////////////// TODO
                }
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

                // remove the editing canvas
                // show the selected canvas
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
                itemDescDataGrid1.ItemsSource = null;   ////////////////////////////////////// trying this...
                itemDescDataGrid1.Columns.Clear();

                // hide the selected invoice canvases
                SelectedInvoiceCanvas.Visibility = Visibility.Hidden;
                EditInvoiceCanvas.Visibility = Visibility.Hidden;

                // clear the new invoice canvas -- no items in DataGrid ******
                itemDescDataGrid.ItemsSource = null;   ////////////////////////////////////// trying this...
                itemDescDataGrid.Columns.Clear();

                // show the new invoice canvas
                NewInvoiceCanvas.Visibility = Visibility.Visible;

                // show the total cost as $0.00
                totalLbl.Content = "$0.00";

                // set invoiceID to zero -- we aren't displaying an invoice anymore
                invoiceID = 0;
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

        /// <summary>
        /// loads the window?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
