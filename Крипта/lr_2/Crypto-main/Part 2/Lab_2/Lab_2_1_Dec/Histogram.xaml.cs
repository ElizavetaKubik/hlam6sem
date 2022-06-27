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
        static string alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
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
            AChance.Content = alphabetChance[0].ToString();
            AHisto.Height = (int)(alphabetChance[0] * 550 / max);
            ĄChance.Content = alphabetChance[1].ToString();
            ĄHisto.Height = (int)(alphabetChance[1] * 550 / max);
            BChance.Content = alphabetChance[2].ToString();
            BHisto.Height = (int)(alphabetChance[2] * 550 / max);
            CChance.Content = alphabetChance[3].ToString();
            CHisto.Height = (int)(alphabetChance[3] * 550 / max);
            ĆChance.Content = alphabetChance[4].ToString();
            ĆHisto.Height = (int)(alphabetChance[4] * 550 / max);
            DChance.Content = alphabetChance[5].ToString();
            DHisto.Height = (int)(alphabetChance[5] * 550 / max);
            EChance.Content = alphabetChance[6].ToString();
            EHisto.Height = (int)(alphabetChance[6] * 550 / max);
            ĘChance.Content = alphabetChance[7].ToString();
            ĘHisto.Height = (int)(alphabetChance[7] * 550 / max);
            FChance.Content = alphabetChance[8].ToString();
            FHisto.Height = (int)(alphabetChance[8] * 550 / max);
            GChance.Content = alphabetChance[9].ToString();
            GHisto.Height = (int)(alphabetChance[9] * 550 / max);
            HChance.Content = alphabetChance[10].ToString();
            HHisto.Height = (int)(alphabetChance[10] * 550 / max);
            IChance.Content = alphabetChance[11].ToString();
            IHisto.Height = (int)(alphabetChance[11] * 550 / max);
            JChance.Content = alphabetChance[12].ToString();
            JHisto.Height = (int)(alphabetChance[12] * 550 / max);
            KChance.Content = alphabetChance[13].ToString();
            KHisto.Height = (int)(alphabetChance[13] * 550 / max);
            LChance.Content = alphabetChance[14].ToString();
            LHisto.Height = (int)(alphabetChance[14] * 550 / max);
            ŁChance.Content = alphabetChance[15].ToString();
            ŁHisto.Height = (int)(alphabetChance[15] * 550 / max);
            MChance.Content = alphabetChance[16].ToString();
            MHisto.Height = (int)(alphabetChance[16] * 550 / max);
            NChance.Content = alphabetChance[17].ToString();
            NHisto.Height = (int)(alphabetChance[17] * 550 / max);
            ŃChance.Content = alphabetChance[18].ToString();
            ŃHisto.Height = (int)(alphabetChance[18] * 550 / max);
            OChance.Content = alphabetChance[19].ToString();
            OHisto.Height = (int)(alphabetChance[19] * 550 / max);
            ÓChance.Content = alphabetChance[20].ToString();
            ÓHisto.Height = (int)(alphabetChance[20] * 550 / max);
            PChance.Content = alphabetChance[21].ToString();
            PHisto.Height = (int)(alphabetChance[21] * 550 / max);
            QChance.Content = alphabetChance[22].ToString();
            QHisto.Height = (int)(alphabetChance[22] * 550 / max);
            RChance.Content = alphabetChance[23].ToString();
            RHisto.Height = (int)(alphabetChance[23] * 550 / max);
            SChance.Content = alphabetChance[24].ToString();
            SHisto.Height = (int)(alphabetChance[24] * 550 / max);
            ŚChance.Content = alphabetChance[25].ToString();
            ŚHisto.Height = (int)(alphabetChance[25] * 550 / max);
            TChance.Content = alphabetChance[26].ToString();
            THisto.Height = (int)(alphabetChance[26] * 550 / max);
            UChance.Content = alphabetChance[27].ToString();
            UHisto.Height = (int)(alphabetChance[27] * 550 / max);
            VChance.Content = alphabetChance[28].ToString();
            VHisto.Height = (int)(alphabetChance[28] * 550 / max);
            WChance.Content = alphabetChance[29].ToString();
            WHisto.Height = (int)(alphabetChance[29] * 550 / max);
            XChance.Content = alphabetChance[30].ToString();
            XHisto.Height = (int)(alphabetChance[30] * 550 / max);
            YChance.Content = alphabetChance[31].ToString();
            YHisto.Height = (int)(alphabetChance[31] * 550 / max);
            ZChance.Content = alphabetChance[32].ToString();
            ZHisto.Height = (int)(alphabetChance[32] * 550 / max);
            ŹChance.Content = alphabetChance[33].ToString();
            ŹHisto.Height = (int)(alphabetChance[33] * 550 / max);
            ŻChance.Content = alphabetChance[34].ToString();
            ŻHisto.Height = (int)(alphabetChance[34] * 550 / max);
        }
    }
}
