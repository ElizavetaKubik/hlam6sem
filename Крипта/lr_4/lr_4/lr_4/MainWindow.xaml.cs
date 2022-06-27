using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace lr_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string alp = "abcdefghijklmnopqrstuvwxyz"; 

        static string alphabet = "acdefghjlmnopqrstvwxykubiz"; // с ключевым словом kubik с 24 позиции

        private void Encrypt(object sender, RoutedEventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RichTextEnc1.Document.Blocks.Clear();
            if (RichText.GetText(RichTextOrig1) != String.Empty)
            {
                //Histogram
                int[] alphabetCount1 = new int[alphabet.Length];
                int[] alphabetCount2 = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance1 = new double[alphabet.Length];
                double[] alphabetChance2 = new double[alphabet.Length];

                string text = RichText.GetText(RichTextOrig1).ToLower();
                text = text.Substring(0, text.Length - 2);
                string encText = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (alphabet.Contains(text[i]))
                    {
                        int temp = -1;

                        for (int j = 0; i < 26; j++)
                        {
                            if (alp[j] == text[i])
                            {
                                temp = j;
                                break;
                            }
                        }

                        if (temp < 26)
                        {
                            encText += alphabet[temp];
                        }
                        else
                        {
                            encText += alphabet[temp%25];
                        }
                    }
                    else
                    {
                        encText += text[i];
                    }
                }
                RichText.SetText(RichTextEnc1, encText);
                stopwatch.Stop();
                lable1.Content = "Потрачено тактов на выполнение: " + stopwatch.ElapsedTicks;

                //Histogram
                string replStr = " ,.!?:-;()[]'\"";
                for (int i = 0; i < replStr.Length; i++)
                {
                    text = text.Replace(replStr[i].ToString(), "");
                    encText = encText.Replace(replStr[i].ToString(), "");
                }

                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (text[i] == alp[j])
                        {
                            alphabetCount1[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < encText.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (encText[i] == alp[j])
                        {
                            alphabetCount2[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < alphabetChance1.Length; i++)
                {
                    alphabetChance1[i] = (double)alphabetCount1[i] / number;
                }
                for (int i = 0; i < alphabetChance2.Length; i++)
                {
                    alphabetChance2[i] = (double)alphabetCount2[i] / number;
                }

                Histogram histo1 = new Histogram(alphabetChance1);
                histo1.Show();
                Histogram histo2 = new Histogram(alphabetChance2);
                histo2.Show();

            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RichTextEnc2.Document.Blocks.Clear();
            if (RichText.GetText(RichTextOrig2) != String.Empty)
            {
                //Histogram
                int[] alphabetCount1 = new int[alphabet.Length];
                int[] alphabetCount2 = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance1 = new double[alphabet.Length];
                double[] alphabetChance2 = new double[alphabet.Length];

                string text = RichText.GetText(RichTextOrig2).ToLower();
                text = text.Substring(0, text.Length - 2);
                string decText = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (alphabet.Contains(text[i]))
                    {
                        int temp = -1;

                        for (int j = 0; i < 26; j++)
                        {
                            if (alphabet[j] == text[i])
                            {
                                temp = j;
                                break;
                            }
                        }

                        if (temp < 26)
                        {
                            decText += alp[temp];
                        }
                        else
                        {
                            decText += alp[temp % 25];
                        }
                    }
                    else
                    {
                        decText += text[i];
                    }
                }
                RichText.SetText(RichTextEnc2, decText);
                stopwatch.Stop();
                lable1.Content = "Потрачено тактов на выполнение: " + stopwatch.ElapsedTicks;

                //Histogram
                string replStr = " ,.!?:-;()[]'\"";
                for (int i = 0; i < replStr.Length; i++)
                {
                    text = text.Replace(replStr[i].ToString(), "");
                    decText = decText.Replace(replStr[i].ToString(), "");
                }

                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (text[i] == alp[j])
                        {
                            alphabetCount1[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < decText.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (decText[i] == alp[j])
                        {
                            alphabetCount2[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < alphabetChance1.Length; i++)
                {
                    alphabetChance1[i] = (double)alphabetCount1[i] / number;
                }
                for (int i = 0; i < alphabetChance2.Length; i++)
                {
                    alphabetChance2[i] = (double)alphabetCount2[i] / number;
                }

                Histogram histo1 = new Histogram(alphabetChance1);
                histo1.Show();
                Histogram histo2 = new Histogram(alphabetChance2);
                histo2.Show();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void EncryptT(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RichTextEnc3.Document.Blocks.Clear();
            if (RichText.GetText(RichTextOrig3) != String.Empty)
            {
                //Histogram
                int[] alphabetCount1 = new int[alphabet.Length];
                int[] alphabetCount2 = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance1 = new double[alphabet.Length];
                double[] alphabetChance2 = new double[alphabet.Length];

                char[,] alph = new char[,] { { 'l', 'i', 'z', 'a', 'b', 'c' },
                                             { 'd', 'e', 'f', 'g', 'h', 'j' },
                                             { 'k', 'm', 'n', 'o', 'p', 'q' },
                                             { 'r', 's', 't', 'u', 'v', 'w' },
                                             { 'x', 'y', '*', '*', '*', '*' }};

                string text = RichText.GetText(RichTextOrig3).ToLower();
                text = text.Substring(0, text.Length - 2);
                string encText = "";
                for(int k = 0; k < text.Length; k++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (text[k] == alph[i, j])
                            {
                                if (i == 4)
                                {
                                    encText += alph[0, j];
                                }
                                else
                                {
                                    encText += alph[i + 1, j];
                                }
                            }
                            if(text[k]==' ')
                            {
                                encText += ' ';
                                k++;
                            }
                        }
                    }
                }

                RichText.SetText(RichTextEnc3, encText);
                stopwatch.Stop();
                lable1.Content = "Потрачено тактов на выполнение: " + stopwatch.ElapsedTicks;

                //Histogram
                string replStr = " ,.!?:-;()[]'\"";
                for (int i = 0; i < replStr.Length; i++)
                {
                    text = text.Replace(replStr[i].ToString(), "");
                    encText = encText.Replace(replStr[i].ToString(), "");
                }

                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (text[i] == alp[j])
                        {
                            alphabetCount1[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < encText.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (encText[i] == alp[j])
                        {
                            alphabetCount2[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < alphabetChance1.Length; i++)
                {
                    alphabetChance1[i] = (double)alphabetCount1[i] / number;
                }
                for (int i = 0; i < alphabetChance2.Length; i++)
                {
                    alphabetChance2[i] = (double)alphabetCount2[i] / number;
                }

                Histogram histo1 = new Histogram(alphabetChance1);
                histo1.Show();
                Histogram histo2 = new Histogram(alphabetChance2);
                histo2.Show();
            }
            else
            {
                MessageBox.Show("Поле пустое. Заполните его");
            }
        }

        private void DecryptT(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RichTextEnc4.Document.Blocks.Clear();
            if (RichText.GetText(RichTextOrig4) != String.Empty)
            {
                //Histogram
                int[] alphabetCount1 = new int[alphabet.Length];
                int[] alphabetCount2 = new int[alphabet.Length];
                int number = 0;
                double[] alphabetChance1 = new double[alphabet.Length];
                double[] alphabetChance2 = new double[alphabet.Length];

                char[,] alph = new char[,] { { 'l', 'i', 'z', 'a', 'b', 'c' },
                                             { 'd', 'e', 'f', 'g', 'h', 'j' },
                                             { 'k', 'm', 'n', 'o', 'p', 'q' },
                                             { 'r', 's', 't', 'u', 'v', 'w' },
                                             { 'x', 'y', '*', '*', '*', '*' }};

                string text = RichText.GetText(RichTextOrig4).ToLower();
                text = text.Substring(0, text.Length - 2);
                string decText = "";
                for (int k = 0; k < text.Length; k++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (text[k] == alph[i, j])
                            {
                                if (i == 0)
                                {
                                    if(j==0 || j == 1)
                                    {
                                        decText += alph[4, j];
                                    }
                                    else
                                    {
                                        decText += alph[3, j];
                                    }
                                }
                                else
                                {
                                    decText += alph[i - 1, j];
                                }

                            }
                            if (text[k] == ' ')
                            {
                                decText += ' ';
                                k++;
                            }
                        }
                    }
                }

                RichText.SetText(RichTextEnc4, decText);
                stopwatch.Stop();
                lable1.Content = "Потрачено тактов на выполнение: " + stopwatch.ElapsedTicks;

                //Histogram
                string replStr = " ,.!?:-;()[]'\"";
                for (int i = 0; i < replStr.Length; i++)
                {
                    text = text.Replace(replStr[i].ToString(), "");
                    decText = decText.Replace(replStr[i].ToString(), "");
                }

                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (text[i] == alp[j])
                        {
                            alphabetCount1[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < decText.Length; i++)
                {
                    for (int j = 0; j < alp.Length; j++)
                    {
                        if (decText[i] == alp[j])
                        {
                            alphabetCount2[j]++;
                            number++;
                        }
                    }
                }

                for (int i = 0; i < alphabetChance1.Length; i++)
                {
                    alphabetChance1[i] = (double)alphabetCount1[i] / number;
                }
                for (int i = 0; i < alphabetChance2.Length; i++)
                {
                    alphabetChance2[i] = (double)alphabetCount2[i] / number;
                }

                Histogram histo1 = new Histogram(alphabetChance1);
                histo1.Show();
                Histogram histo2 = new Histogram(alphabetChance2);
                histo2.Show();
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
