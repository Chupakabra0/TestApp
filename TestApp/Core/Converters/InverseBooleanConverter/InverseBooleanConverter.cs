using System;
using System.Globalization;
using System.Windows.Data;

namespace TestApp.Core.Converters.InverseBooleanConverter {
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            targetType != typeof(bool) ? throw new InvalidOperationException("The target must be a boolean") : !(bool)value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            this.Convert(value, targetType, parameter, culture);
    }
}
