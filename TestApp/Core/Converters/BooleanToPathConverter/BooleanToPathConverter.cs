using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace TestApp.Core.Converters.BooleanToPathConverter {
    public class BooleanToPathConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (bool)value ?
                XamlReader.Parse("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Data=\"M 17.640625 8.976562 C 17.640625 4.019531 13.691406 0 8.820312 0 C 3.949219 0 0 4.019531 0 8.976562 C 0 13.933594 3.949219 17.953125 8.820312 17.953125 C 13.691406 17.953125 17.640625 13.933594 17.640625 8.976562 Z M 15.5625 5.480469 L 7.257812 13.929688 L 6.667969 14.535156 L 2.078125 9.863281 L 4.101562 7.800781 L 6.671875 10.414062 L 13.539062 3.421875 Z M 15.5625 5.480469  \" Stroke=\"Green\" Fill=\"Green\"></Path>")
                :
                XamlReader.Parse("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Data=\"M 17.640625 8.976562 C 17.640625 4.019531 13.691406 0 8.820312 0 C 3.949219 0 0 4.019531 0 8.976562 C 0 13.933594 3.949219 17.953125 8.820312 17.953125 C 13.691406 17.953125 17.640625 13.933594 17.640625 8.976562 Z M 10.570312 8.976562 L 14.644531 13.121094 L 12.890625 14.902344 L 8.820312 10.757812 L 4.746094 14.902344 L 2.996094 13.121094 L 7.070312 8.976562 L 2.996094 4.832031 L 4.746094 3.050781 L 8.820312 7.195312 L 12.890625 3.050781 L 14.644531 4.832031 Z M 10.570312 8.976562 \" Stroke=\"Red\" Fill=\"Red\"></Path>");

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException("Not supported operation!");
    }
}
