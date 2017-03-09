using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfTest {
    public class NullableBooleanToBooleanConverter : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var b = value as bool?;
            return b != null ? b.GetValueOrDefault() : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}