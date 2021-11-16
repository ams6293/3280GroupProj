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
        WndUpdateItem updateItem;

        wndNewItem newItem;

        WndDeleteItem deleteItem;

        public Book()
        {
            InitializeComponent();

            updateItem = new WndUpdateItem();

            newItem = new wndNewItem();

            deleteItem = new WndDeleteItem();
        }

        private void btnUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            updateItem.ShowDialog();

            this.Show();
        }

        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            newItem.ShowDialog();

            this.Show();
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            deleteItem.ShowDialog();

            this.Show();
        }
    }
}
