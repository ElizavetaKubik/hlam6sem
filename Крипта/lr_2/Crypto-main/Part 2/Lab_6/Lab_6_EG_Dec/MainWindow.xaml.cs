using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace Lab_6_EG_Dec
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static bool IsSimple(int n)
        {
            for (int i = 2; i <= (int)(n / 2); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9(),]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private int NOD(int first, int second)
        {
            int a, b, q, r = 1;
            if (first >= second)
            {
                a = first;
                b = second;
            }
            else
            {
                a = second;
                b = first;
            }
            while (r != 0)
            {
                q = (int)(a / b);
                r = (a % b);
                a = b;
                b = r;
            }
            return a;
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
            if (RichText.GetText(RichTextEnc) != String.Empty && TextC.Text != String.Empty)
            {
                int p = Int32.Parse(TextP.Text);
                int c = Int32.Parse(TextC.Text);
                string encText = RichText.GetText(RichTextEnc).ToLower();
                encText = encText.Substring(0, encText.Length - 2);
                string[] letters = encText.Split(' ');
                string text = "";
                foreach (string letter in letters)
                {
                    string[] numbers = letter.Split(',');
                    int r = Int32.Parse(numbers[0].Substring(1, numbers[0].Length - 1));
                    int E = Int32.Parse(numbers[1].Substring(0, numbers[1].Length - 1));
                    text += alphabet[(int)BigInteger.ModPow(BigInteger.Pow(r, p - 1 - c) * E, 1, p)];
                }
                RichText.SetText(RichTextOrig, text);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
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