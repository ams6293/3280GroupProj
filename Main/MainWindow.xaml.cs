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
            sum = 0;
            bIsEditing = false;
            bIsClearingBox = false;

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

        /// <summary>
        /// holds the running total
        /// </summary>
        int sum;

        /// <summary>
        /// holds if an invoice is being edited
        /// </summary>
        bool bIsEditing;

        /// <summary>
        /// holds whether we are clearing a combobox
        /// </summary>
        bool bIsClearingBox;

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

                // check if an invoice is selected
                if (winSearch.hasSelectedInvoiceID != false)
                {
                    // if so, set my invoiceID variable to the invoiceID variable in the Search window
                    // like this...
                    invoiceID = winSearch.invoiceID;

                    // show the selected invoice
                    ShowSelectedInvoice();
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
        /// When the user clicks the "Update Items" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bIsEditing == false)
                {
                    // clear the main screen of the canvases
                    ClearMain();

                    // must instantiate the item window here instead of the constructor
                    // won't work otherwise
                    winItem = new Book();

                    // close this window and open the items window
                    this.Hide();
                    winItem.ShowDialog();

                    // show the main window again when the items window closes
                    this.Show();

                    // reload the combo boxes after exiting the window -- items may have changed
                    LoadComboBox();
                }
                // else, do nothing
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
                if (bIsClearingBox == false)
                {
                    // display item and details from combo box in the data grid
                    itemDescDataGrid.Items.Add(ItemsCBox.SelectedItem);

                    // update the running total
                    var item = ((sender as ComboBox).SelectedItem as Item);
                    sum += item.Cost;

                    // display the running total
                    totalLbl.Content = "$ " + sum + ".00";

                    // an invoice is being edited
                    bIsEditing = true;
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
                    if (itemDescDataGrid.SelectedItem != null && bIsClearingBox == false)
                    {
                        // update the running total
                        var item = itemDescDataGrid.SelectedItem as Item;
                        sum -= item.Cost;

                        // the item that was selected on the data grid is removed
                        itemDescDataGrid.Items.Remove(itemDescDataGrid.SelectedItem);
                    }
                    // display the new total
                    totalLbl.Content = "$ " + sum + ".00";
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
                if (datePicker.SelectedDate != null && bIsClearingBox == false)
                {
                    // get the date in the proper format
                    string date = datePicker.SelectedDate.Value.Date.ToShortDateString();

                    // convert all items in the datagrid to a list
                    var list = itemDescDataGrid.Items.OfType<Item>();

                    // insert all of the items into the Invoice and LineItems tables -- and get the new Invoice ID
                    invoiceID = mainLogic.InsertInvoice(list.ToList(), invoiceID, sum, date);

                    // reload the combo boxes
                    LoadComboBox();

                    // an invoice is NOT being edited
                    bIsEditing = false;

                    // then show selected invoice
                    ShowSelectedInvoice();
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

                // hide the new invoice
                NewInvoiceCanvas.Visibility = Visibility.Hidden;

                // Display the selected invoice canvas
                SelectedInvoiceCanvas.Visibility = Visibility.Visible;
                EditBtn.Visibility = Visibility.Visible;

                // load the selected data grid with the invoice details
                itemDescDataGrid1.ItemsSource = mainLogic.GetSelectedInvoice(invoiceID);

                // change invoice number label
                invoiceNumLbl.Content = invoiceID.ToString();

                // get the total cost of the invoice
                sum = mainLogic.GetCost(invoiceID);

                // change running total label
                totalLbl2.Content = "$ " + sum + ".00";
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

                // an invoice is NOT being edited
                bIsEditing = false;
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

                // an invoice is being edited
                bIsEditing = true;

                // make sure the comboboxes are reloaded
                LoadComboBox();

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
                // make sure the we have something in the comboboxes
                if (bIsClearingBox == false)
                {
                    // create a copy of the list that makes up the item source
                    var lstItem = (IList<Item>)itemDescDataGrid1.ItemsSource;

                    // null the datagrid? YES
                    itemDescDataGrid1.ItemsSource = null;

                    // add the selected item to that list
                    lstItem.Add((Item)ItemsCBox2.SelectedItem);

                    // bind the datagrid to the new list
                    itemDescDataGrid1.ItemsSource = lstItem;

                    // update the running total
                    var item = ((sender as ComboBox).SelectedItem as Item);
                    sum += item.Cost;

                    // display the running total
                    totalLbl2.Content = "$ " + sum + ".00";
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
                        // update the running total
                        var item = itemDescDataGrid1.SelectedItem as Item;
                        sum -= item.Cost;

                        // create a copy of the list that makes up the item source
                        var lstItem = (IList<Item>)itemDescDataGrid1.ItemsSource;

                        // null the datagrid? YES
                        itemDescDataGrid1.ItemsSource = null;

                        // remove the selected item from the list
                        lstItem.Remove(item);

                        // bind the datagrid to the list copy
                        itemDescDataGrid1.ItemsSource = lstItem;
                    }
                    // display the running total
                    totalLbl2.Content = "$ " + sum + ".00";
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
                // remove the editing canvas
                EditInvoiceCanvas.Visibility = Visibility.Hidden;

                // convert all items in the datagrid to a list
                var list = itemDescDataGrid1.Items.OfType<Item>();

                // update the Invoice and LineItems tables
                mainLogic.UpdateInvoice(list.ToList(), invoiceID, sum);

                // then show selected invoice
                ShowSelectedInvoice();

                // an item is NOT being edited
                bIsEditing = false;
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
                // making sure the combo boxes are emptied before being filled
                // I think only the New Invoice combo box needs this
                bIsClearingBox = true;
                ItemsCBox.SelectedIndex = -1;
                ItemsCBox.SelectedItem = null;
                ItemsCBox.Text = "";

                // displays list of items in the New Invoice combo box
                ItemsCBox.ItemsSource = mainLogic.GetItems();

                // displays list of items in the New Invoice combo box
                ItemsCBox2.ItemsSource = mainLogic.GetItems();

                // the combo boxes are filled
                bIsClearingBox = false;
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
                // clear the selected invoice canvases
                itemDescDataGrid1.ItemsSource = null;
                itemDescDataGrid1.Items.Clear();

                // hide the selected invoice canvases & button
                SelectedInvoiceCanvas.Visibility = Visibility.Hidden;
                EditInvoiceCanvas.Visibility = Visibility.Hidden;
                EditBtn.Visibility = Visibility.Hidden;

                // clear the new invoice canvas -- no items in DataGrid
                itemDescDataGrid.Items.Clear();

                // show the new invoice canvas
                NewInvoiceCanvas.Visibility = Visibility.Visible;

                // show the total cost as $0.00
                totalLbl.Content = "$0.00";

                // clear the selected date
                datePicker.SelectedDate = null;

                // set invoiceID to zero -- we aren't displaying an invoice anymore
                invoiceID = 0;

                // set the total cost to zero
                sum = 0;

                // reload the combo boxes
                LoadComboBox();

                // an invoice is NOT being edited
                bIsEditing = false;
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
