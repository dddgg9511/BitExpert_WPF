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

namespace _200331
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        enum SplitViewMenuWidth
        {
            Narrow = 48,
            Wide = 240
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SprocketButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Window_Button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window1 = new Window2();
            window1.Show();
        }

        private void Window_Button3_Click(object sender, RoutedEventArgs e)
        {
            Window3 window1 = new Window3();
            window1.Show();
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
    }
}
