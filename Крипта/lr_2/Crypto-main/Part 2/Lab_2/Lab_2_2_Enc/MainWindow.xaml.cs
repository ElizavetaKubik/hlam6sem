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

        static string alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private static int LetterNumber(char letter)
        {
            int number = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == letter)
                {
                    number = i;
                }
            }
            return number;
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            RichTextEnc.Document.Blocks.Clear();
            if (RichText.GetText(RichTextOrig) != String.Empty && TextA.Text != String.Empty)
            {
                char a = TextA.Text.ToLower()[0];
                string text = RichText.GetText(RichTextOrig).ToLower().Substring(0, RichText.GetText(RichTextOrig).Length - 2);
                string[] words = text.Split(' ');
                string encText = "";

                //Histogram
                int[] alphabetCount = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance = new double[alphabet.Length];
                //

                foreach (string word in words)
                {
                    string temp = word;
                    if (temp.Length % 2 == 1) temp += a;
                    for (int i = 0; i < temp.Length; i = i + 2)
                    {
                        encText += (LetterNumber(temp[i]) * alphabet.Length + LetterNumber(temp[i + 1])).ToString().PadLeft(4, '0');
                    }
                    encText += " ";
                }
                RichText.SetText(RichTextEnc, encText);

                //Histogram
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
                            number++;
                        }
                    }
                }

                for (int i = 0; i < alphabetChance.Length; i++)
                {
                    alphabetChance[i] = (double)alphabetCount[i] / number;
                }

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
