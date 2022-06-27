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

namespace Lab_3
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

        static string alphabet = "abcdiefghijklmnopqrstuvwxyz";

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            RichTextOrig.Document.Blocks.Clear();
            if (RichText.GetText(RichTextEnc) != String.Empty && TextRow.Text != String.Empty && TextColumn.Text != String.Empty)
            {
                string encText = RichText.GetText(RichTextEnc).ToLower().Substring(0, RichText.GetText(RichTextEnc).Length - 2);
                int n = encText.Length;
                int row = Int32.Parse(TextRow.Text);
                int column = Int32.Parse(TextColumn.Text);
                string text = "";

                //Histogram
                int[] alphabetCount = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance = new double[alphabet.Length];
                //

                if (n <= (row * column))
                {
                    encText = encText.PadRight((row * column), ' ');
                    char[,] table = new char[row, column];

                    n = row * column;
                    for (int i = 0; i < n; i++)
                    {
                        table[(int)(i / column), (int)(i % column)] = encText[i];
                    }

                    for (int i = 0; i < n; i++)
                    {
                        text += table[(int)(i % row), (int)(i / row)];
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
