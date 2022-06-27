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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private static bool IsSimple(int n)
        {
            for (int i = 2; i <= (int)(n / 2); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
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
            if (RichText.GetText(RichTextEnc) != String.Empty && TextA.Text != String.Empty && TextB.Text != String.Empty)
            {
                int n = alphabet.Length;
                int a = Int32.Parse(TextA.Text);
                int b = Int32.Parse(TextB.Text);

                //Histogram
                int[] alphabetCount = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance = new double[alphabet.Length];
                //

                if (a >= 0 && a < n && b >= 0 && b < n && IsSimple(a) && IsSimple(b) && (n % a != 0))
                {
                    int a_ = 0;
                    while (((a_ * a) % n) != 1)
                    {
                        int test = (a_ * a) % n;
                        a_++;
                    }
                    string encText = RichText.GetText(RichTextEnc).ToLower();
                    encText = encText.Substring(0, encText.Length - 2);
                    string text = "";
                    for (int i = 0; i < encText.Length; i++)
                    {
                        if (alphabet.Contains(encText[i]))
                        {
                            text += alphabet[(a_ * (LetterNumber(encText[i]) + n - b)) % n];
                        }
                        else
                        {
                            text += encText[i];
                        }
                    }
                    RichText.SetText(RichTextOrig, text);

                    //Histogram
                    string replStr = " ,.!?:-;()[]'\"";
                    for (int i = 0; i < replStr.Length; i++)
                    {
                        encText = encText.Replace(replStr[i].ToString(), "");
                    }

                    for (int i = 0; i < encText.Length; i++)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (encText[i] == alphabet[j])
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
                    MessageBox.Show("Введенные коэффициенты ошибочны. Исправьте это");
                }
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
