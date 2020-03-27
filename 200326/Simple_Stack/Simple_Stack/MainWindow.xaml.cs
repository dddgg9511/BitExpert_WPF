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

namespace Simple_Stack
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Boader_Test boader = new Boader_Test();
            boader.ShowDialog();
        }

        private void chkVertical_Checked(object sender, RoutedEventArgs e)
        {
            stackPanel1.Orientation = Orientation.Horizontal;
        }

        private void chkVertical_Unchecked(object sender, RoutedEventArgs e)
        {
            stackPanel1.Orientation = Orientation.Vertical;
        }
    }
}
