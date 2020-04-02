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

namespace WPFSparkClient
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            data.DataContext = HrDAC.Instance.GetEmployee(100);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            long id;
            if(long.TryParse(emp_id.Text,out id))
            {
                try
                {
                    data.DataContext = HrDAC.Instance.GetEmployee(int.Parse(emp_id.Text));
                }
                catch
                {
                    MessageBox.Show("DB ERROR");
                }
            }
            else
            {
                MessageBox.Show("잘못된 입력");
            }
        }
    }
}
