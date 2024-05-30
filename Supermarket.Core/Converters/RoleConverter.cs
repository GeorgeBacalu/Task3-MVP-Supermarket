using Supermarket.Core.Entities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Supermarket.Core.Converters
{
    public class RoleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            RoleType roleType = (RoleType)value;
            return roleType == RoleType.Admin ? "Admin" : "Cashier";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            bool role = (bool)value;
            return role == true ? 1 : role == false ? 2 : throw new InvalidOperationException("Invalid role type");
        }
    }
}