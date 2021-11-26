﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestApp.Core.Converters.BooleanToVisibilityConverter {
    public class BooleanToVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (bool)value ? Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            (Visibility)value == Visibility.Visible;
    }
}
