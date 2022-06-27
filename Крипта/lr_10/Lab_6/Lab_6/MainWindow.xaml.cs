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

namespace Lab_10
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
            TextY.Clear();
            TextTime.Clear();
            if (TextA.Text != String.Empty && TextX.Text != String.Empty && TextN.Text != String.Empty)
            {
                int a = Int32.Parse(TextA.Text);
                int x = Int32.Parse(TextX.Text);
                double n = Double.Parse(TextN.Text);
                DateTime start = DateTime.Now;
                double y = (Math.Pow(a, x) % n);
                DateTime finish = DateTime.Now;
                TimeSpan time = finish - start;
                TextY.Text = y.ToString();
                TextTime.Text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString() + "." + time.Milliseconds.ToString();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
