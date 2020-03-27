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

namespace _200327
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Spaning spaning = new Spaning();
            spaning.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SplitingWindow spliting = new SplitingWindow();
            spliting.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DoubleSplit doubleSplit = new DoubleSplit();
            doubleSplit.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Shared_SizeGroup shared = new Shared_SizeGroup();
            shared.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            LocalizableText localizableText = new LocalizableText();
            localizableText.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ModularContent modular = new ModularContent();
            modular.Show();
        }
    }
}
