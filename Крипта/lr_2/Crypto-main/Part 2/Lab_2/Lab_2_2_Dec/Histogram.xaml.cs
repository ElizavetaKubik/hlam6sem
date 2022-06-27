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
using System.Windows.Shapes;

namespace Lab_2
{
    /// <summary>
    /// Interaction logic for Histogram.xaml
    /// </summary>
    public partial class Histogram : Window
    {
        static string alphabet = "0123456789";
        double[] alphabetChance = new double[alphabet.Length];

        public Histogram()
        {
            InitializeComponent();
        }

        public Histogram(double[] _alphabetChance)
        {
            this.alphabetChance = _alphabetChance;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double max = alphabetChance.Max();
            Chance0.Content = alphabetChance[0].ToString();
            Histo0.Height = (int)(alphabetChance[0] * 550 / max);
            Chance1.Content = alphabetChance[1].ToString();
            Histo1.Height = (int)(alphabetChance[1] * 550 / max);
            Chance2.Content = alphabetChance[2].ToString();
            Histo2.Height = (int)(alphabetChance[2] * 550 / max);
            Chance3.Content = alphabetChance[3].ToString();
            Histo3.Height = (int)(alphabetChance[3] * 550 / max);
            Chance4.Content = alphabetChance[4].ToString();
            Histo4.Height = (int)(alphabetChance[4] * 550 / max);
            Chance5.Content = alphabetChance[5].ToString();
            Histo5.Height = (int)(alphabetChance[5] * 550 / max);
            Chance6.Content = alphabetChance[6].ToString();
            Histo6.Height = (int)(alphabetChance[6] * 550 / max);
            Chance7.Content = alphabetChance[7].ToString();
            Histo7.Height = (int)(alphabetChance[7] * 550 / max);
            Chance8.Content = alphabetChance[8].ToString();
            Histo8.Height = (int)(alphabetChance[8] * 550 / max);
            Chance9.Content = alphabetChance[9].ToString();
            Histo9.Height = (int)(alphabetChance[9] * 550 / max);
        }
    }
}
