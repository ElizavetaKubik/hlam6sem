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

namespace Lab_2_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string alphabet = "01";

        private void Entropy(object sender, RoutedEventArgs e)
        {
            if (RichText.GetText(RichTextOrig) != String.Empty && RichText.GetText(RichTextOrig) != null && RichText.GetText(RichTextOrig) != "\r\n")
            {
                int[] alphabetCount = new int[alphabet.Length];
                int n = 0;
                double[] alphabetChance = new double[alphabet.Length];
                double entropy = 0.0D;
                double errorEntropy = 0.0D;

                if (Convert.ToDouble(TextError.Text) != 0 && Convert.ToDouble(TextError.Text) != 1.0D)
                {
                    errorEntropy = Convert.ToDouble(TextError.Text) *
                        Math.Log(Convert.ToDouble(TextError.Text), 2) + 
                        (1 - Convert.ToDouble(TextError.Text)) * 
                        Math.Log((1 - Convert.ToDouble(TextError.Text)), 2);
                }

                string text = RichText.GetText(RichTextOrig).Substring(0, RichText.GetText(RichTextOrig).Length - 2).ToLower();
                string binText = "";
                string replStr = " ,.!?:-;()[]'\"";
                for (int i = 0; i < replStr.Length; i++)
                {
                    text = text.Replace(replStr[i].ToString(), "");
                }

                var letters = Encoding.ASCII.GetBytes(text);
                foreach (int letter in letters)
                {
                    binText += Convert.ToString(letter, 2).PadLeft(8, '0');
                }

                for (int i = 0; i < binText.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (binText[i] == alphabet[j])
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
                    if (alphabetChance[i] != 0)
                    {
                        entropy += alphabetChance[i] * Math.Log(alphabetChance[i], 2);
                    }
                }
                if (errorEntropy != 0)
                {
                    entropy -= errorEntropy;
                }

                TextEntropy.Text = (Math.Abs(entropy) * binText.Length).ToString();
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