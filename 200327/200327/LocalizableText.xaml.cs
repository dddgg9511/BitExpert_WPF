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

namespace _200327
{
    /// <summary>
    /// LocalizableText.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LocalizableText : Window
    {
        public LocalizableText()
        {
            InitializeComponent();
        }

        private void chkLongText_Checked(object sender, RoutedEventArgs e)
        {
            cmdPrev.Content = " <- Go to the Previous Window ";
            cmdNext.Content = " Go to the Next Window -> ";
        }

        private void chkLongText_Unchecked(object sender, RoutedEventArgs e)
        {
            cmdPrev.Content = "Prev";
            cmdNext.Content = "Next";
        }
    }
}
