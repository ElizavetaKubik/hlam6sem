using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab_11_Oper
{
    public partial class MainWindow : Window
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^-0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public double CalcY(double a, double b, double x)
        {
            double y = Math.Sqrt(Math.Pow(x, 3) + a * x + b);
            return y;
        }

        public double[] Sum(double x1, double y1, double x2, double y2)
        {
            double[] result = new double[2];
            if (x1 == 0 && y1 == 0)
            {
                result[0] = x2;
                result[1] = y2;
            }
            else if (x2 == 0 && y2 == 0)
            {
                result[0] = x1;
                result[1] = y1;
            }
            else
            {
                double l = (y2 - y1) / (x2 - x1);
                double rx = Math.Pow(l, 2) - x2 - x1;
                double ry = l * (x1 - rx) - y1;
                result[0] = rx;
                result[1] = ry;
            }
            return result;
        }

        public double[] Dublicate(double x, double y, double a)
        {
            double l = (3 * Math.Pow(x, 2) + a) / (2 * y);
            double rx = Math.Pow(l, 2) - 2 * x;
            double ry = l * (x - rx) - y;
            double[] result = new double[2];
            result[0] = rx;
            result[1] = ry;
            return result;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        //=================================================================================================

        private void ChangedK1(object sender, TextChangedEventArgs e)
        {
            if (A1.Text != String.Empty && B1.Text != String.Empty && K1.Text != String.Empty && Px1.Text != String.Empty)
            {
                double a = Convert.ToDouble(A1.Text);
                double b = Convert.ToDouble(B1.Text);
                double k = Convert.ToDouble(K1.Text);
                double x = Convert.ToDouble(Px1.Text);
                Py1.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateQ1();
            }
        }

        private void ChangedPx1(object sender, TextChangedEventArgs e)
        {
            if (A1.Text != String.Empty && B1.Text != String.Empty && K1.Text != String.Empty && Px1.Text != String.Empty)
            {
                double a = Convert.ToDouble(A1.Text);
                double b = Convert.ToDouble(B1.Text);
                double k = Convert.ToDouble(K1.Text);
                double x = Convert.ToDouble(Px1.Text);
                Py1.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateQ1();
            }
        }

        private void CalculateQ1()
        {
            double a = Convert.ToDouble(A1.Text);
            double b = Convert.ToDouble(B1.Text);
            double x = Convert.ToDouble(Px1.Text);
            double y = Convert.ToDouble(Py1.Text);
            double[] result = new double[2];
            result[0] = 0;
            result[1] = 0;
            double[] temp = new double[2];
            temp[0] = x;
            temp[1] = y;
            string k = Convert.ToString(Convert.ToInt32(K1.Text), 2).PadLeft(Convert.ToInt32(K1.Text), '0');
            for (int i = k.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < k.Length - i - 1; j++)
                {
                    temp = Dublicate(temp[0], temp[1], a);
                }
                if (k[i] == '1')
                {
                    result = Sum(result[0], result[1], temp[0], temp[1]);
                }
                temp[0] = x;
                temp[1] = y;
            }
            Qx1.Text = result[0].ToString().PadLeft(9, ' ').Substring(0, 9);
            Qy1.Text = result[1].ToString().PadLeft(9, ' ').Substring(0, 9);
        }

        //=================================================================================================

        private void ChangedPx2(object sender, TextChangedEventArgs e)
        {
            if (A2.Text != String.Empty && B2.Text != String.Empty && Px2.Text != String.Empty && Qx2.Text != String.Empty)
            {
                double a = Convert.ToDouble(A2.Text);
                double b = Convert.ToDouble(B2.Text);
                double x = Convert.ToDouble(Px2.Text);
                Py2.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR2();
            }
            else if (A2.Text != String.Empty && B2.Text != String.Empty && Px2.Text != String.Empty)
            {
                double a = Convert.ToDouble(A2.Text);
                double b = Convert.ToDouble(B2.Text);
                double x = Convert.ToDouble(Px2.Text);
                Py2.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void ChangedQx2(object sender, TextChangedEventArgs e)
        {
            if (A2.Text != String.Empty && B2.Text != String.Empty && Px2.Text != String.Empty && Qx2.Text != String.Empty)
            {
                double a = Convert.ToDouble(A2.Text);
                double b = Convert.ToDouble(B2.Text);
                double x = Convert.ToDouble(Qx2.Text);
                Qy2.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR2();
            }
            else if (A2.Text != String.Empty && B2.Text != String.Empty && Qx2.Text != String.Empty)
            {
                double a = Convert.ToDouble(A2.Text);
                double b = Convert.ToDouble(B2.Text);
                double x = Convert.ToDouble(Qx2.Text);
                Qy2.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void CalculateR2()
        {
            double a = Convert.ToDouble(A2.Text);
            double px = Convert.ToDouble(Px2.Text);
            double py = Convert.ToDouble(Py2.Text);
            double qx = Convert.ToDouble(Qx2.Text);
            double qy = Convert.ToDouble(Qy2.Text);
            double[] result = new double[2];
            if (px == qx)
            {
                result = Dublicate(px, py, a);
            }
            else
            {
                result = Sum(px, py, qx, qy);
            }
            Rx2.Text = result[0].ToString().PadLeft(9, ' ').Substring(0, 9);
            Ry2.Text = result[1].ToString().PadLeft(9, ' ').Substring(0, 9);
        }

        //=================================================================================================

        private void ChangedK3(object sender, TextChangedEventArgs e)
        {
            if (A3.Text != String.Empty && B3.Text != String.Empty && K3.Text != String.Empty && Px3.Text != String.Empty && L3.Text != String.Empty && Qx3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double k = Convert.ToDouble(K3.Text);
                double x = Convert.ToDouble(Px3.Text);
                Py3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR3();
            }
            else if (A3.Text != String.Empty && B3.Text != String.Empty && K3.Text != String.Empty && Px3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double k = Convert.ToDouble(K3.Text);
                double x = Convert.ToDouble(Px3.Text);
                Py3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void ChangedPx3(object sender, TextChangedEventArgs e)
        {
            if (A3.Text != String.Empty && B3.Text != String.Empty && K3.Text != String.Empty && Px3.Text != String.Empty && L3.Text != String.Empty && Qx3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double k = Convert.ToDouble(K3.Text);
                double x = Convert.ToDouble(Px3.Text);
                Py3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR3();
            }
            else if (A3.Text != String.Empty && B3.Text != String.Empty && K3.Text != String.Empty && Px3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double k = Convert.ToDouble(K3.Text);
                double x = Convert.ToDouble(Px3.Text);
                Py3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void ChangedL3(object sender, TextChangedEventArgs e)
        {
            if (A3.Text != String.Empty && B3.Text != String.Empty && K3.Text != String.Empty && Px3.Text != String.Empty && L3.Text != String.Empty && Qx3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double l = Convert.ToDouble(L3.Text);
                double x = Convert.ToDouble(Qx3.Text);
                Qy3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR3();
            }
            else if (A3.Text != String.Empty && B3.Text != String.Empty && L3.Text != String.Empty && Qx3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double l = Convert.ToDouble(L3.Text);
                double x = Convert.ToDouble(Qx3.Text);
                Qy3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void ChangedQx3(object sender, TextChangedEventArgs e)
        {
            if (A3.Text != String.Empty && B3.Text != String.Empty && K3.Text != String.Empty && Px3.Text != String.Empty && L3.Text != String.Empty && Qx3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double l = Convert.ToDouble(L3.Text);
                double x = Convert.ToDouble(Qx3.Text);
                Qy3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR3();
            }
            else if (A3.Text != String.Empty && B3.Text != String.Empty && L3.Text != String.Empty && Qx3.Text != String.Empty)
            {
                double a = Convert.ToDouble(A3.Text);
                double b = Convert.ToDouble(B3.Text);
                double l = Convert.ToDouble(L3.Text);
                double x = Convert.ToDouble(Qx3.Text);
                Qy3.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void CalculateR3()
        {
            double a = Convert.ToDouble(A3.Text);
            double b = Convert.ToDouble(B3.Text);
            double px = Convert.ToDouble(Px3.Text);
            double py = Convert.ToDouble(Py3.Text);
            double qx = Convert.ToDouble(Qx3.Text);
            double qy = Convert.ToDouble(Qy3.Text);
            double[] pResult = new double[2];
            pResult[0] = 0;
            pResult[1] = 0;
            double[] pTemp = new double[2];
            pTemp[0] = px;
            pTemp[1] = py;
            string k = Convert.ToString((Convert.ToInt32(K3.Text) - 1), 2).PadLeft((Convert.ToInt32(K3.Text) - 1), '0');
            for (int i = k.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < k.Length - i - 1; j++)
                {
                    pTemp = Dublicate(pTemp[0], pTemp[1], a);
                }
                if (k[i] == '1')
                {
                    pResult = Sum(pResult[0], pResult[1], pTemp[0], pTemp[1]);
                }
                pTemp[0] = px;
                pTemp[1] = py;
            }

            double[] qResult = new double[2];
            qResult[0] = 0;
            qResult[1] = 0;
            double[] qTemp = new double[2];
            qTemp[0] = qx;
            qTemp[1] = qy;
            string l = Convert.ToString((Convert.ToInt32(L3.Text) - 1), 2).PadLeft((Convert.ToInt32(L3.Text) - 1), '0');
            for (int i = l.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < l.Length - i - 1; j++)
                {
                    qTemp = Dublicate(qTemp[0], qTemp[1], a);
                }
                if (l[i] == '1')
                {
                    qResult = Sum(qResult[0], qResult[1], qTemp[0], qTemp[1]);
                }
                qTemp[0] = qx;
                qTemp[1] = qy;
            }


            double[] result = new double[2];
            result = Sum(pResult[0], pResult[1], qResult[0], qResult[1]);
            Rx3.Text = result[0].ToString().PadLeft(9, ' ').Substring(0, 9);
            Ry3.Text = result[1].ToString().PadLeft(9, ' ').Substring(0, 9);
        }

        //=================================================================================================

        private void ChangedPx4(object sender, TextChangedEventArgs e)
        {
            if (A4.Text != String.Empty && B4.Text != String.Empty && Px4.Text != String.Empty && Qx4.Text != String.Empty)
            {
                double a = Convert.ToDouble(A4.Text);
                double b = Convert.ToDouble(B4.Text);
                double x = Convert.ToDouble(Px4.Text);
                Py4.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR4();
            }
            else if (A4.Text != String.Empty && B4.Text != String.Empty && Px4.Text != String.Empty)
            {
                double a = Convert.ToDouble(A4.Text);
                double b = Convert.ToDouble(B4.Text);
                double x = Convert.ToDouble(Px4.Text);
                Py4.Text = CalcY(a, b, x).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void ChangedQx4(object sender, TextChangedEventArgs e)
        {
            if (A4.Text != String.Empty && B4.Text != String.Empty && Px4.Text != String.Empty && Qx4.Text != String.Empty)
            {
                double a = Convert.ToDouble(A4.Text);
                double b = Convert.ToDouble(B4.Text);
                double x = Convert.ToDouble(Qx4.Text);
                Qy4.Text = (-CalcY(a, b, x)).ToString().PadLeft(9, ' ').Substring(0, 9);
                CalculateR4();
            }
            else if (A4.Text != String.Empty && B4.Text != String.Empty && Qx4.Text != String.Empty)
            {
                double a = Convert.ToDouble(A4.Text);
                double b = Convert.ToDouble(B4.Text);
                double x = Convert.ToDouble(Qx4.Text);
                Qy4.Text = (-CalcY(a, b, x)).ToString().PadLeft(9, ' ').Substring(0, 9);
            }
        }

        private void CalculateR4()
        {
            double a = Convert.ToDouble(A4.Text);
            double px = Convert.ToDouble(Px4.Text);
            double py = Convert.ToDouble(Py4.Text);
            double qx = Convert.ToDouble(Qx4.Text);
            double qy = Convert.ToDouble(Qy4.Text);
            double[] result = new double[2];
            if (px == qx)
            {
                result = Dublicate(px, py, a);
            }
            else
            {
                result = Sum(px, py, qx, qy);
            }
            Rx4.Text = result[0].ToString().PadLeft(9, ' ').Substring(0, 9);
            Ry4.Text = result[1].ToString().PadLeft(9, ' ').Substring(0, 9);
        }
    }
}
