﻿using System;
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
        public Search()
        {
            InitializeComponent();
        }

        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            //This needs to take the users selected invoice based on the InvoiceID back to the main form
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //This will reset the form
        }
    }
}
