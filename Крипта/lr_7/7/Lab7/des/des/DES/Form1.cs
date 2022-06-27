using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string f_file_stream_reader(string text_name_file) //процедура считывания из файла, входные данные - имя файла
        {
            string text_in_file2 = "";
            StreamReader streamReader = new StreamReader(text_name_file);
            while (!streamReader.EndOfStream) //считываем из файла содержимое
            {
                text_in_file2 += streamReader.ReadLine();
            }
            streamReader.Close();
            return text_in_file2;
        }
        public double f_bintodec(string bin) // из двоичного кода в десятичный переводит
        {
            double dec = 0;

            for (int i = bin.Length - 1; i >= 0; i--)
            {
                if (bin[i] == '1')
                {
                    dec += Math.Pow(2, (bin.Length - i - 1));
                }
            }

            return dec;

        }
        public string f_to4bit(string bin) //доводит символ до 4 бит
        {
            string bin4 = "";

            if (bin.Length < 4)
            {
                int lack = 4 - bin.Length;

                for (int i = 0; i < lack; i++)
                {
                    bin4 += '0';
                }
                bin4 += bin;
            }
            else
                bin4 = bin;
            return bin4;
        }
        public string f_to16bit(string bin) //доводит символ до 16 бит
        {
            string bin16 = "";

            if (bin.Length < 16)
            {
                int lack = 16 - bin.Length;

                for (int i = 0; i < lack; i++)
                {
                    bin16 += '0';
                }
                bin16 += bin;
            }
            else
                bin16 = bin;
            return bin16;
        }

        public string f_cypher(string bin16, string key16) // складываем исключающим ИЛИ(ХОR)/ксорим строки
        {
            string cypher = "";
            int len = bin16.Length;

            for (int i = 0; i < len; i++)
            {
                int k = bin16[i] - '0' + key16[i] - '0';

                if (k == 2)
                {
                    k = 0;
                }

                cypher += k;
            }
            return cypher;
        }
        public string f_key_ip(string str_key_64)// процедура перестановки ключа, превращение строки в 56 бит из 64
        {
            string str_key_56 = "";
            string u = "";
            char[] gav = new char[56];
            string[] a_u = new string[56];
            int[] P = new int[56];
            StreamReader streamReader = new StreamReader("KeyP.txt");
            while (!streamReader.EndOfStream) //считываем из файла правила начальной перестановки
            {
                u += streamReader.ReadLine();
            }
            streamReader.Close();
            a_u = u.Split(' ');
            for (int i = 0; i < 56; i++)
            {
                P[i] = Convert.ToInt32(a_u[i]);
            }
            for (int i = 0; i < 56; i++) // выполняем сжание ключа при помощи данных из текст файла
            {
                char cc = str_key_64[P[i] - 1];
                gav[i] = cc;
            }
            for (int i = 0; i < 56; i++) // записываем в строку то что получилось на предыдущем этапе
            {
                str_key_56 += gav[i].ToString();
            }

            return str_key_56; //только уже не 64 бит, а 56
        }

        public string LPad(string str_key_shift_28, int kol)// процедура сдвига влево для ключа, строку сдвигает на kol символов
        {
            char c;
            for (int i = 0; i < kol; i++)
            {
                c = str_key_shift_28[i];
                str_key_shift_28 = str_key_shift_28.Remove(i, 1);
                str_key_shift_28 += c;
            }
            return str_key_shift_28;
        }
        public string RPad(string str_key_shift_28, int kol)// процедура сдвига вправо для ключа, строку сдвигает на kol символов
        {
            char c;
            string str = "";
            for (int i = 0; i < kol; i++)
            {
                int l = str_key_shift_28.Length;
                c = str_key_shift_28[l - 1];
                str += c;
                str_key_shift_28 = str_key_shift_28.Remove(l - 1, 1);
                str_key_shift_28 = str_key_shift_28.Insert(0, str);
                str = "";
            }
            return str_key_shift_28;
        }

        public string f_key_shift(string str_key_shift_28_0, int kol_0, bool cipher)// процедура сдвига вправо для ключа, строку сдвигает на kol символов
        {
            if (cipher)
                LPad(str_key_shift_28_0, kol_0);
            else
                RPad(str_key_shift_28_0, kol_0);

            return str_key_shift_28_0;
        }

        public string f_key(string str_key_48)// процедура перестановки со жатием ключа из 56 в 48, для ксора со строкой
        {
            string res_key = "";
            string u = "";
            string[] a_u = new string[48];
            int[] key_ip = new int[48];
            char[] gav = new char[48]; //массив где хранятся символы, которые переставляют
            StreamReader streamReader = new StreamReader("KeyCompP.txt");
            while (!streamReader.EndOfStream) //считываем из файла правила начальной перестановки
            {
                u += streamReader.ReadLine();
            }
            streamReader.Close();
            a_u = u.Split(' ');
            for (int i = 0; i < 48; i++)
            {
                key_ip[i] = Convert.ToInt32(a_u[i]);
            }
            for (int i = 0; i < 48; i++) // выполняем сжание ключа при помощи данных из текст файла
            {
                char cc = str_key_48[key_ip[i] - 1];
                gav[i] = cc;
            }
            for (int i = 0; i < 48; i++) // записываем в строку то что получилось на предыдущем этапе
            {
                res_key += gav[i].ToString();
            }

            return res_key;
        }

        public string f_IP(string str_64)  //процедура начальной перестановки
        {
            string str_64_IP = "";
            string str_IP = "";
            int[] ar_IP = new int[64];
            string[] ar_IP2 = new string[64];
            char[] gav = new char[64];

            StreamReader streamReader = new StreamReader("initial_permutation.txt");

            while (!streamReader.EndOfStream) //считываем из файла правила начальной перестановки
            {
                str_IP += streamReader.ReadLine();
            }
            streamReader.Close();
            ar_IP2 = str_IP.Split(' ');
            for (int i = 0; i < 64; i++)
            {
                ar_IP[i] = Convert.ToInt32(ar_IP2[i]);
            }

            int len = str_64.Length;
            for (int i = 0; i < str_64.Length; i++) // выполняем саму начальную перестановку
            {
                char cc = str_64[i];
                gav[ar_IP[i] - 1] = cc;
            }
            for (int i = 0; i < 64; i++) // выполняем саму начальную перестановку, записываем в строку
            {
                str_64_IP += gav[i].ToString();
            }

            return str_64_IP;
        }

        public string f_ExpP(string str_32)// процедура перестановки c расширением. 32->48
        {
            string res_P = "";
            string u = "";
            string[] a_u = new string[48];
            int[] p_ip = new int[48];

            StreamReader streamReader = new StreamReader("ExpP.txt");
            while (!streamReader.EndOfStream) //считываем из файла
            {
                u += streamReader.ReadLine();
            }
            streamReader.Close();
            a_u = u.Split(' ');
            for (int i = 0; i < 48; i++)
            {
                p_ip[i] = Convert.ToInt32(a_u[i]);
                res_P += str_32[p_ip[i] - 1];
            }
            return res_P;
        }

        public string f_S_Units(string str_48)  //процедура перестановки S-блоков
        {
            string u = "";
            double line, column; //номера строки и столбца, double чтобы не было отрицательных
            int[,] ar_S = new int[4, 16];
            string[] ar_u = new string[48];
            
            string str_6 = "";  //строка для разбиения на блоки по 6 бит
            string str_32 = "";  //результирующая строка, которая будет равно 32 бита, к ней будет прибавляться результаты по 4 бита
            string str_buf_1 = "0000"; //определяет строку
            string str_buf_2 = "00"; // определеяет столбец

            StreamReader streamReader = new StreamReader("SP.txt");

            while (!streamReader.EndOfStream) //считываем из файла 
            {
                u += streamReader.ReadLine();
            }
            streamReader.Close();
            ar_u = u.Split(' ');
            int k = 0;

            for (int h = 0; h < str_48.Length; h += 6)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 16; j++)
                    {
                        ar_S[i, j] = Convert.ToInt32(ar_u[k]);
                        k++;
                    }
                str_6 = str_48.Substring(h, 6);
                str_buf_1 += str_6.Substring(0, 1) + str_6.Substring(5, 1);
                line = f_bintodec(str_buf_1);//перевели в десятиынй номер строки - чтобы обратиться к массиву S
                str_buf_2 += str_6.Substring(1, 4);
                column = f_bintodec(str_buf_2); //перевели в десятиынй номер столбца- чтобы обратиться к массиву S
                int i_line = (int)line; //т.к. надо интовские типы
                int i_column = (int)column; //т.к. надо интовские типы

                string fack = Convert.ToString(ar_S[i_line, i_column], 2);
                string fack2 = ""; fack2 = f_to4bit(fack);
                str_32 += fack2;  //запихиваем код нового символа расположенного в S таблице 
                str_buf_1 = "";
                str_buf_2 = "";
            }

            return str_32;// уже 32 получится
        }
        public string f_PP(string str_32)// процедура перестановки Р блоков. 32->32
        {
            string res_P = "";
            string u = "";
            string[] a_u = new string[32];
            int[] p_ip = new int[32];
            char[] gav = new char[32]; //массив где хранятся символы, которые переставляют
            StreamReader streamReader = new StreamReader("PP.txt");
            while (!streamReader.EndOfStream) //считываем из файла правила начальнйо перестановки
            {
                u += streamReader.ReadLine();
            }
            streamReader.Close();
            a_u = u.Split(' ');
            for (int i = 0; i < 32; i++)
            {
                p_ip[i] = Convert.ToInt32(a_u[i]);
            }
            for (int i = 0; i < str_32.Length; i++) // выполняем сжание ключа при помощи данных из текст файла
            {
                char cc = str_32[i];
                gav[p_ip[i] - 1] = cc;
            }
            for (int i = 0; i < 32; i++) // записываем в строку то что получилось на предыдущем этапе
            {
                res_P += gav[i].ToString();
            }

            return res_P;
        }

        public string f_IP_end(string str_64)  //процедура конечной перестановки
        {
            string str_64_IP = "";
            string str_IP = "";
            int[] ar_IP = new int[64];
            string[] ar_IP2 = new string[64];
            char[] gav = new char[64];

            StreamReader streamReader = new StreamReader("FinP.txt");

            while (!streamReader.EndOfStream) //считываем из файла
            {
                str_IP += streamReader.ReadLine();
            }
            streamReader.Close();
            ar_IP2 = str_IP.Split(' ');
            for (int i = 0; i < 64; i++)
            {
                ar_IP[i] = Convert.ToInt32(ar_IP2[i]);
            }

            int len = str_64.Length;
            for (int i = 0; i < str_64.Length; i++) // выполняем саму конечную перестановку
            {
                char cc = str_64[i];
                gav[ar_IP[i] - 1] = cc;
            }
            for (int i = 0; i < 64; i++) // выполняем саму конечную перестановку, записываем в строку
            {
                str_64_IP += gav[i].ToString();
            }

            return str_64_IP;
        }

        public string f_FeistelCipher(string part1, string part2, bool cipher) // процедура переставления частей меняет левую и правую местами
        {
            string buf;

            if (cipher)  //для шифрования
            {
                buf = part1;
                part1 = part2;

                part2 = f_cypher(buf, part2);
            }
            else // для дешифрования
            {
                buf = part2;
                part2 = part1;
                part1 = f_cypher(buf, part2);
            }

            return part1 + part2;
        }

        private void button1_Click(object sender, EventArgs e) //кнопка Шифрование
        {
            string text;
            string key, key_bin1 = "", key_bin = "", key_file = "", key_bin_part1 = "", key_bin_part2 = "";
            string[] a_key = new string[16];
            int[] ai_key = new int[16];
            string part1, part2, part0;
            string cyp = "";      //строка с двоичным кодом 
            string cipher = ""; //строка полученнка после начальной перестановки
            string cipher_end = ""; //строка после ксора part1 part2 key

            //Считывание и преобразование считанной введенной информации в двоичный код
            text = richTextBox1.Text;
            key = textBox1.Text;

            for (int i = 0; i < text.Length; i++)
            { // посимвольно переводим в двоичный код
                int j = text[i];
                string output = Convert.ToString(j, 2);
                output = f_to16bit(output);           //преобразуем при необходимости в 16 бит
                cyp += output;
            }

            //если исходный текс не делится на куски по 64 бита, то программа добавляет пробелы. 
            if (cyp.Length % 64 != 0)
            {
                int mod = cyp.Length % 64;
                mod = (64 - mod) / 16;
                int x = ' '; //пробел, для заполнения строки недостающими символами.
                for (int i = 0; i < mod; i++)
                {
                    string output = Convert.ToString(32, 2); //пробел 32 превращаем в двоичный код
                    output = f_to16bit(output);           //преобразуем при необходимости в 16 бит
                    cyp += output;
                }
            }
            richTextBox2.AppendText($"64 bits message\n{cyp}\n");
           // richTextBox2.Text = cyp; //выводим двоичный текст

            for (int i = 0; i < key.Length; i++)
            { // посимвольно переводим в двоичный код ключ
                int j = key[i];
                string output = Convert.ToString(j, 2);
                output = f_to16bit(output);           //преобразуем при необходимости в 16 бит
                key_bin += output;
            }
            richTextBox5.AppendText($"64 bits key\n{key_bin}\n");
            //richTextBox5.Text = key_bin;
           
            //считываем данные для сдвига ключа из файла, при помощи нашей самодельной процедуры, которой посылаем имя файла
            key_file = f_file_stream_reader("KeyNumShift.txt");
            a_key = key_file.Split(' '); // тут теперь количество сдвигов для каждого шага, шагов всего 16, и 16 подключей
            for (int i = 0; i < 1; i++) //16
            {
                ai_key[i] = Convert.ToInt32(a_key[i]);
            }
            key_bin = f_key_ip(key_bin); //ключ 64->56
            richTextBox5.AppendText($"56 bits key\n{key_bin}\n");

            //делим весь текст части по 64 бита, чтобы к каждой из частей применить DES
            int parts = cyp.Length / 64; 
                                         
            //начальная перестановка IP 
           for (int i = 0; i < cyp.Length; i += 64)
            {
                cipher += f_IP(cyp.Substring(i, 64));
            }
            richTextBox2.AppendText($"First permutation\n{cipher}\n");
           // richTextBox3.Text = cipher;


            //начинаем преобразование над полуcтроками
            for (int j = 0; j < 1; j++) //16
            {
                int count = 1;
                for (int i = 0; i < cyp.Length; i += 64)
                {
                    // if (cyp.Length == 64)
                    //{

                    part1 = cipher.Substring(i, 32);
                    if (count == 1)
                    {
                        richTextBox2.AppendText($"32 Left\n{part1}\n");
                    }
                    part2 = cipher.Substring(i + 32, 32);
                    if (count == 1)
                    { richTextBox2.AppendText($"32 Right \n{part2}\n"); }
                    part0 = part2;       //буфер
                    part2 = f_ExpP(part2);// перестановка с расширением
                    key_bin_part1 = key_bin.Substring(0, 28);                    //делим ключ пополам для сдвига-1ая часть
                    key_bin_part1 = f_key_shift(key_bin_part1, ai_key[j], true);  // сдвигаем одну половину
                    key_bin_part2 = key_bin.Substring(28, 28);                  //делим ключ пополам для сдвига -2ая часть
                    key_bin_part2 = f_key_shift(key_bin_part2, ai_key[j], true);  //сдвигаем другую
                    key_bin = key_bin_part1 + key_bin_part2;                      //соединям обе уже сдвинутые части 
                    key_bin1 = f_key(key_bin);
                    if (count == 1)
                    { richTextBox5.AppendText($"48 bits key\n{key_bin1}\n"); }
                    part2 = f_cypher(part2, key_bin1);                           // // складываем исключающим ИЛИ(ХОR)м  правую часть с ключом
                    part2 = f_S_Units(part2); //процедура перестановки S-блоков
                    part2 = f_PP(part2);// процедура перестановки Р блоков. 32->32
                    part2 = f_cypher(part2, part1);// складываем исключающим ИЛИ(ХОR)
                    if (count == 1)
                    { richTextBox2.AppendText($"32 bits after function f\n{part2}\n"); }
                    part1 = part0;
                    cipher_end += part1;
                    cipher_end += part2;
                    count++;
                }
                //else
                //{ richTextBox2.AppendText($"Insert the big message"); }
                cipher = cipher_end;
                cipher_end = "";
                count = 1;
            }
            int len = cipher.Length / 16;
            for (int i = 0; i < cyp.Length; i += 64)
            {
                //if (cyp.Length == 64)
                // {
                cipher_end += f_IP_end(cipher.Substring(i, 64));
            }
            cipher = cipher_end;
            richTextBox2.AppendText($"Last permutation\n{cipher}\n");
            cipher_end = "";

            for (int i = 0; i < len; i++) //перевод всего что у нас получилось из 2ного вида в шифрованный текст.
            {
                string bin16 = cipher.Substring(0, 16);
                cipher = cipher.Remove(0, 16);
                int b = (int)f_bintodec(bin16);
                cipher_end += (char)b;
            }
            //richTextBox3.AppendText($"Encrypt message:\n{cipher_end}\n");
            richTextBox3.Text = cipher_end;
          }

        private void button2_Click(object sender, EventArgs e) //кнопка Дешефровки
        {
            string text = "";
            string key, key_bin1 = "", key_bin = "", key_file = "", key_bin_part1 = "", key_bin_part2 = "";
            string[] a_key = new string[16];
            int[] ai_key = new int[16];
            string part1, part2, part0;
            string cyp = "";      //строка с двоичным кодом 
            string cipher = ""; //строка полученнка после начальной перестановки
            string cipher_end = ""; //строка после ксора part1 part2 key

            //Считывание и преобразование считанной введенной информации в двоичный код
            cipher_end = richTextBox3.Text;
            key = textBox1.Text;

            for (int i = 0; i < cipher_end.Length; i++)
            { // посимвольно переводим в двоичный код
                int j = cipher_end[i];
                string output = Convert.ToString(j, 2);
                output = f_to16bit(output);           //преобразуем при необходимости в 16 бит
                cyp += output;
            }

            //если исходный текс не делится на куски по 64 бита, то программа добавляет пробелы. 
            if (cyp.Length % 64 != 0)
            {
                int mod = cyp.Length % 64;
                mod = (64 - mod) / 16;
                int x = ' '; //пробел, для заполнения строки недостающими символами.
                for (int i = 0; i < mod; i++)
                {
                    string output = Convert.ToString(32, 2); //пробел 32 превращаем в двоичный код
                    output = f_to16bit(output);           //преобразуем при необходимости в 16 бит
                    cyp += output;
                }
            }
           // richTextBox2.AppendText($"64 bits message\n{cyp}\n");
            richTextBox2.Text = cyp; //выводим двоичный текст

            for (int i = 0; i < key.Length; i++)
            { // посимвольно переводим в двоичный код ключ
                int j = key[i];
                string output = Convert.ToString(j, 2);
                output = f_to16bit(output);           //преобразуем при необходимости в 16 бит
                key_bin += output;
            }
            key_bin = f_key_ip(key_bin); //ключ 64->56
            richTextBox5.AppendText($"56 bits key Deshifr\n{key_bin}\n");
           
            //считываем данные для сдвига ключа из файла, при помощи нашей самодельной процедуры, которой посылаем имя файла
            key_file = f_file_stream_reader("KeyNumShift.txt");
            a_key = key_file.Split(' '); // тут теперь количество сдвигов для каждого шага, шагов всего 16, и 16 подключей
            for (int i = 0; i < 1; i++)//16
            {
                ai_key[i] = Convert.ToInt32(a_key[i]);
            }

            //делим весь текст части по 64 бита, чтобы к каждой из частей применить DES
            int parts = cyp.Length / 64;
            
            //начальная перестановка IP 
          for (int i = 0; i < cyp.Length; i += 64)
            {
                cipher += f_IP(cyp.Substring(i, 64));
            }
        //    richTextBox3.Text = cipher;
            
            cipher_end = "";

             //начинаем преобразованеи над полустроками
            for (int j = 0; j < 1; j++) //16
            {
                int count = 1;
                for (int i = 0; i < cyp.Length; i += 64)
                {
//if (cyp.Length == 64)
                    //{
                    part1 = cipher.Substring(i, 32);
                    if (count == 1)
                    {
                        richTextBox2.AppendText($" \n 32 Left Deshifr \n{part1}\n");
                    }
                    part2 = cipher.Substring(i + 32, 32);
                    if (count == 1)
                    { richTextBox2.AppendText($"32 Right Deshifr\n{part2}\n"); }
                    part0 = part1;       //буфер
                    part1 = f_ExpP(part1);// перестановка с расширением
                    key_bin_part1 = key_bin.Substring(0, 28);                    //делим ключ пополам для сдвига-1ая часть
                    key_bin_part1 = f_key_shift(key_bin_part1, ai_key[15 - j], false);  // сдвигаем одну половину
                    key_bin_part2 = key_bin.Substring(28, 28);                  //делим ключ пополам для сдвига -2ая часть
                    key_bin_part2 = f_key_shift(key_bin_part2, ai_key[15 - j], false);  //сдвигаем другую
                    key_bin = key_bin_part1 + key_bin_part2;                      //соединям обе уже сдвинутые части 
                    key_bin1 = f_key(key_bin);
                    if (count == 1)
                    {
                        richTextBox5.AppendText($"48 bits key Deshifr\n{key_bin1}\n");
                    }
                    part1 = f_cypher(part1, key_bin1);                           // ксорим правую часть с ключом
                    part1 = f_S_Units(part1);
                    part1 = f_PP(part1);
                    part1 = f_cypher(part2, part1);
                    if (count == 1)
                    { richTextBox2.AppendText($"32 bits after function f Deshifr \n{part1}\n"); }
                    part2 = part0;
                    cipher_end += part1;
                    cipher_end += part2;
                    count++;
               }
                //else
                //{ richTextBox2.AppendText($"Insert the big message"); }
                cipher = cipher_end;
                cipher_end = "";
                count = 1;
            }

            int len = cipher.Length / 16;
            for (int i = 0; i < cyp.Length; i += 64)
            {
               // if (cyp.Length == 64)

                    cipher_end += f_IP_end(cipher.Substring(i, 64));
            }
            cipher = cipher_end;

            for (int i = 0; i < len; i++) //перевод всего что у нас получилось из 2ного вида в шифрованный текст.
            {
                string bin16 = cipher.Substring(0, 16);
                cipher = cipher.Remove(0, 16);
                int b = (int)f_bintodec(bin16);
                text += (char)b;
            }
            richTextBox4.Text = text;
        }

        private void button4_Click(object sender, EventArgs e)//кнопка для очистки 
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e) //кнопка для закрытия
        {
            Close();
        }
    }
}
