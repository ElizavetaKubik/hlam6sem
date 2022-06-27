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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

        private static bool IsSimple(BigInteger n)
        {
            for (BigInteger i = 2; i <= (BigInteger)(n / 2); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            //TextX.Clear();
            //TextTime.Clear();
            //if (TextY.Text != String.Empty && TextA.Text != String.Empty && TextN.Text != String.Empty)
            //{
            //    int y = Int32.Parse(TextY.Text);
            //    int a = Int32.Parse(TextA.Text);
            //    double n = Double.Parse(TextN.Text);
            //    DateTime start = DateTime.Now;
            //    int x = 0;
            //    while (Math.Pow(a, x) % n != y)
            //    {
            //        x++;
            //    }
            //    DateTime finish = DateTime.Now;
            //    TimeSpan time = finish - start;
            //    TextX.Text = x.ToString();
            //    TextTime.Text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString() + "." + time.Milliseconds.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Заполните все поля");
            //}
            BigInteger p = 712489;
            BigInteger q = 944929;
            BigInteger n = p * q;
            BigInteger a = 0;
            BigInteger b = 0;

            DateTime start = DateTime.Now;
            for (BigInteger i = 2; i <= (BigInteger)Math.Sqrt((double)n); i++)
            {
                if (IsSimple(i))
                {
                    if (n % i == 0)
                    {
                        a = i;
                        b = n / i;
                    }
                }
            }
            DateTime finish = DateTime.Now;
            TimeSpan time = finish - start;
            MessageBox.Show(a.ToString());
            MessageBox.Show(b.ToString());
            TextTime.Text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString() + "." + time.Milliseconds.ToString();
        }
    }
}
