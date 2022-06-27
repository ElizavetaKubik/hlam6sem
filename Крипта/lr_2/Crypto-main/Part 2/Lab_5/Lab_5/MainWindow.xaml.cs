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

namespace Lab_5
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

        private int BinToDec(string bin)
        {
            int dec = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                dec += (int)(Math.Pow(2, bin.Length - i - 1) * Int32.Parse(bin[i].ToString()));
            }
            return dec;
        }

        private int[] left = new int[32];
        private int[] right = new int[32];
        private string leftRight = "";
        private string finish = "";

        private int[] SetPBoxExt(string ip, int round)
        {
            int[] sequence = new int[64]
            {
                39, 7, 47, 15, 55, 23, 63, 31,
                38, 6, 46, 14, 54, 22, 62, 30,
                37, 5, 45, 13, 53, 21, 61, 29,
                36, 4, 44, 12, 52, 20, 60, 28,
                35, 3, 43, 11, 51, 19, 59, 27,
                34, 2, 42, 10, 50, 18, 58, 26,
                33, 1, 41, 9, 49, 17, 57, 25,
                32, 0, 40, 8, 48, 16, 56, 24
            };

            int[] temp = new int[64];
            if (round == 0)
            {
                for (int i = 0; i < ip.Length; i++)
                {
                    temp[sequence[i]] = Int32.Parse(ip[i].ToString());
                }
            }
            else
            {
                for (int i = 0; i < ip.Length; i++)
                {
                    temp[i] = Int32.Parse(ip[i].ToString());
                }
            }

            int[] leftSequence = new int[32];
            int[] rightSequence = new int[32];
            for (int i = 0; i < (ip.Length / 2); i++)
            {
                leftSequence[i] = temp[i];
            }
            for (int i = 0; i < (ip.Length / 2); i++)
            {
                rightSequence[i] = temp[i + 32];
            }

            int[] pBoxExt = new int[48];
            pBoxExt[0] = rightSequence[31];     pBoxExt[1] = rightSequence[0];      pBoxExt[2] = rightSequence[1];      pBoxExt[3] = rightSequence[2];      pBoxExt[4] = rightSequence[3];      pBoxExt[5] = rightSequence[4];
            pBoxExt[6] = rightSequence[3];      pBoxExt[7] = rightSequence[4];      pBoxExt[8] = rightSequence[5];      pBoxExt[9] = rightSequence[6];      pBoxExt[10] = rightSequence[7];     pBoxExt[11] = rightSequence[8];
            pBoxExt[12] = rightSequence[7];     pBoxExt[13] = rightSequence[8];     pBoxExt[14] = rightSequence[9];     pBoxExt[15] = rightSequence[10];    pBoxExt[16] = rightSequence[11];    pBoxExt[17] = rightSequence[12];
            pBoxExt[18] = rightSequence[11];    pBoxExt[19] = rightSequence[12];    pBoxExt[20] = rightSequence[13];    pBoxExt[21] = rightSequence[14];    pBoxExt[22] = rightSequence[15];    pBoxExt[23] = rightSequence[16];
            pBoxExt[24] = rightSequence[15];    pBoxExt[25] = rightSequence[16];    pBoxExt[26] = rightSequence[17];    pBoxExt[27] = rightSequence[18];    pBoxExt[28] = rightSequence[19];    pBoxExt[29] = rightSequence[20];
            pBoxExt[30] = rightSequence[19];    pBoxExt[31] = rightSequence[20];    pBoxExt[32] = rightSequence[21];    pBoxExt[33] = rightSequence[22];    pBoxExt[34] = rightSequence[23];    pBoxExt[35] = rightSequence[24];
            pBoxExt[36] = rightSequence[23];    pBoxExt[37] = rightSequence[24];    pBoxExt[38] = rightSequence[25];    pBoxExt[39] = rightSequence[26];    pBoxExt[40] = rightSequence[27];    pBoxExt[41] = rightSequence[28];
            pBoxExt[42] = rightSequence[27];    pBoxExt[43] = rightSequence[28];    pBoxExt[44] = rightSequence[29];    pBoxExt[45] = rightSequence[30];    pBoxExt[46] = rightSequence[31];    pBoxExt[47] = rightSequence[0];

            for (int i = 0; i < leftSequence.Length; i++)
            {
                left[i] = leftSequence[i];
            }

            for (int i = 0; i < rightSequence.Length; i++)
            {
                right[i] = rightSequence[i];
            }

            return pBoxExt;
        }

        private string savedKey = "";

        private int[] SetKey(string key, int round)
        {
            int[] shift = new int[16]
            {
                1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1
            };

            int[] compKey = new int[56];
            if (round == 0)
            {
                for (int i = 0; i < (compKey.Length / 7); i++)
                {
                    compKey[i * 7] = Int32.Parse(key[i * 8].ToString());
                    compKey[(i * 7) + 1] = Int32.Parse(key[(i * 8) + 1].ToString());
                    compKey[(i * 7) + 2] = Int32.Parse(key[(i * 8) + 2].ToString());
                    compKey[(i * 7) + 3] = Int32.Parse(key[(i * 8) + 3].ToString());
                    compKey[(i * 7) + 4] = Int32.Parse(key[(i * 8) + 4].ToString());
                    compKey[(i * 7) + 5] = Int32.Parse(key[(i * 8) + 5].ToString());
                    compKey[(i * 7) + 6] = Int32.Parse(key[(i * 8) + 6].ToString());
                }
            }
            else
            {
                for (int i = 0; i < compKey.Length; i++)
                {
                    compKey[i] = Int32.Parse(key[i].ToString());
                }
            }

            int[] mixedCD = new int[56]
                {
                7, 15, 23, 55, 51, 43, 35, 6, 14, 22, 54, 50, 42, 34,
                5, 13, 21, 53, 49, 41, 33, 4, 12, 20, 52, 48, 40, 32,
                3, 11, 19, 27, 47, 39, 31, 2, 10, 18, 26, 46, 38, 30,
                1, 9, 17, 25, 45, 37, 29, 0, 8, 16, 24, 44, 36, 28
                };

            int[] mixedKey = new int[56];
            for (int i = 0; i < mixedKey.Length; i++)
            {
                mixedKey[mixedCD[i]] = compKey[i];
            }

            int[] CList = new int[28];
            int[] DList = new int[28];

            if (shift[round] == 1)
            {
                for (int i = 0; i < (mixedKey.Length / 2) - 1; i++)
                {
                    CList[i] = mixedKey[i + 1];
                    DList[i] = mixedKey[i + 29];
                }
                CList[27] = mixedKey[0];
                DList[27] = mixedKey[28];
            }
            else
            {
                for (int i = 0; i < (mixedKey.Length / 2) - 2; i++)
                {
                    CList[i] = mixedKey[i + 2];
                    DList[i] = mixedKey[i + 30];
                }
                CList[26] = mixedKey[0];
                CList[27] = mixedKey[1];
                DList[26] = mixedKey[28];
                DList[27] = mixedKey[29];
            }

            int[] unionKey = new int[56];
            for (int i = 0; i < (unionKey.Length / 2); i++)
            {
                unionKey[i] = CList[i];
                unionKey[i + 28] = DList[i];
            }

            string temp = "";
            for (int i = 0; i < unionKey.Length; i++)
            {
                temp += unionKey[mixedCD[i]].ToString();
            }
            savedKey = temp;

            int[] PBoxMixed = new int[48]
            {
                unionKey[13], unionKey[16], unionKey[10], unionKey[23], unionKey[0], unionKey[4], unionKey[2], unionKey[27],
                unionKey[14], unionKey[5], unionKey[20], unionKey[9], unionKey[22], unionKey[18], unionKey[11], unionKey[3],
                unionKey[25], unionKey[7], unionKey[15], unionKey[6], unionKey[26], unionKey[19], unionKey[12], unionKey[1],
                unionKey[40], unionKey[51], unionKey[30], unionKey[36], unionKey[46], unionKey[54], unionKey[29], unionKey[39],
                unionKey[50], unionKey[44], unionKey[32], unionKey[47], unionKey[43], unionKey[48], unionKey[38], unionKey[55],
                unionKey[33], unionKey[52], unionKey[45], unionKey[41], unionKey[49], unionKey[35], unionKey[28], unionKey[31]
            };

            return PBoxMixed;
        }

        private int[] CalcXor48(int[] PBoxExt, int[] Key)
        {
            int[] xor = new int[48];
            for (int i = 0; i < xor.Length; i++)
            {
                if ((((PBoxExt[i] == 0) && (Key[i] == 0))) || ((PBoxExt[i] == 1) && (Key[i] == 1)))
                {
                    xor[i] = 0;
                }
                else
                {
                    xor[i] = 1;
                }
            }
            return xor;
        }

        private int[] CalcXor32(int[] pBox)
        {
            int[] xor = new int[32];
            for (int i = 0; i < xor.Length; i++)
            {
                if ((((pBox[i] == 0) && (left[i] == 0))) || ((pBox[i] == 1) && (left[i] == 1)))
                {
                    xor[i] = 0;
                }
                else
                {
                    xor[i] = 1;
                }
            }
            return xor;
        }

        private int[] SetSBox(int[] xor)
        {
            int[] sBox = new int[32];

            int[] row = new int[8]
            {
                BinToDec((xor[0].ToString() + xor[5].ToString())),
                BinToDec((xor[6].ToString() + xor[11].ToString())),
                BinToDec((xor[12].ToString() + xor[17].ToString())),
                BinToDec((xor[18].ToString() + xor[23].ToString())),
                BinToDec((xor[24].ToString() + xor[29].ToString())),
                BinToDec((xor[30].ToString() + xor[35].ToString())),
                BinToDec((xor[36].ToString() + xor[41].ToString())),
                BinToDec((xor[42].ToString() + xor[47].ToString()))
            };

            int[] column = new int[8]
            {
                BinToDec((xor[1].ToString() + xor[2].ToString() + xor[3].ToString() + xor[4].ToString())),
                BinToDec((xor[7].ToString() + xor[8].ToString() + xor[9].ToString() + xor[10].ToString())),
                BinToDec((xor[13].ToString() + xor[14].ToString() + xor[15].ToString() + xor[16].ToString())),
                BinToDec((xor[19].ToString() + xor[20].ToString() + xor[21].ToString() + xor[22].ToString())),
                BinToDec((xor[25].ToString() + xor[26].ToString() + xor[27].ToString() + xor[28].ToString())),
                BinToDec((xor[31].ToString() + xor[32].ToString() + xor[33].ToString() + xor[34].ToString())),
                BinToDec((xor[37].ToString() + xor[38].ToString() + xor[39].ToString() + xor[40].ToString())),
                BinToDec((xor[43].ToString() + xor[44].ToString() + xor[45].ToString() + xor[46].ToString())),
            };

            int[,] S1 = new int[4, 16]
            {
                { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
                { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
                { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }
            };

            int[,] S2 = new int[4, 16]
            {
                { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
                { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
                { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
                { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }
            };

            int[,] S3 = new int[4, 16]
            {
                { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
                { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
                { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
                { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }
            };

            int[,] S4 = new int[4, 16]
            {
                { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
                { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
                { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }
            };

            int[,] S5 = new int[4, 16]
            {
                { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
                { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
                { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }
            };

            int[,] S6 = new int[4, 16]
            {
                { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }
            };

            int[,] S7 = new int[4, 16]
            {
                { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
                { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
                { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }
            };

            int[,] S8 = new int[4, 16]
            {
                { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
                { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
                { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }
            };

            sBox[0] = Int32.Parse(Convert.ToString(S1[row[0], column[0]], 2).PadLeft(4, '0')[0].ToString());
            sBox[1] = Int32.Parse(Convert.ToString(S1[row[0], column[0]], 2).PadLeft(4, '0')[1].ToString());
            sBox[2] = Int32.Parse(Convert.ToString(S1[row[0], column[0]], 2).PadLeft(4, '0')[2].ToString());
            sBox[3] = Int32.Parse(Convert.ToString(S1[row[0], column[0]], 2).PadLeft(4, '0')[3].ToString());

            sBox[4] = Int32.Parse(Convert.ToString(S2[row[1], column[1]], 2).PadLeft(4, '0')[0].ToString());
            sBox[5] = Int32.Parse(Convert.ToString(S2[row[1], column[1]], 2).PadLeft(4, '0')[1].ToString());
            sBox[6] = Int32.Parse(Convert.ToString(S2[row[1], column[1]], 2).PadLeft(4, '0')[2].ToString());
            sBox[7] = Int32.Parse(Convert.ToString(S2[row[1], column[1]], 2).PadLeft(4, '0')[3].ToString());

            sBox[8] = Int32.Parse(Convert.ToString(S3[row[2], column[2]], 2).PadLeft(4, '0')[0].ToString());
            sBox[9] = Int32.Parse(Convert.ToString(S3[row[2], column[2]], 2).PadLeft(4, '0')[1].ToString());
            sBox[10] = Int32.Parse(Convert.ToString(S3[row[2], column[2]], 2).PadLeft(4, '0')[2].ToString());
            sBox[11] = Int32.Parse(Convert.ToString(S3[row[2], column[2]], 2).PadLeft(4, '0')[3].ToString());

            sBox[12] = Int32.Parse(Convert.ToString(S4[row[3], column[3]], 2).PadLeft(4, '0')[0].ToString());
            sBox[13] = Int32.Parse(Convert.ToString(S4[row[3], column[3]], 2).PadLeft(4, '0')[1].ToString());
            sBox[14] = Int32.Parse(Convert.ToString(S4[row[3], column[3]], 2).PadLeft(4, '0')[2].ToString());
            sBox[15] = Int32.Parse(Convert.ToString(S4[row[3], column[3]], 2).PadLeft(4, '0')[3].ToString());

            sBox[16] = Int32.Parse(Convert.ToString(S5[row[4], column[4]], 2).PadLeft(4, '0')[0].ToString());
            sBox[17] = Int32.Parse(Convert.ToString(S5[row[4], column[4]], 2).PadLeft(4, '0')[1].ToString());
            sBox[18] = Int32.Parse(Convert.ToString(S5[row[4], column[4]], 2).PadLeft(4, '0')[2].ToString());
            sBox[19] = Int32.Parse(Convert.ToString(S5[row[4], column[4]], 2).PadLeft(4, '0')[3].ToString());

            sBox[20] = Int32.Parse(Convert.ToString(S6[row[5], column[5]], 2).PadLeft(4, '0')[0].ToString());
            sBox[21] = Int32.Parse(Convert.ToString(S6[row[5], column[5]], 2).PadLeft(4, '0')[1].ToString());
            sBox[22] = Int32.Parse(Convert.ToString(S6[row[5], column[5]], 2).PadLeft(4, '0')[2].ToString());
            sBox[23] = Int32.Parse(Convert.ToString(S6[row[5], column[5]], 2).PadLeft(4, '0')[3].ToString());

            sBox[24] = Int32.Parse(Convert.ToString(S7[row[6], column[6]], 2).PadLeft(4, '0')[0].ToString());
            sBox[25] = Int32.Parse(Convert.ToString(S7[row[6], column[6]], 2).PadLeft(4, '0')[1].ToString());
            sBox[26] = Int32.Parse(Convert.ToString(S7[row[6], column[6]], 2).PadLeft(4, '0')[2].ToString());
            sBox[27] = Int32.Parse(Convert.ToString(S7[row[6], column[6]], 2).PadLeft(4, '0')[3].ToString());

            sBox[28] = Int32.Parse(Convert.ToString(S8[row[7], column[7]], 2).PadLeft(4, '0')[0].ToString());
            sBox[29] = Int32.Parse(Convert.ToString(S8[row[7], column[7]], 2).PadLeft(4, '0')[1].ToString());
            sBox[30] = Int32.Parse(Convert.ToString(S8[row[7], column[7]], 2).PadLeft(4, '0')[2].ToString());
            sBox[31] = Int32.Parse(Convert.ToString(S8[row[7], column[7]], 2).PadLeft(4, '0')[3].ToString());

            return sBox;
        }

        private void Round(int[] sBox)
        {
            int[] pBox = new int[32]
            {
                sBox[15], sBox[6], sBox[19], sBox[20], sBox[28], sBox[11], sBox[27], sBox[16],
                sBox[0], sBox[14], sBox[22], sBox[25], sBox[4], sBox[17], sBox[30], sBox[9],
                sBox[1], sBox[7], sBox[23], sBox[13], sBox[31], sBox[26], sBox[2], sBox[8],
                sBox[18], sBox[12], sBox[29], sBox[5], sBox[21], sBox[10], sBox[3], sBox[24]
            };

            int[] round = CalcXor32(pBox);
            left = right;
            right = round;

            string temp = "";
            for (int i = 0; i < left.Length; i++)
            {
                temp += Int32.Parse(left[i].ToString());
            }

            for (int i = 0; i < right.Length; i++)
            {
                temp += Int32.Parse(right[i].ToString());
            }
            leftRight = temp;
        }

        private void Final(int[] left, int[] right)
        {
            int[] temp = new int[64];
            for (int i = 0; i < (temp.Length / 2); i++)
            {
                temp[i] = right[i];
                temp[i + 32] = left[i];
            }

            int[] sequence = new int[64]
            {
                57, 49, 41, 33, 25, 17, 9, 1,
                59, 51, 43, 35, 27, 19, 11, 3,
                61, 53, 45, 37, 29, 21, 13, 5,
                61, 55, 47, 39, 31, 23, 15, 7,
                56, 48, 40, 32, 24, 16, 8, 0,
                58, 50, 42, 34, 26, 18, 10, 2,
                60, 52, 44, 36, 28, 20, 12, 4,
                62, 54, 46, 38, 30, 22, 14, 6
            };

            int[] final = new int[64];
            for (int i = 0; i < final.Length; i++)
            {
                final[sequence[i]] = Int32.Parse(temp[i].ToString());
            }

            finish = "";
            for (int i = 0; i < final.Length; i++)
            {
                finish += Int32.Parse(final[i].ToString());
            }
        }

        private void DES()
        {
            for (int i = 0; i < 16; i++)
            {
                int[] pBoxExt = SetPBoxExt(leftRight, i);
                int[] key = SetKey(savedKey, i);
                int[] xor = CalcXor48(pBoxExt, key);
                int[] sBox = SetSBox(xor);
                Round(sBox);
            }
            Final(left, right);
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            if (RichText.GetText(RichTextOrig) != String.Empty)
            {
                //string text = RichText.GetText(RichTextOrig).Substring(0, RichText.GetText(RichTextOrig).Length - 2);
                //string binText = "";
                //var letters = Encoding.ASCII.GetBytes(text);
                //foreach (int letter in letters)
                //{
                //    binText += Convert.ToString(letter, 2).PadLeft(8, '0');
                //}
                //if (binText.Length % 64 != 0)
                //{
                //    int length = (binText.Length / 64) * 64 + 64;
                //    binText = binText.PadRight(length, '0');
                //}

                //string binKey = "";
                //var keys = Encoding.ASCII.GetBytes(Key.Text.PadRight(8, ' ').Substring(0, 8));
                //foreach (int key in keys)
                //{
                //    binKey += Convert.ToString(key, 2).PadLeft(8, '0');
                //}

                //savedKey = binKey;
                //string encText = "";
                //for (int i = 0; i < (binText.Length / 64); i++)
                //{
                //    leftRight = binText.Substring((i * 64), 64);
                //    DES();
                //    encText += finish;
                //}
                //RichText.SetText(RichTextEnc, encText);

                //DEMO
                leftRight = "0001001000110100010101101010101111001101000100110010010100110110";
                savedKey = "1010101010111011000010010001100000100111001101101100110011011101";
                DES();
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
