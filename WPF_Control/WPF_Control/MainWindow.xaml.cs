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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ElementBinding
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        enum SplitViewMenuWidth
        {
            Narrow = 48,
            Wide = 240
        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            // toggle menu width
            SplitViewMenu.Width = (int)SplitViewMenu.Width == (int)SplitViewMenuWidth.Narrow
                                      ? (int)SplitViewMenuWidth.Wide
                                      : (int)SplitViewMenuWidth.Narrow;

            // reset column width in the column definition based on window size
            RootGrid.ColumnDefinitions[0].Width = new GridLength(GetColumnZeroWidth());
        }

        private int GetColumnZeroWidth()
        {
            // determine how wide column zero should be based on window size
            // if window is maximized, column zero width is equal to current menu width.
            // if window is normal, column zero width is equal to narrow menu width
            return WindowState == WindowState.Maximized
                       ? (int)SplitViewMenu.Width
                       : (int)SplitViewMenuWidth.Narrow;

        }

        private void BasicBindButton_Checked(object sender, RoutedEventArgs e)
        {
            BasicBinding.Visibility = Visibility.Visible;

        }

        private void BasicBindingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            BasicBinding.Visibility = Visibility.Hidden;
        }

        private void RadioButton_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        private void ElementToElement_Checked(object sender, RoutedEventArgs e)
        {
            ElementBinding.Visibility = Visibility.Visible;
        }

       

        private void ElementToElement_Unchecked(object sender, RoutedEventArgs e)
        {
            ElementBinding.Visibility = Visibility.Hidden;
        }

        private void FWPButton_Checked(object sender, RoutedEventArgs e)
        {
            MultipleBinding.Visibility = Visibility.Visible;
        }

        private void FWPButton_Unchecked(object sender, RoutedEventArgs e)
        {
            MultipleBinding.Visibility = Visibility.Hidden;
        }

        private void FPPButton_Checked(object sender, RoutedEventArgs e)
        {
            Relative.Visibility = Visibility.Visible;
        }

        private void FPPButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Relative.Visibility = Visibility.Hidden;
        }

        private void FPBButton_Checked(object sender, RoutedEventArgs e)
        {
            DataC.Visibility = Visibility.Visible;
        }

        private void FPBButton_Unchecked(object sender, RoutedEventArgs e)
        {
            DataC.Visibility = Visibility.Hidden;
        }

        private void SparkWindowButton_Checked(object sender, RoutedEventArgs e)
        {
            SourceBind.Visibility = Visibility.Visible;
        }

        private void SparkWindowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SourceBind.Visibility = Visibility.Hidden;
        }

        private void FPBButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void FPBButton_Unchecked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
