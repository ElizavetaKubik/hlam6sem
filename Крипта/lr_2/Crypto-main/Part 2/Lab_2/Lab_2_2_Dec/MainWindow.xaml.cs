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

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            RichTextOrig.Document.Blocks.Clear();
            if (RichText.GetText(RichTextEnc) != String.Empty)
            {
                string encText = RichText.GetText(RichTextEnc).ToLower().Substring(0, RichText.GetText(RichTextEnc).Length - 2);
                string[] words = encText.Split(' ');
                string text = "";

                //Histogram
                string digitAlphabet = "0123456789";
                int[] digitAlphabetCount = new int[digitAlphabet.Length];
                int number = 0;
                double[] digitAlphabetChance = new double[digitAlphabet.Length];
                //

                foreach (string word in words)
                {
                    string temp = word;
                    for (int i = 0; i < temp.Length; i = i + 4)
                    {
                        int chain = Int32.Parse(temp.Substring(i, 4));
                        int row = chain / alphabet.Length;
                        int column = chain % alphabet.Length;
                        text += alphabet[row].ToString() + alphabet[column].ToString();
                    }
                    text += " ";
                }
                RichText.SetText(RichTextOrig, text);

                string replStr = " ,.!?:-;()[]'\"";
                for (int i = 0; i < replStr.Length; i++)
                {
                    encText = encText.Replace(replStr[i].ToString(), "");
                }

                for (int i = 0; i < encText.Length; i++)
                {
                    for (int j = 0; j < digitAlphabet.Length; j++)
                    {
                        if (encText[i] == digitAlphabet[j])
                        {
                            digitAlphabetCount[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < digitAlphabetChance.Length; i++)
                {
                    digitAlphabetChance[i] = (double)digitAlphabetCount[i] / number;
                }

                Histogram histo = new Histogram(digitAlphabetChance);
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
