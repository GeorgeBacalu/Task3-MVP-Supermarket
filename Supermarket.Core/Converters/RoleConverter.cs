using System;
using System.Globalization;
using System.Windows.Data;

namespace Supermarket.Core.Converters
{
    public class RoleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            string role = (string)parameter;
            int roleId = (int)value;
            return role == "Admin" && roleId == 1 || role == "Cashier" && roleId == 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) return null;
            string role = (string)parameter;
            return role == "Admin" ? 1 : 2;
        }
    }
}