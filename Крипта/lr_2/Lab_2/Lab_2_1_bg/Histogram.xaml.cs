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
    public partial class Histogram : Window
    {
        static string alphabet = "абвгдежзийклмнопрстуфхцчшщъьюя";
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
            C1.Content = alphabetChance[0].ToString();
            L1.Height = (int)(alphabetChance[0] * 550 / max);
            C2.Content = alphabetChance[1].ToString();
            L2.Height = (int)(alphabetChance[1] * 550 / max);
            C3.Content = alphabetChance[2].ToString();
            L3.Height = (int)(alphabetChance[2] * 550 / max);
            C4.Content = alphabetChance[3].ToString();
            L4.Height = (int)(alphabetChance[3] * 550 / max);
            C5.Content = alphabetChance[4].ToString();
            L5.Height = (int)(alphabetChance[4] * 550 / max);
            C6.Content = alphabetChance[5].ToString();
            L6.Height = (int)(alphabetChance[5] * 550 / max);
            C7.Content = alphabetChance[6].ToString();
            L7.Height = (int)(alphabetChance[6] * 550 / max);
            C8.Content = alphabetChance[7].ToString();
            L8.Height = (int)(alphabetChance[7] * 550 / max);
            C9.Content = alphabetChance[8].ToString();
            L9.Height = (int)(alphabetChance[8] * 550 / max);
            C10.Content = alphabetChance[9].ToString();
            L10.Height = (int)(alphabetChance[9] * 550 / max);
            C11.Content = alphabetChance[10].ToString();
            L11.Height = (int)(alphabetChance[10] * 550 / max);
            C12.Content = alphabetChance[11].ToString();
            L12.Height = (int)(alphabetChance[11] * 550 / max);
            C13.Content = alphabetChance[12].ToString();
            L13.Height = (int)(alphabetChance[12] * 550 / max);
            C14.Content = alphabetChance[13].ToString();
            L14.Height = (int)(alphabetChance[13] * 550 / max);
            C15.Content = alphabetChance[14].ToString();
            L15.Height = (int)(alphabetChance[14] * 550 / max);
            C16.Content = alphabetChance[15].ToString();
            L16.Height = (int)(alphabetChance[15] * 550 / max);
            C17.Content = alphabetChance[16].ToString();
            L17.Height = (int)(alphabetChance[16] * 550 / max);
            C18.Content = alphabetChance[17].ToString();
            L18.Height = (int)(alphabetChance[17] * 550 / max);
            C19.Content = alphabetChance[18].ToString();
            L19.Height = (int)(alphabetChance[18] * 550 / max);
            C20.Content = alphabetChance[19].ToString();
            L20.Height = (int)(alphabetChance[19] * 550 / max);
            C21.Content = alphabetChance[20].ToString();
            L21.Height = (int)(alphabetChance[20] * 550 / max);
            C22.Content = alphabetChance[21].ToString();
            L22.Height = (int)(alphabetChance[21] * 550 / max);
            C23.Content = alphabetChance[22].ToString();
            L23.Height = (int)(alphabetChance[22] * 550 / max);
            C24.Content = alphabetChance[23].ToString();
            L24.Height = (int)(alphabetChance[23] * 550 / max);
            C25.Content = alphabetChance[24].ToString();
            L25.Height = (int)(alphabetChance[24] * 550 / max);
            C26.Content = alphabetChance[25].ToString();
            L26.Height = (int)(alphabetChance[25] * 550 / max);
            C27.Content = alphabetChance[25].ToString();
            L27.Height = (int)(alphabetChance[25] * 550 / max); 
            C28.Content = alphabetChance[25].ToString();
            L28.Height = (int)(alphabetChance[25] * 550 / max);
            C29.Content = alphabetChance[25].ToString();
            L29.Height = (int)(alphabetChance[25] * 550 / max);
            C30.Content = alphabetChance[25].ToString();
            L30.Height = (int)(alphabetChance[25] * 550 / max);
        }
    }
}
