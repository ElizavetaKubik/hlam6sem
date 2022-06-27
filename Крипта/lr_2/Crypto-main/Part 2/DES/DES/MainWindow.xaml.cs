using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace DES
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            if (InputText.Text != "")
            {
                var str = InputText.Text;

                long startTicks1 = DateTime.Now.Ticks;
                var crypted = Des.Crypt(str);
                startTicks1 = DateTime.Now.Ticks - startTicks1;
                DESCypher.Text = crypted.ToString();

                long startTicks2 = DateTime.Now.Ticks;
                var decrypted = Des.Decrypt(crypted);
                startTicks2 = DateTime.Now.Ticks - startTicks2;
                DESDecypher.Text = decrypted.ToString();

                long startTicks3 = DateTime.Now.Ticks;
                crypted = TripleDes.Crypt(str);
                startTicks3 = DateTime.Now.Ticks - startTicks3;
                DES3Cypher.Text = crypted.ToString();

                long startTicks4 = DateTime.Now.Ticks;
                decrypted = TripleDes.Decrypt(crypted);
                startTicks4 = DateTime.Now.Ticks - startTicks4;
                DES3Decypher.Text = decrypted.ToString();

                double seconds1 = (new TimeSpan(startTicks1)).TotalSeconds;
                double seconds2 = (new TimeSpan(startTicks2)).TotalSeconds;
                double seconds3 = (new TimeSpan(startTicks3)).TotalSeconds;
                double seconds4 = (new TimeSpan(startTicks4)).TotalSeconds;

                MessageBox.Show("DES:" + "\nEncrypt: " + seconds1 +
                                "\nDecrypt: " + seconds2 +
                                "\nDES3: " +
                                "\nEncrypt: " + seconds3 + 
                                "\nDecrypt: " + seconds4, "Overview time");
            } else
            {
                MessageBox.Show("Введите сообщение для зашифровки.");
            }
        }
    }

    public class Des
    {
        public static string Crypt(string text)
        {
            var key = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            var iv = new byte[] { 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8 }; //Вектор инициализации

            var bytes = Encoding.Default.GetBytes(text);
            var data = Encrypt(bytes, key, iv);
            return Encoding.Default.GetString(data);
        }

        public static string Decrypt(string text)
        {
            var key = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            var iv = new byte[] { 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8 };

            var bytes = Encoding.Default.GetBytes(text);
            var data = Decrypt(bytes, key, iv);
            return Encoding.Default.GetString(data);
        }

        public static byte[] Encrypt(byte[] inputBytes, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CFB;
                des.Padding = PaddingMode.Zeros;

                var encryptor = des.CreateEncryptor(key, iv);//объект шифратор с заданным ключом

                var stream = new MemoryStream();
                using (var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    //записывает последовательность байт
                    //и  перемещ текущую позицию внутри потока на число байт
                }

                return stream.ToArray().Take(inputBytes.Length).ToArray();
            }
        }

        public static byte[] Decrypt(byte[] inputBytes, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CFB;//режим блочного шифра
                des.Padding = PaddingMode.Zeros;//режим заполнения

                var decryptor = des.CreateDecryptor(key, iv);
                var input = new List<byte>(inputBytes);
                if (inputBytes.Length % 8 != 0)
                {
                    input.AddRange(new byte[8 - inputBytes.Length % 8]);
                }

                using (var result = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(new MemoryStream(input.ToArray()), decryptor,
                        CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(result);
                    }

                    return result.ToArray().Take(inputBytes.Length).ToArray();
                }
            }
        }
    }

    public class TripleDes
    {
        public static string Crypt(string text)
        {
            var key1 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            var key2 = new byte[] { 0x02, 0x03, 0x15, 0x11, 0x13, 0x03, 0x04, 0x06 };
            var key3 = new byte[] { 0x22, 0x11, 0x12, 0x13, 0x14, 0x9, 0x08, 0x07 };
            var iv = new byte[] { 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8 };

            var bytes = Encoding.Default.GetBytes(text);
            var data = Des.Encrypt(bytes, key1, iv);
            data = Des.Encrypt(data, key2, iv);
            data = Des.Encrypt(data, key3, iv);
            return Encoding.Default.GetString(data);
        }

        public static string Decrypt(string text)
        {
            var key3 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            var key2 = new byte[] { 0x02, 0x03, 0x15, 0x11, 0x13, 0x03, 0x04, 0x06 };
            var key1 = new byte[] { 0x22, 0x11, 0x12, 0x13, 0x14, 0x9, 0x08, 0x07 };
            var iv = new byte[] { 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8 };

            var bytes = Encoding.Default.GetBytes(text);
            var data = Des.Decrypt(bytes, key1, iv);
            data = Des.Decrypt(data, key2, iv);
            data = Des.Decrypt(data, key3, iv);
            return Encoding.Default.GetString(data);
        }
    }
}
