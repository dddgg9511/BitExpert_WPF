using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSpark;
using Timer = System.Timers.Timer;

namespace WPFSparkClient.NET46
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SparkWindow
    {
        #region Enums

        public enum AppMode
        {
            DataAccessComponent,
            InquireEmployee,
            EmpNum_List,
            DataTemplateList,
            DataGrid,
            SprocketControl,
            ToggleSwitch,
            FluidWrapPanel,
            SparkWindow,
            FluidPivotPanel,
            FluidProgressBar,
            FluidStatusBar
        }

        enum SplitViewMenuWidth
        {
            Narrow = 48,
            Wide = 240
        }

        #endregion

        #region Fields

        Timer timer1 = new Timer(70);
        Timer timer2 = new Timer(70);

        bool isBGWorking = false;
        BackgroundWorker bgWorker;
        private Random _rnd = new Random();
        private Brush[] _brushes;

        #endregion

        #region Dependency Properties

        #region CurrentAppMode

        /// <summary>
        /// CurrentAppMode Dependency Property
        /// </summary>
        public static readonly DependencyProperty CurrentAppModeProperty =
            DependencyProperty.Register("CurrentAppMode", typeof(AppMode), typeof(MainWindow),
                new FrameworkPropertyMetadata(AppMode.SprocketControl));

        /// <summary>
        /// Gets or sets the CurrentAppMode property. This dependency property 
        /// indicates the current application mode.
        /// </summary>
        public AppMode CurrentAppMode
        {
            get { return (AppMode)GetValue(CurrentAppModeProperty); }
            set { SetValue(CurrentAppModeProperty, value); }
        }

        #endregion

        #region AppTitle

        /// <summary>
        /// AppTitle Dependency Property
        /// </summary>
        public static readonly DependencyProperty AppTitleProperty =
            DependencyProperty.Register("AppTitle", typeof(string), typeof(MainWindow),
                new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the AppTitle property. This dependency property 
        /// indicates the title to be displayed based on user selection.
        /// </summary>
        public string AppTitle
        {
            get { return (string)GetValue(AppTitleProperty); }
            set { SetValue(AppTitleProperty, value); }
        }

        #endregion

        #endregion

        public MainWindow()
        {
            InitializeComponent();


            _brushes = new Brush[] {
                                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4cd964")),
                                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007aff")),
                                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9600")),
                                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff2d55")),
                                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5856d6")),
                                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffcc00")),
                                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8e8e93")),
                                      };

            SizeChanged += (o, a) =>
            {
                switch (WindowState)
                {
                    case WindowState.Maximized:
                        SplitViewMenu.Width = (int)SplitViewMenuWidth.Wide;
                        break;

                    case WindowState.Normal:
                        SplitViewMenu.Width = (int)SplitViewMenuWidth.Narrow;
                        break;
                }

                RootGrid.ColumnDefinitions[0] = new ColumnDefinition { Width = new GridLength(SplitViewMenu.Width) };
                RootGrid.InvalidateVisual();
            };

            // Enable the tooltip for SplitView menu buttons only if the SplitView width is narrow
            SplitViewMenu.SizeChanged += (o, a) =>
            {
                var isNarrowMenu = (int)SplitViewMenu.Width == (int)SplitViewMenuWidth.Narrow;
                ToolTipService.SetIsEnabled(DataAccessComponent, isNarrowMenu);
 ;
            };

            Loaded += (s, e) =>
            {
                DataContext = this;
               
            };


            InitializeFluidProgressBars();
        }

        // -------------------------------------------------------------------------------------
        // SprocketControl
        // -------------------------------------------------------------------------------------

        #region SprocketControl


      

       
        

      

        #endregion

        // -------------------------------------------------------------------------------------
        // SparkWindow
        // -------------------------------------------------------------------------------------

        #region SparkWindow

        private void LaunchSparkWindow(object sender, RoutedEventArgs e)
        {
            SparkWindow win = new SparkWindow
            {
                Width = 800,
                Height = 600,
                Title = "Sample SparkWindow",
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                Content = new Grid
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DBE6ECF0"))
                }
            };


            win.ShowDialog();
        }

        #endregion

        // -------------------------------------------------------------------------------------
        // FluidWrapPanel
        // -------------------------------------------------------------------------------------

        #region FluidWrapPanel

        private Random _random = new Random();

        #region UseRandomChildSize

        /// <summary>
        /// UseRandomChildSize Dependency Property
        /// </summary>
        public static readonly DependencyProperty UseRandomChildSizeProperty =
            DependencyProperty.Register("UseRandomChildSize", typeof(bool), typeof(MainWindow),
                new FrameworkPropertyMetadata(false, OnRandomChildSizeChanged));

        private static void OnRandomChildSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as MainWindow;
          
        }

        /// <summary>
        /// Gets or sets the UseRandomChildSize property. This dependency property 
        /// indicates whether the children should be of different size or same size.
        /// </summary>
        public bool UseRandomChildSize
        {
            get { return (bool)GetValue(UseRandomChildSizeProperty); }
            set { SetValue(UseRandomChildSizeProperty, value); }
        }

        #endregion

      

      
        private void OnRefresh(object sender, RoutedEventArgs e)
        {
      
        }

        #endregion

        // -------------------------------------------------------------------------------------
        // FluidPivotPanel
        // -------------------------------------------------------------------------------------

        #region FluidPivotPanel

        public class TextMessage : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            #region MainText

            private string _mainText = string.Empty;

            /// <summary>
            /// Gets or sets the MainText property. This observable property 
            /// indicates the main text.
            /// </summary>
            public string MainText
            {
                get { return _mainText; }
                set
                {
                    if (_mainText == value)
                        return;

                    _mainText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MainText)));
                }
            }

            #endregion

            #region SubText

            private string subText = string.Empty;

            /// <summary>
            /// Gets or sets the SubText property. This observable property 
            /// indicates the sub text.
            /// </summary>
            public string SubText
            {
                get { return subText; }
                set
                {
                    if (subText == value)
                        return;

                    subText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubText)));
                }
            }

            #endregion
        }

        
        #endregion

        // -------------------------------------------------------------------------------------
        // FluidProgressBar
        // -------------------------------------------------------------------------------------

        #region FluidProgressBar

        private void InitializeFluidProgressBars()
        {
            
        }

        #endregion

        // -------------------------------------------------------------------------------------
        // FluidStatusBar
        // -------------------------------------------------------------------------------------

        #region FluidStatusBar

       

       
    

       

        #endregion

        // -------------------------------------------------------------------------------------
        // SplitView Menu
        // -------------------------------------------------------------------------------------

        #region SplitView Menu

        private int GetColumnZeroWidth()
        {
            // determine how wide column zero should be based on window size
            // if window is maximized, column zero width is equal to current menu width.
            // if window is normal, column zero width is equal to narrow menu width
            return WindowState == WindowState.Maximized
                       ? (int)SplitViewMenu.Width
                       : (int)SplitViewMenuWidth.Narrow;

        }

        private void OnMenuButtonClicked(object sender, RoutedEventArgs e)
        {
            // toggle menu width
            SplitViewMenu.Width = (int)SplitViewMenu.Width == (int)SplitViewMenuWidth.Narrow
                                      ? (int)SplitViewMenuWidth.Wide
                                      : (int)SplitViewMenuWidth.Narrow;

            // reset column width in the column definition based on window size
            RootGrid.ColumnDefinitions[0].Width = new GridLength(GetColumnZeroWidth());
        }

       
      

        private void OnToggleSwitch(object sender, RoutedEventArgs e)
        {
            
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.DataAccessComponent;
            AppTitle = Enum.GetName(typeof (AppMode), CurrentAppMode);
        }

   
        private void OnSparkWindow(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.SparkWindow;
            AppTitle = Enum.GetName(typeof (AppMode), CurrentAppMode);
        }

        private void OnFluidPivotPanel(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.FluidPivotPanel;
            AppTitle = Enum.GetName(typeof (AppMode), CurrentAppMode);
        }

      

       
        private void OnFluidStatusBar(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.FluidStatusBar;
            AppTitle = Enum.GetName(typeof (AppMode), CurrentAppMode);
        }

        #endregion
        Window1 Window1;
        Window2 window2;
        Window3 window3;
        private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
           Window1 = new Window1();
           Window1.Show();
        }

        private void ToggleSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            window2 = new Window2();
            window2.Show();
        }

        private void ToggleSwitch_Checked_2(object sender, RoutedEventArgs e)
        {
            window3 = new Window3();
            window3.Show();
        }

        private void ToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            Window1.Close();
        }

        private void ToggleSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            window2.Close();
        }

        private void ToggleSwitch_Unchecked_2(object sender, RoutedEventArgs e)
        {
            window3.Close();
        }

        private void InquireEmployee_Checked(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.InquireEmployee;
            AppTitle = Enum.GetName(typeof(AppMode), CurrentAppMode);
        }

        private void EmpNumList_Checked(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.EmpNum_List;
            AppTitle = Enum.GetName(typeof(AppMode), CurrentAppMode);
        }

        private void DataTemplateList_Checked(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.DataTemplateList;
            AppTitle = Enum.GetName(typeof(AppMode), CurrentAppMode);
        }

        private void DataGrid_Checked(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.Width = GetColumnZeroWidth();
            CurrentAppMode = AppMode.DataGrid;
            AppTitle = Enum.GetName(typeof(AppMode), CurrentAppMode);
        }
    }
}
