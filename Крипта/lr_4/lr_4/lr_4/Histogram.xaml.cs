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

namespace lr_4
{
    public partial class Histogram : Window
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";
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
            BChance.Content = alphabetChance[1].ToString();
            BHisto.Height = (int)(alphabetChance[1] * 550 / max);
            CChance.Content = alphabetChance[2].ToString();
            CHisto.Height = (int)(alphabetChance[2] * 550 / max);
            DChance.Content = alphabetChance[3].ToString();
            DHisto.Height = (int)(alphabetChance[3] * 550 / max);
            EChance.Content = alphabetChance[4].ToString();
            EHisto.Height = (int)(alphabetChance[4] * 550 / max);
            FChance.Content = alphabetChance[5].ToString();
            FHisto.Height = (int)(alphabetChance[5] * 550 / max);
            GChance.Content = alphabetChance[6].ToString();
            GHisto.Height = (int)(alphabetChance[6] * 550 / max);
            HChance.Content = alphabetChance[7].ToString();
            HHisto.Height = (int)(alphabetChance[7] * 550 / max);
            IChance.Content = alphabetChance[8].ToString();
            IHisto.Height = (int)(alphabetChance[8] * 550 / max);
            JChance.Content = alphabetChance[9].ToString();
            JHisto.Height = (int)(alphabetChance[9] * 550 / max);
            KChance.Content = alphabetChance[10].ToString();
            KHisto.Height = (int)(alphabetChance[10] * 550 / max);
            LChance.Content = alphabetChance[11].ToString();
            LHisto.Height = (int)(alphabetChance[11] * 550 / max);
            MChance.Content = alphabetChance[12].ToString();
            MHisto.Height = (int)(alphabetChance[12] * 550 / max);
            NChance.Content = alphabetChance[13].ToString();
            NHisto.Height = (int)(alphabetChance[13] * 550 / max);
            OChance.Content = alphabetChance[14].ToString();
            OHisto.Height = (int)(alphabetChance[14] * 550 / max);
            PChance.Content = alphabetChance[15].ToString();
            PHisto.Height = (int)(alphabetChance[15] * 550 / max);
            QChance.Content = alphabetChance[16].ToString();
            QHisto.Height = (int)(alphabetChance[16] * 550 / max);
            RChance.Content = alphabetChance[17].ToString();
            RHisto.Height = (int)(alphabetChance[17] * 550 / max);
            SChance.Content = alphabetChance[18].ToString();
            SHisto.Height = (int)(alphabetChance[18] * 550 / max);
            TChance.Content = alphabetChance[19].ToString();
            THisto.Height = (int)(alphabetChance[19] * 550 / max);
            UChance.Content = alphabetChance[20].ToString();
            UHisto.Height = (int)(alphabetChance[20] * 550 / max);
            VChance.Content = alphabetChance[21].ToString();
            VHisto.Height = (int)(alphabetChance[21] * 550 / max);
            WChance.Content = alphabetChance[22].ToString();
            WHisto.Height = (int)(alphabetChance[22] * 550 / max);
            XChance.Content = alphabetChance[23].ToString();
            XHisto.Height = (int)(alphabetChance[23] * 550 / max);
            YChance.Content = alphabetChance[24].ToString();
            YHisto.Height = (int)(alphabetChance[24] * 550 / max);
            ZChance.Content = alphabetChance[25].ToString();
            ZHisto.Height = (int)(alphabetChance[25] * 550 / max);
        }
    }
}
