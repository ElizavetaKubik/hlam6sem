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
using OxyPlot;
using OxyPlot.Series;

namespace Lab_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^-0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public double CalcY(double a, double b, double p, double x)
        {
            double y = (Math.Sqrt(Math.Pow(x, 3) + a * x + b) % p);
            return y;
        }

        public void CalcR()
        {
            double px = Convert.ToDouble(Px.Text);
            double py = Convert.ToDouble(Py.Text);
            double qx = Convert.ToDouble(Qx.Text);
            double qy = Convert.ToDouble(Qy.Text);
            double l = 0;
            if (px != qx)
            {
                l = (qy - py) / (qx - px);
            }
            else
            {
                double a = Convert.ToDouble(A.Text);
                l = (3 * Math.Pow(px, 2) + a) / (2 * py);
            }
            double rx = Math.Pow(l, 2) - qx - px;
            double ry = l * (px - rx) - py;
            Rx.Text = rx.ToString().PadLeft(7, ' ').Substring(0, 7);
            Ry.Text = ry.ToString().PadLeft(7, ' ').Substring(0, 7);

            PlotViewDraw();
        }

        public double PLine(double x)
        {
            return Convert.ToDouble(Py.Text);
        }

        public double QLine(double x)
        {
            return Convert.ToDouble(Qy.Text);
        }

        public double RLine(double x)
        {
            return Convert.ToDouble(Ry.Text);
        }

        public double ECLine(double x)
        {
            double a = Convert.ToDouble(A.Text);
            double b = Convert.ToDouble(B.Text);
            double p = Convert.ToDouble(P.Text);
            double y = (Math.Sqrt(Math.Pow(x, 3) + a * x + b)) % p;
            return y;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangedP(object sender, TextChangedEventArgs e)
        {
            if (A.Text != String.Empty && B.Text != String.Empty && P.Text != String.Empty && Px.Text != String.Empty && Qx.Text != String.Empty)
            {
                double a = Convert.ToDouble(A.Text);
                double b = Convert.ToDouble(B.Text);
                double p = Convert.ToDouble(P.Text);
                double x = Convert.ToDouble(Px.Text);
                Py.Text = CalcY(a, b, p, x).ToString().PadLeft(7, ' ').Substring(0, 7);
                CalcR();
            }
            else if (A.Text != String.Empty && B.Text != String.Empty && P.Text != String.Empty && Px.Text != String.Empty)
            {
                double a = Convert.ToDouble(A.Text);
                double b = Convert.ToDouble(B.Text);
                double p = Convert.ToDouble(P.Text);
                double x = Convert.ToDouble(Px.Text);
                Py.Text = CalcY(a, b, p, x).ToString().PadLeft(7, ' ').Substring(0, 7);
            }
        }

        private void ChangedQ(object sender, TextChangedEventArgs e)
        {
            if (A.Text != String.Empty && B.Text != String.Empty && P.Text != String.Empty && Px.Text != String.Empty && Qx.Text != String.Empty)
            {
                double a = Convert.ToDouble(A.Text);
                double b = Convert.ToDouble(B.Text);
                double p = Convert.ToDouble(P.Text);
                double x = Convert.ToDouble(Qx.Text);
                Qy.Text = CalcY(a, b, p, x).ToString().PadLeft(7, ' ').Substring(0, 7);
                CalcR();
            }
            else if (A.Text != String.Empty && B.Text != String.Empty && P.Text != String.Empty && Qx.Text != String.Empty)
            {
                double a = Convert.ToDouble(A.Text);
                double b = Convert.ToDouble(B.Text);
                double p = Convert.ToDouble(P.Text);
                double x = Convert.ToDouble(Qx.Text);
                Qy.Text = CalcY(a, b, p, x).ToString().PadLeft(7, ' ').Substring(0, 7);
            }
        }

        private void PlotViewDraw()
        {
            double p = Convert.ToDouble(P.Text);
            double px = Convert.ToDouble(Px.Text);
            double qx = Convert.ToDouble(Qx.Text);
            double rx = Convert.ToDouble(Rx.Text);
            var plotModel = new PlotModel();
            var verticalLinearAxis = new OxyPlot.Axes.LinearAxis();
            verticalLinearAxis.Maximum = p;
            verticalLinearAxis.MajorGridlineStyle = LineStyle.Solid;
            verticalLinearAxis.MinorGridlineStyle = LineStyle.Dot;
            plotModel.Axes.Add(verticalLinearAxis);
            var horizontalLinearAxis = new OxyPlot.Axes.LinearAxis();
            horizontalLinearAxis.Maximum = p;
            horizontalLinearAxis.MajorGridlineStyle = LineStyle.Solid;
            horizontalLinearAxis.MinorGridlineStyle = LineStyle.Dot;
            horizontalLinearAxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            plotModel.Axes.Add(horizontalLinearAxis);
            plotModel.Series.Add(new FunctionSeries(PLine, px - 0.05, px + 0.05, 0.1));
            plotModel.Series.Add(new FunctionSeries(ECLine, -p, p, 0.1));
            plotModel.Series.Add(new FunctionSeries(QLine, qx - 0.05, qx + 0.05, 0.1));
            plotModel.Series.Add(new FunctionSeries(RLine, rx - 0.05, rx + 0.05, 0.1));

            PlotView.Model = plotModel;
        }
    }
}
