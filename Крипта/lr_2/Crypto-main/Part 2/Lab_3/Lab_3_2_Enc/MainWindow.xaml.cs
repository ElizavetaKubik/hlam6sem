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

        static string alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            RichTextEnc.Document.Blocks.Clear();
            if (RichText.GetText(RichTextOrig) != String.Empty && TextRow.Text != String.Empty && TextColumn.Text != String.Empty)
            {
                string text = RichText.GetText(RichTextOrig).ToLower().Substring(0, RichText.GetText(RichTextOrig).Length - 2);
                int n = text.Length;
                int row = TextRow.Text.Length;
                int column = TextColumn.Text.Length;
                int[] rowKey = new int[row];
                int[] columnKey = new int[column];
                string encText = "";

                //Histogram
                int[] alphabetCount = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance = new double[alphabet.Length];
                //

                if (n <= (row * column))
                {
                    int rowKeyNumber = 0;
                    int columnKeyNumber = 0;
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        for (int j = 0; j < row; j++)
                        {
                            if (alphabet[i] == TextRow.Text[j])
                            {
                                rowKey[j] = rowKeyNumber;
                                rowKeyNumber++;
                            }
                        }
                        for (int j = 0; j < column; j++)
                        {
                            if (alphabet[i] == TextColumn.Text[j])
                            {
                                columnKey[j] = columnKeyNumber;
                                columnKeyNumber++;
                            }
                        }
                    }

                    text = text.PadRight((row * column), ' ');
                    char[,] table = new char[row, column];

                    n = row * column;

                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            table[rowKey[i], columnKey[j]] = text[(i * column) + j];
                        }
                    }

                    for (int i = 0; i < n; i++)
                    {
                        encText += table[(int)(i % row), (int)(i / row)];
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
