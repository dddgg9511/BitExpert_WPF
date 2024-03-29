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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSparkClient
{
    /// <summary>
    /// UserControl3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        private ICollection<Employee> products;
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = HrDAC.Instance.GetEmployeeList();
            lstProducts.ItemsSource = products;
        }
    }
}
