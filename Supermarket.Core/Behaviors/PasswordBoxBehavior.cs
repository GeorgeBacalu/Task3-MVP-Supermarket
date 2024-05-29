using System.Windows;
using System.Windows.Controls;

namespace Supermarket.Core.Behaviors
{
    public static class PasswordBoxBehavior
    {
        public static readonly DependencyProperty BoundPasswordProperty = DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxBehavior), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static readonly DependencyProperty BindPasswordProperty = DependencyProperty.RegisterAttached("BindPassword", typeof(bool), typeof(PasswordBoxBehavior), new PropertyMetadata(false, OnBindPasswordChanged));

        private static readonly DependencyProperty UpdatingPasswordProperty = DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordBoxBehavior), new PropertyMetadata(false));

        public static string GetBoundPassword(DependencyObject dependencyObject) => (string)dependencyObject.GetValue(BoundPasswordProperty);

        public static void SetBoundPassword(DependencyObject dependencyObject, string value) => dependencyObject.SetValue(BoundPasswordProperty, value);

        public static bool GetBindPassword(DependencyObject dependencyObject) => (bool)dependencyObject.GetValue(BindPasswordProperty);

        public static void SetBindPassword(DependencyObject dependencyObject, bool value) => dependencyObject.SetValue(BindPasswordProperty, value);

        private static bool GetUpdatingPassword(DependencyObject dependencyObject) => (bool)dependencyObject.GetValue(UpdatingPasswordProperty);

        private static void SetUpdatingPassword(DependencyObject dependencyObject, bool value) => dependencyObject.SetValue(UpdatingPasswordProperty, value);

        private static void OnBoundPasswordChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = dependencyObject as PasswordBox;
            if (passwordBox == null || !GetBindPassword(dependencyObject)) return;
            passwordBox.PasswordChanged -= HandlePasswordChanged;
            string newPassword = e.NewValue as string;
            if (!GetUpdatingPassword(passwordBox)) 
                passwordBox.Password = newPassword;
            passwordBox.PasswordChanged += HandlePasswordChanged;
        }

        private static void OnBindPasswordChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = dependencyObject as PasswordBox;
            if (passwordBox == null) return;
            bool wasBound = (bool)(e.OldValue);
            bool needToBind = (bool)(e.NewValue);
            if (wasBound) passwordBox.PasswordChanged -= HandlePasswordChanged;
            if (needToBind) passwordBox.PasswordChanged += HandlePasswordChanged;
        }

        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetUpdatingPassword(passwordBox, true);
            SetBoundPassword(passwordBox, passwordBox.Password);
            SetUpdatingPassword(passwordBox, false);
        }
    }
}