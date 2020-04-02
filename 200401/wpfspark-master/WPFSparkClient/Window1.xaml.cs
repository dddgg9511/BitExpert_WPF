using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFSpark;
using static WPFSparkClient.NET46.MainWindow;

namespace WPFSparkClient
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            var items = new ObservableCollection<PivotItem>();

            var colors = new[] { "first"};
            var brushes = new Brush[] { Brushes.Orange, Brushes.Green, Brushes.Blue, Brushes.Magenta, Brushes.Cyan };
            var data = new List<List<TextMessage>>
            {
                new List<TextMessage>()
                {
                    new TextMessage {MainText = "design one", SubText = "Lorem ipsum dolor sit amet"},
                    new TextMessage {MainText = "design two", SubText = "consectetur adipisicing elit"},
                    new TextMessage {MainText = "design three", SubText = "sed do eiusmod tempor incididunt"},
                    new TextMessage {MainText = "design four", SubText = "ut labore et dolore magna aliqua"},
                    new TextMessage {MainText = "design five", SubText = "Ut enim ad minim veniam"},
                    new TextMessage {MainText = "design six", SubText = "quis nostrud exercitation ullamco laboris"},
                    new TextMessage {MainText = "design seven", SubText = "nisi ut aliquip ex ea commodo consequat"}
                }
            };

            for (var i = 0; i < colors.Count(); i++)
            {
                var tb = new PivotHeaderControl
                {
                    FontFamily = new FontFamily("Segoe UI"),
                    FontWeight = FontWeights.Light,
                    ActiveForeground = Brushes.White,
                    InactiveForeground = new SolidColorBrush(Color.FromRgb(48, 48, 48)),
                    DisabledForeground = Brushes.Red,
                    FontSize = 42,
                    Content = colors[i],
                    Margin = new Thickness(20, 0, 0, 0),
                    IsEnabled = !((i > 0) && ((i % 2) == 0))
                };

                var pci = new PivotContentControl();
                var lb = new ListBox
                {
                    FontFamily = new FontFamily("Segoe UI"),
                    FontSize = 24,
                    FontWeight = FontWeights.Light,
                    Foreground = brushes[i],
                    Background = new SolidColorBrush(Color.FromRgb(16, 16, 16)),
                    BorderThickness = new Thickness(0),
                    ItemTemplate = (DataTemplate)this.Resources["ListBoxItemTemplate"],
                    ItemsSource = data[i],
                };
                ScrollViewer.SetHorizontalScrollBarVisibility(lb, ScrollBarVisibility.Disabled);
                lb.HorizontalAlignment = HorizontalAlignment.Stretch;
                lb.VerticalAlignment = VerticalAlignment.Stretch;
                lb.Margin = new Thickness(30, 10, 10, 10);
                pci.Content = lb;

                var pi = new PivotItem { PivotHeader = tb, PivotContent = pci };
                //pi.SetActive(false);
                items.Add(pi);
            }

            RootPivotPanel.ItemsSource = items;

            RootPivotPanel.Background = new SolidColorBrush(Color.FromRgb(16, 16, 16));
        }
    }
}
