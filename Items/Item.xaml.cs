using _3280groupProj.Items;
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
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Book : Window
    {
        /// <summary>
        /// This is the link to be Items business logic
        /// </summary>
        clsItemsLogic ItemsLogic = new clsItemsLogic();

        public Book()
        {
            InitializeComponent();

        }
        /// <summary>
        /// this button displays the entire inventory of items in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchItems_Click(object sender, RoutedEventArgs e)
        {
            dgItems.ItemsSource = ItemsLogic.getItems();
        }
        /// <summary>
        /// this event allows the user to update an item's desc and/or cost in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbItemCost.Text == "")
                {
                    MessageBox.Show("Please enter an item code, item cost, and item description.");
                }
                else if (tbItemDesc.Text == "")
                {
                    MessageBox.Show("Please enter an item code, item cost, and item description.");
                }
                else if (tbItemCode2.Text == "")
                {
                    MessageBox.Show("Please enter an item code, item cost, and item description.");
                }
                else
                {
                    int iItemCost;
                    iItemCost = Int32.Parse(tbItemCost.Text);
                    ItemsLogic.updateItem(tbItemDesc.Text, iItemCost, tbItemCode2.Text);
                    MessageBox.Show("Item '" + tbItemCode2.Text + "' updated.");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show($"There was a problem updating the item information: {a.Message}");
            }
        }
        /// <summary>
        /// this event allows the user to add an row to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (tbItemCost.Text == "")
                {
                    MessageBox.Show("Please enter an item code, item cost, and item description.");
                }
                else if (tbItemDesc.Text == "")
                {
                    MessageBox.Show("Please enter an item code, item cost, and item description.");
                }
                else if (tbItemCode2.Text == "")
                {
                    MessageBox.Show("Please enter an item code, item cost, and item description.");
                }
                else 
                { 
                int iItemCost;
                iItemCost = Int32.Parse(tbItemCost.Text);
                ItemsLogic.insertNewItem(tbItemDesc.Text, iItemCost, tbItemCode2.Text);
                MessageBox.Show("New item '" + tbItemCode2.Text + "' added.");
                }
            }
            catch (Exception b)
            {
                MessageBox.Show($"There was a problem enter the new item information: {b.Message}");
            }
        }
        /// <summary>
        /// this event removes a row from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbItemCode2.Text == "")
                {
                    MessageBox.Show("Please enter an Item Code to delete.");
                }
                else
                {
                    ItemsLogic.deleteItem(tbItemCode2.Text);
                    MessageBox.Show("'" + tbItemCode2.Text + "' deleted.");
                }
            }
            catch (Exception c)
            {
                MessageBox.Show($"There was a problem deleting the item: {c.Message}");
            }
        }
        /// <summary>
        /// this button event will return to main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMain_Click (object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
