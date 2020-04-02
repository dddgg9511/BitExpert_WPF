using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFSparkClient
{
    class DateConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //6/17/2003 12:00:00 AM
            DateTime myDate = (DateTime)value;
            string myConvertedDate = myDate.ToShortDateString();

            return myConvertedDate;

        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            string myStringDate = (string)value;
            DateTime myDate = DateTime.Parse(myStringDate);
            return myDate;
        }
    }
}
