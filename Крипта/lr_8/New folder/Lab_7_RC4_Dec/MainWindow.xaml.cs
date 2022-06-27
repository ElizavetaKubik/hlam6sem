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

namespace Lab_8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static byte[] EncryptData(byte[] pwd, byte[] data)
        {
            int a, i, j, k, tmp;
            int[] key, box;
            byte[] cipher;

            key = new int[256];
            box = new int[256];
            cipher = new byte[data.Length];

            for (i = 0; i < 256; i++)
            {
                key[i] = pwd[i % pwd.Length];
                box[i] = i;
            }
            for (j = i = 0; i < 256; i++)
            {
                j = (j + box[i] + key[i]) % 256;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }
            for (a = j = i = 0; i < data.Length; i++)
            {
                a++;
                a %= 256;
                j += box[a];
                j %= 256;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[((box[a] + box[j]) % 256)];
                cipher[i] = (byte)(data[i] ^ k);
            }
            return cipher;
        }

        public static byte[] DecryptData(byte[] pwd, byte[] data)
        {
            return EncryptData(pwd, data);
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            RichTextEnc.Document.Blocks.Clear();
            string[] text = RichText.GetText(RichTextOrig).Substring(0, RichText.GetText(RichTextOrig).Length - 2).Split(' ');
            byte[] data = new byte[text.Count()];
            for (int i = 0; i < text.Count(); i++)
            {
                data[i] = Convert.ToByte(text[i]);
            }

            string[] temp = Key.Text.Split(' ');
            byte[] key = new byte[temp.Count()];
            for (int i = 0; i < temp.Count(); i++)
            {
                key[i] = Convert.ToByte(temp[i]);
            }
            byte[] enc = EncryptData(key, data);

            string encText = "";
            for (int i = 0; i < enc.Count(); i++)
            {

                encText += ((char)enc[i]).ToString();
            }
            RichText.SetText(RichTextEnc, encText);
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
