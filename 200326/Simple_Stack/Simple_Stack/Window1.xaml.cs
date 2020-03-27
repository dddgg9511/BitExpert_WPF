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

namespace Simple_Stack
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Boader_Test boader = new Boader_Test();
            boader.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Layout_Panels layout = new Layout_Panels();
            layout.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DockPanel dock = new DockPanel();
            dock.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BasicDialogBox basicDialogBox = new BasicDialogBox();
            basicDialogBox.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            GridView grid = new GridView();
            grid.ShowDialog();
            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            GridView_Sizemode grid = new GridView_Sizemode();
            grid.ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Answer answer = new Answer();
            answer.ShowDialog();
        }
    }
}
