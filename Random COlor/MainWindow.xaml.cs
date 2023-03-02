using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = GetRandomColor();
            MessageBox.Show($"Button {btn.Content} clicked!");
        }

        private void Button_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Button btn = (Button)sender;
            int index = ((StackPanel)btn.Parent).Children.IndexOf(btn) + 1;
            ((StackPanel)btn.Parent).Children.Remove(btn);
            this.Title = $"Button {index} deleted!";
        }

        private SolidColorBrush GetRandomColor()
        {
            var random = new Random();
            var colors = typeof(Colors).GetProperties().Where(p => p.PropertyType == typeof(Color))
                                                      .Select(p => (Color)p.GetValue(null))
                                                      .ToList();
            return new SolidColorBrush(colors[random.Next(colors.Count)]);
        }
    }
}