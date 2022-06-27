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

namespace Lab_1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static bool IsSimple(int n)
        {
            for (int i = 2; i <= (int)(n / 2); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void T1Calculate(object sender, RoutedEventArgs e)
        {
            T1Numbers.Items.Clear();
            T1Count.Clear();
            T1Ln.Clear();
            if (T1N.Text != String.Empty)
            {
                int count = 0;
                int n = Int32.Parse(T1N.Text);
                for (int i = 2; i <= n; i++)
                {
                    if (IsSimple(i))
                    {
                        T1Numbers.Items.Add(i.ToString());
                        count++;
                    }
                }
                T1Count.Text = count.ToString();
                T1Ln.Text = (n / (Math.Log(n))).ToString();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void T2Calculate(object sender, RoutedEventArgs e)
        {
            T2Numbers.Items.Clear();
            T2Count.Clear();
            T2Ln.Clear();
            if ((T2M.Text != String.Empty) && (T2N.Text != String.Empty))
            {
                int count = 0;
                int m = Int32.Parse(T2M.Text);
                int n = Int32.Parse(T2N.Text);
                for (int i = m; i <= n; i++)
                {
                    if (IsSimple(i))
                    {
                        T2Numbers.Items.Add(i.ToString());
                        count++;
                    }
                }
                T2Count.Text = count.ToString();
                T2Ln.Text = (n / (Math.Log(n)) - m / (Math.Log(m))).ToString();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void T3Calculate(object sender, RoutedEventArgs e)
        {
            NumbersM.Items.Clear();
            NumbersN.Items.Clear();
            if ((T3M.Text != String.Empty) && (T3N.Text != String.Empty))
            {
                int m = Int32.Parse(T3M.Text);
                int n = Int32.Parse(T3N.Text);

                for (int i = 2; i <= (int)(m / 2);)
                {
                    if (m % i == 0)
                    {
                        m = m / i;
                        NumbersM.Items.Add(i.ToString());
                    }
                    else
                    {
                        i++;
                    }
                }
                NumbersM.Items.Add(m.ToString());

                for (int i = 2; i <= (int)(n / 2);)
                {
                    if (n % i == 0)
                    {
                        n = n / i;
                        NumbersN.Items.Add(i.ToString());
                    }
                    else
                    {
                        i++;
                    }
                }
                NumbersN.Items.Add(n.ToString());
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void T4Calculate(object sender, RoutedEventArgs e)
        {
            Result4.Clear();
            if ((T4M.Text != String.Empty) && (T4N.Text != String.Empty))
            {
                int mn = Int32.Parse(T4M.Text + T4N.Text);
                if (IsSimple(mn))
                {
                    Result4.Text = mn.ToString() + " - простое число";
                }
                else
                {
                    Result4.Text = mn.ToString() + " - не простое число";
                }
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void T5Calculate(object sender, RoutedEventArgs e)
        {
            Result5.Clear();
            if ((T5M.Text != String.Empty) && (T5N.Text != String.Empty))
            {
                int m = Int32.Parse(T5M.Text);
                int n = Int32.Parse(T5N.Text);

                List<int> listM = new List<int>();
                List<int> listN = new List<int>();

                for (int i = 2; i <= (int)(m / 2);)
                {
                    if (m % i == 0)
                    {
                        m = m / i;
                        listM.Add(i);
                    }
                    else
                    {
                        i++;
                    }
                }
                listM.Add(m);

                for (int i = 2; i <= (int)(n / 2);)
                {
                    if (n % i == 0)
                    {
                        n = n / i;
                        listN.Add(i);
                    }
                    else
                    {
                        i++;
                    }
                }
                listN.Add(n);

                List<int> listMN = listM.Supersect(listN).ToList<int>();
                List<int> listNM = listN.Supersect(listM).ToList<int>();
                int nod = 1;
                List<int> listNOD = listMN.Count > listNM.Count ? listMN : listNM;
                foreach (int elem in listNOD)
                {
                    nod = nod * elem;
                }
                Result5.Text = nod.ToString();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void T6Calculate(object sender, RoutedEventArgs e)
        {
            T6MN.Clear();
            Result6.Items.Clear();
            if ((T6M.Text != String.Empty) && (T6N.Text != String.Empty))
            {
                int a, b, q, r = 1;
                if (Int32.Parse(T6M.Text) >= Int32.Parse(T6N.Text))
                {
                    a = Int32.Parse(T6M.Text);
                    b = Int32.Parse(T6N.Text);
                }
                else
                {
                    a = Int32.Parse(T6N.Text);
                    b = Int32.Parse(T6M.Text);
                }
                while (r != 0)
                {
                    q = (int)(a / b);
                    r = (a % b);
                    Result6.Items.Add(a.ToString() + " = " + b.ToString() + " * " + q.ToString() + " + " + r.ToString());
                    a = b;
                    b = r;
                }
                T6MN.Text = a.ToString();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

    }

    public static class List
    {
        public static IEnumerable<T> Supersect<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            List<T> list = target.ToList();
            foreach (T item in source)
            {
                if (list.Contains(item))
                {
                    list.Remove(item);
                    yield return item;
                }
            }
        }
    }
}
