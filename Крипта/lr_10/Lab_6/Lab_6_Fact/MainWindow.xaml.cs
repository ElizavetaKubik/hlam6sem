using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Lab_6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            int p = 811;
            int q = 821;
            int n = p * q;

            DateTime start = DateTime.Now;
            int y = (int)Math.Pow(97, 2) % n;
            DateTime finish = DateTime.Now;
            TextX.Text = y.ToString();

            TimeSpan time = finish - start;
            TextTime.Text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString() + "." + time.Milliseconds.ToString();
        }
    }
}
