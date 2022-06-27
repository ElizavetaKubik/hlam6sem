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

        private void Button1Seek(object sender, RoutedEventArgs e)
        {
            Combo1MN.Items.Clear();
            Text1Count.Clear();
            Text1Log.Clear();
            if (Text1N.Text != String.Empty)
            {
                int count = 0;
                int n = Int32.Parse(Text1N.Text);
                for (int i = 2; i <= n; i++)
                {
                    if (IsSimple(i))
                    {
                        Combo1MN.Items.Add(i.ToString());
                        count++;
                    }
                }
                Text1Count.Text = count.ToString();
                Text1Log.Text = (n / (Math.Log(n))).ToString();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void Button2Seek(object sender, RoutedEventArgs e)
        {
            Combo2MN.Items.Clear();
            Text2Count.Clear();
            Text2Log.Clear();
            if ((Text2M.Text != String.Empty) && (Text2N.Text != String.Empty))
            {
                int count = 0;
                int m = Int32.Parse(Text2M.Text);
                int n = Int32.Parse(Text2N.Text);
                for (int i = m; i <= n; i++)
                {
                    if (IsSimple(i))
                    {
                        Combo2MN.Items.Add(i.ToString());
                        count++;
                    }
                }
                Text2Count.Text = count.ToString();
                Text2Log.Text = ((n-m) / (Math.Log(n-m))).ToString();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void Button3Seek(object sender, RoutedEventArgs e)
        {
            Combo3M.Items.Clear();
            Combo3N.Items.Clear();
            if ((Text3M.Text != String.Empty) && (Text3N.Text != String.Empty))
            {
                int m = Int32.Parse(Text3M.Text);
                int n = Int32.Parse(Text3N.Text);

                for (int i = 2; i <= (int)(m / 2);)
                {
                    if (m % i == 0)
                    {
                        m = m / i;
                        Combo3M.Items.Add(i.ToString());
                    }
                    else
                    {
                        i++;
                    }
                }
                Combo3M.Items.Add(m.ToString());

                for (int i = 2; i <= (int)(n / 2);)
                {
                    if (n % i == 0)
                    {
                        n = n / i;
                        Combo3N.Items.Add(i.ToString());
                    }
                    else
                    {
                        i++;
                    }
                }
                Combo3N.Items.Add(n.ToString());
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void Button4Seek(object sender, RoutedEventArgs e)
        {
            Text4MN.Clear();
            if ((Text4M.Text != String.Empty) && (Text4N.Text != String.Empty))
            {
                int mn = Int32.Parse(Text4M.Text + Text4N.Text);
                if (IsSimple(mn))
                {
                    Text4MN.Text = mn.ToString() + " - это простое число";
                }
                else
                {
                    Text4MN.Text = mn.ToString() + " - это не простое число";
                }
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void Button5Seek(object sender, RoutedEventArgs e)
        {
            Text5MN.Clear();
            if ((Text5M.Text != String.Empty) && (Text5N.Text != String.Empty))
            {
                int m = Int32.Parse(Text5M.Text);
                int n = Int32.Parse(Text5N.Text);

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
                Text5MN.Text = nod.ToString();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void Button6Seek(object sender, RoutedEventArgs e)
        {
            Text6MN.Clear();
            Combo6MN.Items.Clear();
            if ((Text6M.Text != String.Empty) && (Text6N.Text != String.Empty))
            {
                int a, b, q, r = 1;
                if (Int32.Parse(Text6M.Text) >= Int32.Parse(Text6N.Text))
                {
                    a = Int32.Parse(Text6M.Text);
                    b = Int32.Parse(Text6N.Text);
                }
                else
                {
                    a = Int32.Parse(Text6N.Text);
                    b = Int32.Parse(Text6M.Text);
                }
                while (r != 0)
                {
                    q = (int)(a / b);
                    r = (a % b);
                    Combo6MN.Items.Add(a.ToString() + " = " + b.ToString() + " * " + q.ToString() + " + " + r.ToString());
                    a = b;
                    b = r;
                }
                Text6MN.Text = a.ToString();
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
