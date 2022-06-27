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

namespace Lab_2
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

        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        private void Entropy(object sender, RoutedEventArgs e)
        {
            if (RichText.GetText(RichTextOrig) != String.Empty)
            {
                int[] alphabetCount = new int[alphabet.Length];
                int n = 0;
                double[] alphabetChance = new double[alphabet.Length];
                double entropy = 0.0D;

                string text = RichText.GetText(RichTextOrig).Substring(0, RichText.GetText(RichTextOrig).Length - 2).ToLower();
                string replStr = " ,.!?:-;()[]'\"";
                for (int i = 0; i < replStr.Length; i++)
                {
                    text = text.Replace(replStr[i].ToString(), "");
                }
                
                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (text[i] == alphabet[j])
                        {
                            alphabetCount[j]++;
                            n++;
                        }
                    }
                }

                for (int i = 0; i < alphabetChance.Length; i++)
                {
                    alphabetChance[i] = (double)alphabetCount[i] / n;
                }

                for (int i = 0; i < alphabetChance.Length; i++)
                {
                    if (alphabetChance[i] != 0) {
                        entropy += alphabetChance[i] * Math.Log(alphabetChance[i], 2);
                    }
                }

                TextEntropy.Text = (entropy * (-1)).ToString();
                Histogram histo = new Histogram(alphabetChance);
                histo.Show();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }
    }

    public static class RichText
    {
        public static void SetText(this RichTextBox richTextBox, string text)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
        }

        public static string GetText(this RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd).Text;
        }
    }
}
